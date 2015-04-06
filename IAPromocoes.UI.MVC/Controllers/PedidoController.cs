using IAPromocoes.Application.Interfaces;
using IAPromocoes.Application.ViewModels;
using IAPromocoes.UI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Uol.PagSeguro.Constants;
using Uol.PagSeguro.Domain;
using Uol.PagSeguro.Exception;
using Uol.PagSeguro.Resources;

namespace IAPromocoes.UI.MVC.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoAppService _pedidoApp;
        private readonly IItemPedidoAppService _itemPedidoApp;
        private readonly IFormaDePagamentoAppService _formaPagamentoApp;
        private readonly IProdutoAppService _produtoApp;

        public PedidoController(IPedidoAppService pedidoApp,
                                IItemPedidoAppService itemPedidoApp,
                                IProdutoAppService produtoApp,
                                IFormaDePagamentoAppService formaPagamentoApp)
        {
            _pedidoApp = pedidoApp;
            _itemPedidoApp = itemPedidoApp;
            _produtoApp = produtoApp;
            _formaPagamentoApp = formaPagamentoApp;
        }

        // GET: Pedido
        public ActionResult Index()
        {
            return View();
        }

        // GET: Pedido/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pedido/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pedido/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pedido/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pedido/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pedido/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pedido/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Pagamento()
        {
            var pedidoModel = (PedidoViewModel)Session["Pedido"];
            if (pedidoModel == null)
            {
                return RedirectToAction("Vazio", "Carrinho");
            }

            ViewBag.IdFormaDePagamento = new SelectList(_formaPagamentoApp.GetAll(), "IdFormaDePagamento", "Descricao");
            //Carrinho carrinho = ObterCarrinho();
            //return PartialView(carrinho);
            return View(pedidoModel);
        }

        [HttpPost]
        public ActionResult Pagamento(PedidoViewModel pedidoViewModel)
        {
            var pedidoModel = (PedidoViewModel)Session["Pedido"];
            if (pedidoModel == null)
            {
                return RedirectToAction("Vazio", "Carrinho");
            }

            pedidoModel.IdFormaDePagamento = pedidoViewModel.IdFormaDePagamento;
            Session["Pedido"] = pedidoModel;
            return RedirectToAction("Resumo");
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Resumo()
        {
            var pedidoModel = (PedidoViewModel)Session["Pedido"];
            if (pedidoModel == null)
            {
                return RedirectToAction("Vazio", "Carrinho");
            }

            var formaPagamento = _formaPagamentoApp.GetByIdTipoInteiro(pedidoModel.IdFormaDePagamento);
            if (formaPagamento != null)
                ViewBag.FormaDePagamento = formaPagamento.Descricao;


            //Carrinho carrinho = ObterCarrinho();
            //return PartialView(carrinho);
            return View(pedidoModel);
        }

        public ActionResult PagSeguro()
        {
            //Carrinho carrinho = ObterCarrinho();
            //return PartialView(carrinho);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Confirmacao()
        {
            var pedidoModel = (PedidoViewModel)Session["Pedido"];
            if (pedidoModel == null)
            {
                return RedirectToAction("Vazio", "Carrinho");
            }

            var formaPagamento = _formaPagamentoApp.GetByIdTipoInteiro(pedidoModel.IdFormaDePagamento);
            if (formaPagamento != null)
                ViewBag.FormaDePagamento = formaPagamento.Descricao;

            //Carrinho carrinho = ObterCarrinho();
            //return PartialView(carrinho);
            //return View(pedidoModel);

            if (ModelState.IsValid)
            {
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
                //carrinho.LimparCarrinho();
                Session.Remove("Carrinho");
                Session.Remove("Pedido");
                //return View("PedidoConcluido");
                return View("Confirmacao", pedidoModel);
            }
            else
            {
                //return View();
                return View(pedidoModel);
            }
        }


        public ViewResult PedidoConcluido()
        {
            return View();
        }



        public ActionResult Pagar(string IdPedido)
        {

            //model.Produto = (from i in Lista
            //                 where i.ID_PRODUTO == id
            //                 select i).FirstOrDefault();

            //var pedidoModel = _pedidoApp.GetById(Guid.Parse(IdPedido));
            var includes = new[] { "ItensPedido" };
            var pedidoModel = _pedidoApp.GetByIdWithIncludes(Guid.Parse(IdPedido), includes);

            if (pedidoModel != null)
            {
                PagamentoPagSeguroModel model = new PagamentoPagSeguroModel();
                model.Pedido = new PagamentoPagSeguroPedido { Reference = "P" + IdPedido + "#" + DateTime.Now.Millisecond, RedirectUri = "https://www.google.com.br/search?q=url-temporaria" };
                model.Cobrador = new PagamentoPagSeguroCobrador { Nome = "Gabriel Teste Silva", CPF = "33565201720", Email = "gabrielm@fieb.org.br", TelefonePrevixo = 71, TelefoneNumero = 88637803 };

                //PagSeguroConfiguration.UrlXmlConfiguration = HttpRuntime.AppDomainAppPath + @"Configuration\PagSeguroConfig.xml";
                AccountCredentials credentials = new AccountCredentials("gabrielandrade.moura@gmail.com", "63FB07B49624434E9AE4802EBA036F00");

                try
                {
                    PaymentRequest payment = new PaymentRequest();
                    payment.Currency = Currency.Brl;
                    
                    
                    //payment.Items.Add(new Item(model.Produto.ID_PRODUTO.ToString(), model.Produto.Nome, 1, Convert.ToDecimal(model.Produto.Valor)));


                    //var itensPedidoModel = _itemPedidoApp.BuscarItensPorIdPedido(pedidoModel.IdPedido);
                    foreach (var item in pedidoModel.ItensPedido)
                    {
                        var produtoModel = _produtoApp.GetById(item.IdProduto);
                        payment.Items.Add(new Item(item.IdProduto.ToString(), produtoModel.Descricao, 1, Convert.ToDecimal(item.ValorUnitario)));
                    }

                    payment.Reference = model.Pedido.Reference;
                    payment.Shipping = new Shipping();
                    payment.Shipping.ShippingType = ShippingType.NotSpecified;
                    payment.Shipping.Cost = 0.00m;

                    payment.Shipping.Address = new Address(
                        "BRA",
                        "SP",
                        "Sao Paulo",
                        "Jardim Paulistano",
                        "01452002",
                        "Av. Brig. Faria Lima",
                        "1384",
                        "5o andar"
                    );  

                    //payment.Shipping.Address = new Address(
                    //    model.Endereco.Pais,
                    //    model.Endereco.Estado,
                    //    model.Endereco.Cidade,
                    //    model.Endereco.Bairro,
                    //    model.Endereco.Cep,
                    //    model.Endereco.Rua,
                    //    model.Endereco.Numero,
                    //    model.Endereco.Complemento
                    //);

                    // Sets your customer information.
                    payment.Sender = new Sender(
                        model.Cobrador.Nome,
                        model.Cobrador.Email,
                        new Phone(model.Cobrador.TelefonePrevixo.ToString(), model.Cobrador.TelefoneNumero.ToString())
                    );

                    // Sets the url used by PagSeguro for redirect user after ends checkout process
                    //payment.RedirectUri = new Uri(@"" + model.Pedido.RedirectUri);
                    

                    //payment.RedirectUri = new Uri(HttpRuntime.AppDomainAppPath + @"Configuration\PagSeguroConfig.xml");
                    
                    SenderDocument senderCPF = new SenderDocument(Documents.GetDocumentByType("CPF"), model.Cobrador.CPF);
                    payment.Sender.Documents.Add(senderCPF);
                    string paymentRedirectUri = payment.Register(credentials).ToString();

                    if (!string.IsNullOrEmpty(paymentRedirectUri))
                    {
                        return Redirect(paymentRedirectUri);
                    }
                    else
                    {
                        ViewBag.Retorno = paymentRedirectUri;
                        return View();
                    }
                }
                catch (PagSeguroServiceException exception)
                {
                    ViewBag.Erro = "Não Foi possivel carregar a página";
                    return View("Error");
                }
            }
            else
            {
                return View();
            }
        }
    }
}
