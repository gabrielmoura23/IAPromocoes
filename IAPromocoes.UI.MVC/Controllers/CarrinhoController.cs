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


        public CarrinhoController(IProdutoAppService produtoApp)
        {
            _produtoApp = produtoApp;
        }

        public RedirectToRouteResult Adicionar(Guid IdProduto, string returnUrl)
        {
            var produto = _produtoApp.GetById(IdProduto);
            
            if (produto != null)
            {
                ObterCarrinho().AdicionarItem(produto, 1);

            }

            return RedirectToAction("Index", new { returnUrl });

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
            return View(new CarrinhoViewModel
            {
                Carrinho = ObterCarrinho(),
                ReturnUrl = returnurl
            });
        }

        public PartialViewResult _Resumo()
        {
            Carrinho carrinho = ObterCarrinho();
            return PartialView(carrinho);
        }


        public ViewResult FecharPedido()
        {
            return View(new PedidoViewModel());
        }


        [HttpPost]
        public ViewResult FecharPedido(PedidoViewModel pedido)
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
                //emailPedido.ProcessarPedido(carrinho, pedido);
                carrinho.LimparCarrinho();
                return View("PedidoConcluido");
            }
            else
            {
                return View(pedido);
            }

        }

        public ViewResult PedidoConcluido()
        {
            return View();
        }

        
    }
}
