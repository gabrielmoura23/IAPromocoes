using IAPromocoes.Application.Interfaces;
using IAPromocoes.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IAPromocoes.UI.MVC.Adm.Controllers
{
    public class FormaDePagamentoController : Controller
    {
        private readonly IFormaDePagamentoAppService _formaDePagamentoApp;

        public FormaDePagamentoController(
            IFormaDePagamentoAppService formaDePagamentoApp)
        {
            _formaDePagamentoApp = formaDePagamentoApp;
        }

        // GET: FormaDePagamento
        public ActionResult Index()
        {
            var FormaDePagamentoViewModel = _formaDePagamentoApp.GetAll();
            return View(FormaDePagamentoViewModel);
        }

        // GET: FormaDePagamento/Details/5
        public ActionResult Details(int id)
        {
            var FormaDePagamentoViewModel = _formaDePagamentoApp.GetByIdTipoInteiro(id);
            return View(FormaDePagamentoViewModel);
        }

        // GET: FormaDePagamento/Cadastrar
        public ActionResult Cadastrar()
        {
            //ViewBag.FornecedorId = new SelectList(_fornecedorApp.GetAll(), "FornecedorId", "Nome");
            return View();
        }

        // POST: FormaDePagamento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(FormaDePagamentoViewModel FormaDePagamentoViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = _formaDePagamentoApp.Add(FormaDePagamentoViewModel);

                if (!result.IsValid)
                {
                    foreach (var validationAppError in result.Erros)
                    {
                        ModelState.AddModelError(string.Empty, validationAppError.Message);
                    }
                    return View(FormaDePagamentoViewModel);
                }

                return RedirectToAction("Index");
            }

            return View(FormaDePagamentoViewModel);
        }

        // GET: FormaDePagamento/Edit/5
        public ActionResult Alterar(int id)
        {
            var FormaDePagamentoViewModel = _formaDePagamentoApp.GetByIdTipoInteiro(id);
            return View(FormaDePagamentoViewModel);
        }

        // POST: FormaDePagamento/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alterar(FormaDePagamentoViewModel FormaDePagamentoViewModel)
        {
            if (ModelState.IsValid)
            {
                _formaDePagamentoApp.Update(FormaDePagamentoViewModel);
                return RedirectToAction("Index");
            }

            return View(FormaDePagamentoViewModel);
        }

        // GET: FormaDePagamento/Excluir/5
        public ActionResult Excluir(int id)
        {
            var FormaDePagamentoViewModel = _formaDePagamentoApp.GetByIdTipoInteiro(id);
            return View(FormaDePagamentoViewModel);
        }

        // POST: FormaDePagamento/Delete/5
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarExcluir(int id)
        {
            var FormaDePagamento = _formaDePagamentoApp.GetByIdTipoInteiro(id);
            _formaDePagamentoApp.Remove(FormaDePagamento);

            return RedirectToAction("Index");
        }
    }
}
