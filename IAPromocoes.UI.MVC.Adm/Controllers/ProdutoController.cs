using IAPromocoes.Application.Interfaces;
using IAPromocoes.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IAPromocoes.UI.MVC.Adm.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoAppService _produtoApp;
        private readonly ICategoriaAppService _categoriaApp;

        public ProdutoController(
            IProdutoAppService produtoApp,
            ICategoriaAppService categoriaApp)
        {
            _produtoApp = produtoApp;
            _categoriaApp = categoriaApp;
        }

        // GET: Categoria
        public ActionResult Index()
        {
            var ProdutoViewModel = _produtoApp.GetAll();
            return View(ProdutoViewModel);
        }

        // GET: Categoria/Details/5
        public ActionResult Details(Guid id)
        {
            var ProdutoViewModel = _produtoApp.GetById(id);
            return View(ProdutoViewModel);
        }

        // GET: Categoria/Cadastrar
        public ActionResult Cadastrar()
        {
            ViewBag.IdCategoria = new SelectList(_categoriaApp.GetAll(), "IdCategoria", "Descricao");
            return View();
        }

        // POST: Categoria/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(ProdutoViewModel ProdutoViewModel, string Command)
        {
            ViewBag.IdCategoria = new SelectList(_categoriaApp.GetAll(), "IdCategoria", "Descricao", ProdutoViewModel.IdCategoria);
            
            if (ModelState.IsValid)
            {
                var result = _produtoApp.Add(ProdutoViewModel);

                if (!result.IsValid)
                {
                    foreach (var validationAppError in result.Erros)
                    {
                        ModelState.AddModelError(string.Empty, validationAppError.Message);
                    }
                    return View(ProdutoViewModel);
                }

                if (Command == "Submit")
                    return RedirectToAction("Index");
                else
                    return RedirectToAction("Alterar");
            }

            return View(ProdutoViewModel);
        }

        // GET: Categoria/Edit/5
        public ActionResult Alterar(Guid id)
        {
            var ProdutoViewModel = _produtoApp.GetById(id);
            ViewBag.IdCategoria = new SelectList(_categoriaApp.GetAll(), "IdCategoria", "Descricao", ProdutoViewModel.IdCategoria);
            return View(ProdutoViewModel);
        }

        // POST: Categoria/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alterar(ProdutoViewModel ProdutoViewModel, string Command)
        {
            ViewBag.IdCategoria = new SelectList(_categoriaApp.GetAll(), "IdCategoria", "Descricao", ProdutoViewModel.IdCategoria);

            if (ModelState.IsValid)
            {
                _produtoApp.Update(ProdutoViewModel);
                //return RedirectToAction("Index");

                if (Command == "Submit")
                    return RedirectToAction("Index");
                else
                    return RedirectToAction("Alterar");
            }

            return View(ProdutoViewModel);
        }

        // GET: Categoria/Excluir/5
        public ActionResult Excluir(Guid id)
        {
            var ProdutoViewModel = _produtoApp.GetById(id);
            return View(ProdutoViewModel);
        }

        // POST: Categoria/Delete/5
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarExcluir(Guid id)
        {
            var categoria = _produtoApp.GetById(id);
            _produtoApp.Remove(categoria);

            return RedirectToAction("Index");
        }
    }
}
