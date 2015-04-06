using IAPromocoes.Application.Interfaces;
using IAPromocoes.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace IAPromocoes.UI.MVC.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoAppService _produtoApp;
        private readonly IProdutoImagemAppService _produtoImagemApp;
        private readonly IProdutoPrecoAppService _produtoPrecoApp;
        public const int RecordsPerPage = 6;

        public ProdutoController(IProdutoAppService produtoApp,
                                IProdutoImagemAppService produtoImagemApp,
                                IProdutoPrecoAppService produtoPrecoApp)
        {
            _produtoApp = produtoApp;
            _produtoImagemApp = produtoImagemApp;
            _produtoPrecoApp = produtoPrecoApp;
            ViewBag.RecordsPerPage = RecordsPerPage;
        }

        public ActionResult GetCustomers(int? pageNum, string flgOrdenacao, string sort, string order)
        {
            pageNum = pageNum ?? 0;
            ViewBag.IsEndOfRecords = false;

            if (String.IsNullOrEmpty(flgOrdenacao))
                flgOrdenacao = "N";


            //if (flgOrdenacao.Equals("S"))
            //{
            //    //mudar pra botar todos em uma sessao e nao consultar toda hora

            //    LoadAllCustomersToSession(sort, order);
            //    var customers = GetRecordsForPage(pageNum.Value, sort, order);
            //    ViewBag.Customers = customers;

            //    return PartialView("_Produtos", customers);
            //}
            //else 
            if (Request.IsAjaxRequest())
            {
                var customers = GetRecordsForPage(pageNum.Value, sort, order);
                ViewBag.IsEndOfRecords = (customers.Any()) && ((pageNum.Value * RecordsPerPage) >= customers.Last().Key);
                return PartialView("_Produtos", customers);
            }
            else
            {
                LoadAllCustomersToSession(sort, order);
                ViewBag.Customers = GetRecordsForPage(pageNum.Value, sort, order);
                return View("Lista");
            }
        }

        public void LoadAllCustomersToSession(string sort, string order)
        {
            var produtoViewModel = _produtoApp.GetAll();
            //return View(produtoViewModel);

            //padrao ordena por data de cadastro
            if (String.IsNullOrEmpty(sort) || sort.Equals("pd.padrao"))
                sort = "DtCadastro";
            else if (sort.Equals("pd.descricao"))
                sort = "Descricao";
            else if (sort.Equals("pd.preco"))
                sort = "Preco";

            if (!String.IsNullOrEmpty(order) && order.Equals("DESC"))
                produtoViewModel = produtoViewModel.OrderByDescending(t => t.GetType().GetProperty(sort).GetValue(t, null));
            else
                produtoViewModel = produtoViewModel.OrderBy(t => t.GetType().GetProperty(sort).GetValue(t, null));


            //var customerRepo = new CustomerRepository();
            //var customers = customerRepo.ListCustomers();
            int custIndex = 1;
            Session["Customers"] = produtoViewModel.ToDictionary(x => custIndex++, x => x);
            ViewBag.TotalNumberCustomers = produtoViewModel.Count();
        }

        public Dictionary<int, ProdutoViewModel> GetRecordsForPage(int pageNum, string sort, string order)
        {
            Dictionary<int, ProdutoViewModel> customers = (Session["Customers"] as Dictionary<int, ProdutoViewModel>);

            int from = (pageNum * RecordsPerPage);
            int to = from + RecordsPerPage;

            if (String.IsNullOrEmpty(sort) || sort.Equals("pd.padrao"))
                sort = "DtCadastro";
            else if (sort.Equals("pd.descricao"))
                sort = "Descricao";
            else if (sort.Equals("pd.preco"))
                sort = "Preco";

            if (!String.IsNullOrEmpty(order) && order.Equals("DESC"))
                customers = customers.OrderByDescending(x => x.Value.GetType().GetProperty(sort).GetValue(x.Value, null))
                        .ToDictionary(x => x.Key, x => x.Value);
            else
                customers = customers.OrderBy(x => x.Value.GetType().GetProperty(sort).GetValue(x.Value, null))
                        .ToDictionary(x => x.Key, x => x.Value);

            int custIndex = 1;
            Dictionary<int, ProdutoViewModel> customersAux = customers.ToDictionary(x => custIndex++, x => x.Value);
                                              
            if (!String.IsNullOrEmpty(order) && order.Equals("DESC"))
                return customersAux
                .Where(x => x.Key > from && x.Key <= to)
                .OrderByDescending(x => x.Value.GetType().GetProperty(sort).GetValue(x.Value, null))
                .ToDictionary(x => x.Key, x => x.Value);
            else
                return customersAux
                .Where(x => x.Key > from && x.Key <= to)
                .OrderBy(x => x.Value.GetType().GetProperty(sort).GetValue(x.Value, null))
                .ToDictionary(x => x.Key, x => x.Value);

            //return customers
            //    .Where(x => x.Key > from && x.Key <= to)
            //    .OrderBy(x => x.Key)
            //    .ToDictionary(x => x.Key, x => x.Value);
        }


        // GET: Produto
        public ActionResult Index()
        {
            var produtoViewModel = _produtoApp.GetAll();
            return View(produtoViewModel);
        }

        // GET: Produto/Details/5
        public ActionResult Details(Guid id)
        {
            var produtoViewModel = _produtoApp.GetById(id);
            //produtoViewModel.Enderecos = _enderecoApp.ObterPorCliente(id);

            return View(produtoViewModel);
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel produtoViewModel)
        {
            //ViewBag.EstadoId = new SelectList(_estadoApp.GetAll().OrderBy(e => e.Nome), "EstadoId", "Nome", clienteEndereco.EstadoId);
            //ViewBag.CidadeId = new SelectList(_cidadeApp.GetAll().OrderBy(c => c.Nome), "CidadeId", "Nome", clienteEndereco.CidadeId);

            if (ModelState.IsValid)
            {
                var result = _produtoApp.Add(produtoViewModel);

                if (!result.IsValid)
                {
                    foreach (var validationAppError in result.Erros)
                    {
                        ModelState.AddModelError(string.Empty, validationAppError.Message);
                    }
                    return View(produtoViewModel);
                }

                return RedirectToAction("Index");
            }

            return View(produtoViewModel);
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(Guid id)
        {
            var produtoViewModel = _produtoApp.GetById(id);

            return View(produtoViewModel);
        }

        // POST: Produto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                _produtoApp.Update(produtoViewModel);

                return RedirectToAction("Index");
            }

            return View(produtoViewModel);
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(Guid id)
        {
            var produtoViewModel = _produtoApp.GetById(id);

            return View(produtoViewModel);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var model = _produtoApp.GetById(id);
            _produtoApp.Remove(model);

            return RedirectToAction("Index");
        }


        public ActionResult Lista()
        {
            //ViewBag.Message = "Your application description page.";
            //var produtoViewModel = _produtoApp.GetAll();
            //return View(produtoViewModel);

            return RedirectToAction("GetCustomers");

            //return View();
        }

        public ActionResult Detalhes(Guid IdProduto)
        {
            ViewBag.Message = "Your contact page.";

            var customers = _produtoApp.GetById(IdProduto);
            ViewData["Imagens"] = _produtoImagemApp.BuscarImagensPorIdProduto(IdProduto);

            var precos = _produtoPrecoApp.BuscarPrecosPorIdProduto(IdProduto);
            List<SelectListItem> obj = new List<SelectListItem>();
            obj.Add(new SelectListItem { Text = "(Selecione)", Value = "0" });
            foreach (var item in precos)
            {
                obj.Add(new SelectListItem { Text = item.Descricao + " - " + item.ValorUnitario.ToString("C"), Value = item.IdProdutoPreco.ToString() });
            }

            ViewBag.IdProdutoPreco = obj;

            return View(customers);            
            

            //return View();
        }

        [ChildActionOnly]
        public ActionResult _Lancamentos()
        {
            ViewBag.Message = "Your contact page.";

            //Expression<Func<ProdutoViewModel, object>>[] myExpression = { o => o.ProdutoImagensViewModel };
            //var teste = new ProdutoViewModel();

            //Expression<Func<ProdutoViewModel, object>> myExpression = o => teste.ProdutoImagensViewModel;

            var produtoViewModel = _produtoApp.GetAll();
            return PartialView(produtoViewModel);

            //return View();
        }


        public ActionResult _FastView(string idProduto)
        {
            var customers = _produtoApp.GetById(Guid.Parse(idProduto));
            //ViewBag.IsEndOfRecords = (customers.Any()) && ((pageNum.Value * RecordsPerPage) >= customers.Last().Key);
            return PartialView(customers);
        }


        [ChildActionOnly]
        public ActionResult _MaisVendidos()
        {
            ViewBag.Message = "Your contact page.";

            var produtoViewModel = _produtoApp.GetAll();
            produtoViewModel = produtoViewModel.OrderByDescending(t => t.QtdCurtidas).Take(3);

            return PartialView(produtoViewModel);

            //return View();
        }
    }
}
