using IAPromocoes.Application.Interfaces;
using IAPromocoes.Application.ViewModels;
using IAPromocoes.UI.MVC.Models;
using IAPromocoes.UI.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IAPromocoes.UI.MVC.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly IProdutoAppService _produtoApp;
        private readonly IPedidoAppService _pedidoApp;


        public CarrinhoController(IProdutoAppService produtoApp, IPedidoAppService pedidoApp)
        {
            _produtoApp = produtoApp;
            _pedidoApp = pedidoApp;
        }

        public RedirectToRouteResult Adicionar(Guid IdProduto, int qtdProduto, string returnUrl)
        {
            if (qtdProduto <= 0)
            {
                return RedirectToAction("Detalhes", new { returnUrl });
            }
            else
            {
                var produto = _produtoApp.GetById(IdProduto);

                if (produto != null)
                {
                    ObterCarrinho().AdicionarItem(produto, qtdProduto);

                }

                return RedirectToAction("Index", new { returnUrl });
            }
        }

        public RedirectToRouteResult Atualizar(Guid IdProduto, int qtdProduto, string returnUrl)
        {
            if (qtdProduto <= 0)
            {
                return RedirectToAction("Detalhes", new { returnUrl });
            }
            else
            {
                var produto = _produtoApp.GetById(IdProduto);

                if (produto != null)
                {
                    ObterCarrinho().AtualizarItem(produto, qtdProduto);

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

        public RedirectToRouteResult Remover(Guid IdProduto, string returnUrl)
        {

            var produto = _produtoApp.GetById(IdProduto);

            if (produto != null)
            {
                ObterCarrinho().RemevorItem(produto);
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


        [HttpPost]
        public ViewResult FecharPedido(PedidoViewModel pedidoModel)
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
                pedidoModel.ValorTotal = carrinho.ObterValorTotal();

                var result = _pedidoApp.Add(pedidoModel);

                if (!result.IsValid)
                {
                    foreach (var validationAppError in result.Erros)
                    {
                        ModelState.AddModelError(string.Empty, validationAppError.Message);
                    }
                    return View(pedidoModel);
                }

                //emailPedido.ProcessarPedido(carrinho, pedido);
                carrinho.LimparCarrinho();
                return View("PedidoConcluido");
            }
            else
            {
                return View(pedidoModel);
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
