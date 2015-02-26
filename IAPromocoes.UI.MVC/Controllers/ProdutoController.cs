using IAPromocoes.Application.Interfaces;
using IAPromocoes.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IAPromocoes.UI.MVC.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoAppService _produtoApp;

        public ProdutoController(IProdutoAppService produtoApp)
        {
            _produtoApp = produtoApp;
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
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}
