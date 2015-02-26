using IAPromocoes.Application.Interfaces;
using IAPromocoes.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IAPromocoes.UI.MVC.Adm.Controllers
{
    public class ProdutoPrecoController : Controller
    {
        private readonly IProdutoAppService _produtoApp;
        private readonly IProdutoPrecoAppService _produtoPrecoApp;

        public ProdutoPrecoController(
            IProdutoAppService produtoApp,
            IProdutoPrecoAppService produtoPrecoApp)
        {
            _produtoApp = produtoApp;
            _produtoPrecoApp = produtoPrecoApp;
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
            //ViewBag.Imagens = _produtoImagemApp.GetAll();
            return View(ProdutoViewModel);
        }

        public ActionResult _CadPreco(Guid IdProduto)
        {
            var model = new ProdutoPrecoViewModel();
            model.IdProduto = IdProduto;
            model.FlgAtivo = true;
            return PartialView(model);
        }

        // GET: Categoria/Cadastrar
        public ActionResult Cadastrar()
        {

            //ViewBag.IdCategoria = new SelectList(_categoriaApp.GetAll(), "IdCategoria", "Descricao");
            return View();
        }

        // POST: Categoria/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(ProdutoPrecoViewModel produtoPrecoViewModel)
        {
            //ViewBag.IdCategoria = new SelectList(_categoriaApp.GetAll(), "IdCategoria", "Descricao", ProdutoViewModel.IdCategoria);
            
            if (ModelState.IsValid)
            {
                var result = _produtoPrecoApp.Add(produtoPrecoViewModel);
                
                if (!result.IsValid)
                {
                    foreach (var validationAppError in result.Erros)
                    {
                        ModelState.AddModelError(string.Empty, validationAppError.Message);
                    }
                    return PartialView("_CadPreco", produtoPrecoViewModel);
                    //return PartialView(produtoPrecoViewModel);
                }

                return Json(new { success = true });
            }

            return PartialView("_CadPreco", produtoPrecoViewModel);
            //return PartialView(produtoPrecoViewModel);
            //return Json(new { success = true });
            //return new JsonResult() { Data = true };
            //return Json(new { success = false, mensagem = "Dados incorretos." });
            //return RedirectToAction("Alterar","Produto");
        }


        public ActionResult _AltPreco(Guid? id)
        {
            var model = _produtoPrecoApp.GetById(id.Value);
            return PartialView(model);
        }

        // GET: Categoria/Edit/5
        public ActionResult Alterar(Guid id)
        {
            var modelViewModel = _produtoPrecoApp.GetById(id);
            //ViewBag.IdCategoria = new SelectList(_categoriaApp.GetAll(), "IdCategoria", "Descricao", produtoViewModel.IdCategoria);
            //ViewData["Imagens"] = _produtoImagemApp.BuscarImagensPorIdProduto(id);

            //return View(modelViewModel);
            return PartialView("_AltPreco", modelViewModel);
        }

        // POST: Categoria/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alterar(ProdutoPrecoViewModel produtoPrecoViewModel)
        {
            //ViewBag.IdCategoria = new SelectList(_categoriaApp.GetAll(), "IdCategoria", "Descricao", ProdutoViewModel.IdCategoria);

            if (ModelState.IsValid)
            {
                _produtoPrecoApp.Update(produtoPrecoViewModel);
                //return RedirectToAction("Index");

                return Json(new { success = true });
                //return Json(new { Url = Url.Action("_AltPreco", produtoPrecoViewModel) });
                //return Json(produtoPrecoViewModel, JsonRequestBehavior.AllowGet);
            }

            return PartialView("_AltPreco", produtoPrecoViewModel);
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

        /*Action usada pelo plupload para enviar os arquivos*/
        [HttpPost]
        public ActionResult Upload(int? chunk, string name)
        {
            //Arquivo que o PlUpload envia.
            var fileUpload = Request.Files[0];
            //Local onde vai ficar as fotos enviadas.
            var uploadPath = Server.MapPath("~/Uploads/Produtos");
            //Faz um checagem se o arquivo veio correto.
            chunk = chunk ?? 0;

            var uploadedFilePath = Path.Combine(uploadPath, name);

            //faz o upload literalmetne do arquivo.
            using (var fs = new FileStream(uploadedFilePath, chunk == 0 ? FileMode.Create : FileMode.Append))
            {
                var buffer = new byte[fileUpload.InputStream.Length];
                fileUpload.InputStream.Read(buffer, 0, buffer.Length);
                fs.Write(buffer, 0, buffer.Length);
            }

            //return Content("OK", "text/plain");
            return Json(new { result = "OK", name = name, id = name });
        }

        [HttpPost]
        public ActionResult SalvarPreco(string idProduto, string descricao)
        {
            string retorno = "OK";

            //var produtoImagemViewModel = new ProdutoImagemViewModel();
            //produtoImagemViewModel.IdProdutoImagem = Guid.NewGuid();
            //produtoImagemViewModel.IdProduto = Guid.Parse(idProduto);
            //produtoImagemViewModel.NomeArquivo = descricao;
            //produtoImagemViewModel.Descricao = descricao;
            //produtoImagemViewModel.Ordem = 1;
            //produtoImagemViewModel.CaminhoFisico = "~/Uploads/Produtos/" + descricao;
            //produtoImagemViewModel.FotoPrincipal = true;
            //produtoImagemViewModel.DtCadastro = DateTime.Now;
            //produtoImagemViewModel.IdUsuarioCadastro = Guid.NewGuid();

            //var result = _produtoPrecoApp.Add(produtoImagemViewModel);
            //if (!result.IsValid)
            //{
            //    retorno = "NOK";
            //    foreach (var validationAppError in result.Erros)
            //    {
            //        ModelState.AddModelError(string.Empty, validationAppError.Message);
            //    }
            //}

            return new JsonResult() { Data = retorno };
        }

        [HttpGet]
        public ActionResult GetPrecosProdutos(string idProduto)
        {
            var model = _produtoPrecoApp.BuscarPrecosPorIdProduto(Guid.Parse(idProduto));
            //return new JsonResult() { Data = model };
            return PartialView("_ListaPrecos", model);
        }




        // GET: Categoria/Excluir/5
        public ActionResult ExcluirImagem(Guid id)
        {
            var produtoImagemViewModel = _produtoPrecoApp.GetById(id);
            return View(produtoImagemViewModel);
        }

        // POST: Categoria/Delete/5
        [HttpPost, ActionName("ExcluirImagem")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarExcluirImagem(string id)
        {
            var model = _produtoPrecoApp.GetById(Guid.Parse(id));
            _produtoPrecoApp.Remove(model);

            return new JsonResult() { Data = "OK" };
        }


        [HttpPost]
        public ActionResult ExcluirPreco(string id)
        {
            var model = _produtoPrecoApp.GetById(Guid.Parse(id));
            _produtoPrecoApp.Remove(model);

            return new JsonResult() { Data = "OK" };
        }



    }
}
