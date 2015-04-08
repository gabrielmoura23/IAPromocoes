using IAPromocoes.Application.Interfaces;
using IAPromocoes.Application.ViewModels;
using IAPromocoes.UI.MVC.Models;
using IAPromocoes.UI.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;

namespace IAPromocoes.UI.MVC.Controllers
{
    [Authorize]
    public class CarrinhoController : Controller
    {
        private readonly IProdutoAppService _produtoApp;
        private readonly IProdutoPrecoAppService _produtoPrecoApp;
        private readonly IPedidoAppService _pedidoApp;


        public CarrinhoController(IProdutoAppService produtoApp, 
                                    IPedidoAppService pedidoApp,
                                    IProdutoPrecoAppService produtoPrecoApp)
        {
            _produtoApp = produtoApp;
            _produtoPrecoApp = produtoPrecoApp;
            _pedidoApp = pedidoApp;
        }

        public RedirectToRouteResult Adicionar(Guid IdProduto, string IdProdutoPreco, int qtdProduto, string returnUrl)
        {
            if (qtdProduto <= 0 || IdProdutoPreco.Equals("0"))
            {
                return RedirectToAction("Detalhes", "Produto", new { IdProduto = IdProduto });
            }
            else
            {
                var produto = _produtoApp.GetById(IdProduto);
                var produtoPreco = _produtoPrecoApp.GetById(Guid.Parse(IdProdutoPreco));

                if (produto != null && produtoPreco != null)
                {
                    ObterCarrinho().AdicionarItem(produto, qtdProduto, produtoPreco);

                }

                return RedirectToAction("Index", new { returnUrl });
            }
        }

        public RedirectToRouteResult Atualizar(Guid IdProduto, string IdProdutoPreco, int qtdProduto, string returnUrl)
        {
            if (qtdProduto <= 0)
            {
                return RedirectToAction("Index", new { returnUrl });
            }
            else
            {
                var produto = _produtoApp.GetById(IdProduto);
                var produtoPreco = _produtoPrecoApp.GetById(Guid.Parse(IdProdutoPreco));

                if (produto != null && produtoPreco != null)
                {
                    ObterCarrinho().AtualizarItem(produto, qtdProduto, produtoPreco);

                }

                return RedirectToAction("Index", new { returnUrl });
            }
        }

        private Carrinho ObterCarrinho()
        {
            Carrinho carrinho = (Carrinho)Session["Carrinho"];

            if (carrinho == null)
            {
                carrinho = new Carrinho();
                Session["Carrinho"] = carrinho;
            }

            return carrinho;
        }

        public RedirectToRouteResult Remover(Guid IdProduto, string IdProdutoPreco, string returnUrl)
        {

            var produto = _produtoApp.GetById(IdProduto);
            var produtoPreco = _produtoPrecoApp.GetById(Guid.Parse(IdProdutoPreco));

            if (produto != null && produtoPreco != null)
            {
                ObterCarrinho().RemevorItem(produto, produtoPreco);
            }

            return RedirectToAction("Index", new { returnUrl });
        }
      

        public ViewResult Index(string returnurl)
        {
            Carrinho carrinho = ObterCarrinho();
            if (!carrinho.ItensCarrinho.Any())
            {
                return View("Vazio");
            }

            return View(new CarrinhoViewModel
            {
                Carrinho = carrinho,
                ReturnUrl = returnurl
            });
        }

        public PartialViewResult _Resumo()
        {
            Carrinho carrinho = ObterCarrinho();
            return PartialView(carrinho);
        }

        public PartialViewResult _Lista()
        {
            return PartialView(new CarrinhoViewModel
            {
                Carrinho = ObterCarrinho(),
                ReturnUrl = String.Empty
            });
        }

        public ViewResult FecharPedido()
        {
            Carrinho carrinho = ObterCarrinho();
            if (!carrinho.ItensCarrinho.Any())
            {
                return View("Vazio");
            }

            return View(new PedidoViewModel());
        }


        [ActionName("FecharPedido")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ViewResult FecharPedido(PedidoViewModel pedidoModel)
        public ActionResult ConfirmaFecharPedido()
        {
            Carrinho carrinho = ObterCarrinho();

            //EmailConfiguracoes email = new EmailConfiguracoes
            //{
            //    EscreverArquivo = bool.Parse(ConfigurationManager.AppSettings["Email.EscreverArquivo"] ?? "false")
            //};

            //EmailPedido emailPedido = new EmailPedido(email);

            if (!carrinho.ItensCarrinho.Any())
            {
                ModelState.AddModelError("", "Não foi possível concluir o pedido, seu carrinho está vazio!");
            }

            if (ModelState.IsValid)
            {
                //Guid guid = (Guid) Membership.GetUser().ProviderUserKey;

                var pedidoModel = new PedidoViewModel();
                pedidoModel.IdPedido = Guid.NewGuid();
                pedidoModel.DataPedido = DateTime.Now;
                pedidoModel.DtCadastro = DateTime.Now;
                pedidoModel.HoraPedido = DateTime.Now;
                pedidoModel.IdCliente = Guid.Parse(User.Identity.GetUserId());
                pedidoModel.IdStatusPedido = 3;
                pedidoModel.ValorTotal = carrinho.ObterValorTotal();

                foreach(var item in carrinho.ItensCarrinho)
                {
                    var itemModel = new ItemPedidoViewModel();
                    itemModel.IdItemPedido = Guid.NewGuid();
                    itemModel.IdPedido = pedidoModel.IdPedido;
                    itemModel.IdProduto = item.Produto.IdProduto;
                    itemModel.IdProdutoPreco = item.ProdutoPreco.IdProdutoPreco;
                    itemModel.QtdProduto = item.Quantidade;
                    itemModel.ValorUnitario = item.ProdutoPreco.ValorUnitario;
                    itemModel.DtCadastro = pedidoModel.DtCadastro;
                    itemModel.IdUsuarioCadastro = Guid.NewGuid();                    

                    pedidoModel.ItensPedido.Add(itemModel);
                }

                Session["Pedido"] = pedidoModel;
                //Session["ItensPedido"] = pedidoModel.ItensPedido;

                return RedirectToAction("Pagamento", "Pedido");

                //var result = _pedidoApp.Add(pedidoModel);

                //if (!result.IsValid)
                //{
                //    foreach (var validationAppError in result.Erros)
                //    {
                //        ModelState.AddModelError(string.Empty, validationAppError.Message);
                //    }
                //    return View(pedidoModel);
                //}

                //emailPedido.ProcessarPedido(carrinho, pedido);
                //carrinho.LimparCarrinho();
                //return View("PedidoConcluido");
            }
            else
            {
                return View();
                //return View(pedidoModel);
            }

        }

        public ViewResult PedidoConcluido()
        {
            return View();
        }

        public PartialViewResult _CarrinhoPadrao()
        {
            return PartialView(new CarrinhoViewModel
            {
                Carrinho = ObterCarrinho(),
                ReturnUrl = String.Empty
            });
            //Carrinho carrinho = ObterCarrinho();
            //return PartialView(carrinho);
        }

        public ViewResult Vazio()
        {
            return View();
        }
        
    }
}
