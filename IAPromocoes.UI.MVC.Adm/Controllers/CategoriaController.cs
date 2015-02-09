using IAPromocoes.Application.Interfaces;
using IAPromocoes.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IAPromocoes.UI.MVC.Adm.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaAppService _categoriaApp;

        public CategoriaController(
            ICategoriaAppService categoriaApp)
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
            return View(categoriaViewModel);
        }

        // GET: Categoria/Cadastrar
        public ActionResult Cadastrar()
        {
            //ViewBag.FornecedorId = new SelectList(_fornecedorApp.GetAll(), "FornecedorId", "Nome");
            return View();
        }

        // POST: Categoria/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(CategoriaViewModel categoriaViewModel)
        {
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
        public ActionResult Alterar(Guid id)
        {
            var categoriaViewModel = _categoriaApp.GetById(id);
            return View(categoriaViewModel);
        }

        // POST: Categoria/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alterar(CategoriaViewModel categoriaViewModel)
        {
            if (ModelState.IsValid)
            {
                _categoriaApp.Update(categoriaViewModel);
                return RedirectToAction("Index");
            }

            return View(categoriaViewModel);
        }

        // GET: Categoria/Excluir/5
        public ActionResult Excluir(Guid id)
        {
            var categoriaViewModel = _categoriaApp.GetById(id);
            return View(categoriaViewModel);
        }

        // POST: Categoria/Delete/5
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarExcluir(Guid id)
        {
            var categoria = _categoriaApp.GetById(id);
            _categoriaApp.Remove(categoria);

            return RedirectToAction("Index");
        }
    }
}
