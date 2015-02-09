using IAPromocoes.Application.Interfaces;
using IAPromocoes.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IAPromocoes.UI.MVC.Adm.Controllers
{
    public class StatusPedidoController : Controller
    {
        private readonly IStatusPedidoAppService _statusPedidoApp;

        public StatusPedidoController(
            IStatusPedidoAppService statusPedidoApp)
        {
            _statusPedidoApp = statusPedidoApp;
        }

        // GET: StatusPedido
        public ActionResult Index()
        {
            var statusPedidoViewModel = _statusPedidoApp.GetAll();
            return View(statusPedidoViewModel);
        }

        // GET: StatusPedido/Details/5
        public ActionResult Details(int id)
        {
            var statusPedidoViewModel = _statusPedidoApp.GetByIdTipoInteiro(id);
            return View(statusPedidoViewModel);
        }

        // GET: StatusPedido/Cadastrar
        public ActionResult Cadastrar()
        {
            //ViewBag.FornecedorId = new SelectList(_fornecedorApp.GetAll(), "FornecedorId", "Nome");
            return View();
        }

        // POST: StatusPedido/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(StatusPedidoViewModel statusPedidoViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = _statusPedidoApp.Add(statusPedidoViewModel);

                if (!result.IsValid)
                {
                    foreach (var validationAppError in result.Erros)
                    {
                        ModelState.AddModelError(string.Empty, validationAppError.Message);
                    }
                    return View(statusPedidoViewModel);
                }

                return RedirectToAction("Index");
            }

            return View(statusPedidoViewModel);
        }

        // GET: StatusPedido/Edit/5
        public ActionResult Alterar(int id)
        {
            var statusPedidoViewModel = _statusPedidoApp.GetByIdTipoInteiro(id);
            return View(statusPedidoViewModel);
        }

        // POST: StatusPedido/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alterar(StatusPedidoViewModel statusPedidoViewModel)
        {
            if (ModelState.IsValid)
            {
                _statusPedidoApp.Update(statusPedidoViewModel);
                return RedirectToAction("Index");
            }

            return View(statusPedidoViewModel);
        }

        // GET: StatusPedido/Excluir/5
        public ActionResult Excluir(int id)
        {
            var statusPedidoViewModel = _statusPedidoApp.GetByIdTipoInteiro(id);
            return View(statusPedidoViewModel);
        }

        // POST: StatusPedido/Delete/5
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarExcluir(int id)
        {
            var StatusPedido = _statusPedidoApp.GetByIdTipoInteiro(id);
            _statusPedidoApp.Remove(StatusPedido);

            return RedirectToAction("Index");
        }
    }
}
