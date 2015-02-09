using IAPromocoes.Application.Interfaces;
using IAPromocoes.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IAPromocoes.UI.MVC.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaAppService _categoriaApp;

        public CategoriaController(ICategoriaAppService categoriaApp)
        {
            _categoriaApp = categoriaApp;
        }

        // GET: Categoria
        public ActionResult Index()
        {
            var categoriaViewModel = _categoriaApp.GetAll();
            return View(categoriaViewModel);
        }

        // GET: Categoria/Details/5
        public ActionResult Details(Guid id)
        {
            var categoriaViewModel = _categoriaApp.GetById(id);
            //categoriaViewModel.Enderecos = _enderecoApp.ObterPorCliente(id);

            return View(categoriaViewModel);
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriaViewModel categoriaViewModel)
        {
            //ViewBag.EstadoId = new SelectList(_estadoApp.GetAll().OrderBy(e => e.Nome), "EstadoId", "Nome", clienteEndereco.EstadoId);
            //ViewBag.CidadeId = new SelectList(_cidadeApp.GetAll().OrderBy(c => c.Nome), "CidadeId", "Nome", clienteEndereco.CidadeId);

            if (ModelState.IsValid)
            {
                var result = _categoriaApp.Add(categoriaViewModel);

                if (!result.IsValid)
                {
                    foreach (var validationAppError in result.Erros)
                    {
                        ModelState.AddModelError(string.Empty, validationAppError.Message);
                    }
                    return View(categoriaViewModel);
                }

                return RedirectToAction("Index");
            }

            return View(categoriaViewModel);
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(Guid id)
        {
            var categoriaViewModel = _categoriaApp.GetById(id);

            return View(categoriaViewModel);
        }

        // POST: Categoria/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoriaViewModel categoriaViewModel)
        {
            if (ModelState.IsValid)
            {
                _categoriaApp.Update(categoriaViewModel);

                return RedirectToAction("Index");
            }

            return View(categoriaViewModel);
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(Guid id)
        {
            var categoriaViewModel = _categoriaApp.GetById(id);

            return View(categoriaViewModel);
        }

        // POST: Categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var model = _categoriaApp.GetById(id);
            _categoriaApp.Remove(model);

            return RedirectToAction("Index");
        }
    }
}
