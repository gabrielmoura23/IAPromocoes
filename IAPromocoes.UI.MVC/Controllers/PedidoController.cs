using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IAPromocoes.Application.ViewModels;
using IAPromocoes.Application.Interfaces;

namespace IAPromocoes.UI.MVC.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoAppService _pedidoApp;
        private readonly IProdutoAppService _produtoApp;

        public PedidoController(
            IPedidoAppService pedidoApp,
            IProdutoAppService produtoApp)
        {
            _pedidoApp = pedidoApp;
            _produtoApp = produtoApp;
        }

        // GET: Pedido
        public ActionResult Index()
        {
            var pedidoViewModel = _pedidoApp.GetAll();
            return View(pedidoViewModel);
        }

        // GET: Pedido/Details/5
        public ActionResult Details(Guid id)
        {
            var pedidoViewModel = _pedidoApp.GetById(id);
            //pedidoViewModel.Enderecos = _enderecoApp.ObterPorCliente(id);

            return View(pedidoViewModel);
        }

        // GET: Pedido/Create
        public ActionResult Create()
        {
            //ViewBag.EstadoId = new SelectList(_estadoApp.GetAll().OrderBy(e => e.Nome), "EstadoId", "Nome");
            //ViewBag.CidadeId = new SelectList(_cidadeApp.GetAll().OrderBy(c => c.Nome), "CidadeId", "Nome");

            return View();
        }

        // POST: Pedido/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PedidoViewModel pedidoViewModel)
        {
            //ViewBag.EstadoId = new SelectList(_estadoApp.GetAll().OrderBy(e => e.Nome), "EstadoId", "Nome", clienteEndereco.EstadoId);
            //ViewBag.CidadeId = new SelectList(_cidadeApp.GetAll().OrderBy(c => c.Nome), "CidadeId", "Nome", clienteEndereco.CidadeId);

            if (ModelState.IsValid)
            {
                var result = _pedidoApp.Add(pedidoViewModel);

                if (!result.IsValid)
                {
                    foreach (var validationAppError in result.Erros)
                    {
                        ModelState.AddModelError(string.Empty, validationAppError.Message);
                    }
                    return View(pedidoViewModel);
                }

                return RedirectToAction("Index");
            }

            return View(pedidoViewModel);
        }

        // GET: Pedido/Edit/5
        public ActionResult Edit(Guid id)
        {
            var pedidoViewModel = _pedidoApp.GetById(id);

            return View(pedidoViewModel);
        }

        // POST: Pedido/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PedidoViewModel pedidoViewModel)
        {
            if (ModelState.IsValid)
            {
                _pedidoApp.Update(pedidoViewModel);

                return RedirectToAction("Index");
            }

            return View(pedidoViewModel);
        }

        // GET: Pedido/Delete/5
        public ActionResult Delete(Guid id)
        {
            var pedidoViewModel = _pedidoApp.GetById(id);

            return View(pedidoViewModel);
        }

        // POST: Pedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var model = _pedidoApp.GetById(id);
            _pedidoApp.Remove(model);

            return RedirectToAction("Index");
        }


        public ActionResult AdicionarCarrinho(Guid idProduto, Guid idProdutoPreco)
        {
            // Ao invés de colocar uma lista de ítens de Design, vamos colocar
            // Um objeto da entidade Pedido, que já possui List<ItemDesign>.
            // List<ItemDesign> carrinho = Session["Carrinho"] != null ? (List<ItemDesign>)Session["Carrinho"] : new List<ItemDesign>();
            var carrinho = Session["Carrinho"] != null ? (PedidoViewModel) Session["Carrinho"] : new PedidoViewModel();
            var produtoViewModel = _produtoApp.GetById(idProduto);

            if (produtoViewModel != null)
            {
                //pego o Preço escolhido do produto
                var produtoPrecoViewModel = produtoViewModel.ProdutoPrecosViewModel.Where(t => t.IdProdutoPreco == idProdutoPreco).FirstOrDefault();
                if (produtoPrecoViewModel != null)
                {
                    var itemPedido = new ItemPedidoViewModel();
                    //itemPedido.IdItemPedido = Guid.NewGuid();
                    itemPedido.IdPedido = carrinho.IdPedido;
                    itemPedido.IdProduto = idProduto;
                    itemPedido.QtdProduto = 1;
                    itemPedido.ValorUnitario = produtoPrecoViewModel.ValorUnitario;

                    if (carrinho.ItensPedido.FirstOrDefault(x => x.IdProduto == produtoViewModel.IdProduto) != null)
                        carrinho.ItensPedido.FirstOrDefault(x => x.IdProduto == produtoViewModel.IdProduto).QtdProduto += 1;
                    else
                        carrinho.ItensPedido.Add(itemPedido);

                
                    // Aqui podemos fazer o cálculo do valor
                    //carrinho.ValorTotal = carrinho.ItensDesign.Select(i => i.Design).Sum(d => d.Preco);
                    carrinho.ValorTotal = carrinho.ItensPedido.SelectMany(i => i.ProdutoViewModel.ProdutoPrecosViewModel).Sum(i => i.ValorUnitario);

                    Session["Carrinho"] = carrinho;
                }
            }

            return RedirectToAction("Carrinho");
        }

        public ActionResult Carrinho()
        {
            var carrinho = Session["Carrinho"] != null ? (PedidoViewModel)Session["Carrinho"] : new PedidoViewModel();

            return View(carrinho);
        }


        public ActionResult ExcluirItem(Guid id)
        {
            var carrinho = Session["Carrinho"] != null ? (PedidoViewModel) Session["Carrinho"] : new PedidoViewModel();
            var itemExclusao = carrinho.ItensPedido.FirstOrDefault(i => i.IdItemPedido == id);
            carrinho.ItensPedido.Remove(itemExclusao);

            Session["Carrinho"] = carrinho;
            return RedirectToAction("Carrinho");
        }

        public ActionResult SalvarCarrinho()
        {
            var carrinho = Session["Carrinho"] != null ? (PedidoViewModel)Session["Carrinho"] : new PedidoViewModel();

            //contexto.Pedidos.Add(carrinho);
            //contexto.SaveChanges();

            return RedirectToAction("Carrinho");
        }


        public ActionResult Finalizar()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
    }
}
