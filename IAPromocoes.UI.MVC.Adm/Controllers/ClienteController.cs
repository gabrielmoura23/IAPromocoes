
using IAPromocoes.Application.Interfaces;
using IAPromocoes.Application.ViewModels;
using IAPromocoes.Infra.CrossCutting.Identity;
using IAPromocoes.Infra.CrossCutting.Identity.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace IAPromocoes.UI.MVC.Adm.Controllers
{
    public class ClienteController : Controller
    {
        public ClienteController()
        {
        }

        public ClienteController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        // Definindo a instancia UserManager presente no request.
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // Definindo a instancia SignInManager presente no request.
        private ApplicationSignInManager _signInManager;
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        //private readonly IClienteAppService _clienteApp;

        //public ClienteController(
        //    IClienteAppService clienteApp)
        //{
        //    _clienteApp = clienteApp;
        //}

        // GET: Categoria
        public ActionResult Index()
        {
            var allUsers = UserManager.Users.ToList();

            return View(allUsers);
            //var clienteViewModel = _clienteApp.GetAll();
            //return View(clienteViewModel);
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
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

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cliente/Edit/5
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

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cliente/Delete/5
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


        // GET: Cliente/Cadastrar
        public ActionResult Cadastrar()
        {
            //ViewBag.FornecedorId = new SelectList(_fornecedorApp.GetAll(), "FornecedorId", "Nome");
            var lista = IAPromocoes.Application.Util.CamposLista.GetListaSexo();
            ViewBag.SexoList = new SelectList(lista, "Id", "Text");

            return View();
        }

        // GET: Cliente/Edit/5
        public ActionResult Alterar(string id)
        {
            var lista = IAPromocoes.Application.Util.CamposLista.GetListaSexo();
            ViewBag.SexoList = new SelectList(lista, "Id", "Text");

            var user = UserManager.FindById(id);
            //var ClienteViewModel = _clienteApp.GetById(id);
            return View(user);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alterar(ApplicationUser modelViewModel)
        {
            var lista = IAPromocoes.Application.Util.CamposLista.GetListaSexo();
            ViewBag.SexoList = new SelectList(lista, "Id", "Text");

            if (ModelState.IsValid)
            {
                ApplicationUser u = UserManager.FindById(modelViewModel.Id);
                //u.UserName = modelViewModel.Email;
                //u.Email = modelViewModel.Email;
                u.Sobrenome = modelViewModel.Sobrenome; // Extra Property
                u.DddTelefone = modelViewModel.DddTelefone; // Extra Property
                u.Telefone = modelViewModel.Telefone; // Extra Property
                u.DddCelular = modelViewModel.DddCelular; // Extra Property
                u.Celular = modelViewModel.Celular; // Extra Property
                u.FlgAceitoNewsletter = modelViewModel.FlgAceitoNewsletter; // Extra Property
                u.FlgAceitoTermos = modelViewModel.FlgAceitoTermos; // Extra Property
                u.FlgAtivo = modelViewModel.FlgAtivo; // Extra Property

                var result = UserManager.Update(u);
                if (result.Succeeded)
                {
                    //_clienteApp.Update(ClienteViewModel);
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var validationAppError in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, validationAppError);
                    }
                    return View(modelViewModel);
                }
            }

            return View(modelViewModel);
        }

        //// POST: Cliente/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Cadastrar(ClienteViewModel ClienteViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = _clienteApp.Add(ClienteViewModel);

        //        if (!result.IsValid)
        //        {
        //            foreach (var validationAppError in result.Erros)
        //            {
        //                ModelState.AddModelError(string.Empty, validationAppError.Message);
        //            }
        //            return View(ClienteViewModel);
        //        }

        //        return RedirectToAction("Index");
        //    }

        //    return View(ClienteViewModel);
        //}

        //// GET: Cliente/Edit/5
        //public ActionResult Alterar(Guid id)
        //{
        //    var ClienteViewModel = _clienteApp.GetById(id);
        //    return View(ClienteViewModel);
        //}

        //// POST: Cliente/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Alterar(ClienteViewModel ClienteViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _clienteApp.Update(ClienteViewModel);
        //        return RedirectToAction("Index");
        //    }

        //    return View(ClienteViewModel);
        //}

        //// GET: Cliente/Excluir/5
        //public ActionResult Excluir(Guid id)
        //{
        //    var ClienteViewModel = _clienteApp.GetById(id);
        //    return View(ClienteViewModel);
        //}

        //// POST: Cliente/Delete/5
        //[HttpPost, ActionName("Excluir")]
        //[ValidateAntiForgeryToken]
        //public ActionResult ConfirmarExcluir(Guid id)
        //{
        //    var Cliente = _clienteApp.GetById(id);
        //    _clienteApp.Remove(Cliente);

        //    return RedirectToAction("Index");
        //}

    }
}
