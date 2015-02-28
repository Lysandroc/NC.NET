using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using negocio.Dominio;
using negocio.Intermediario;
using negocio.UI.Web.Areas.Admin.Models;
using Ninject;

namespace negocio.UI.Web.Areas.Admin.Controllers
{
    public class ProdutoCategoriaController : Controller
    {
        #region Propriedades

        private string dadosInvalidos = "Os dados são inválidos!";

        [Inject]
        public ICrud<ProdutoCategoriaDTO> intermediario { get; set; }

        #endregion

        #region Ações

        public ActionResult Index()
        {
            IEnumerable<ProdutoCategoriaViewModel> produtoCategoriaViewModel =
                Mapper.Map<IEnumerable<ProdutoCategoriaDTO>, IEnumerable<ProdutoCategoriaViewModel>>(
                    intermediario.ListarTodos());
            return View(produtoCategoriaViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoCategoriaViewModel produtoCategoriaViewModel)
        {
            if (!(ModelState.IsValid))
            {
                ViewBag.status = dadosInvalidos;
                return View(produtoCategoriaViewModel);
            }
            ProdutoCategoriaDTO produtoCategoriaDTO =
                Mapper.Map<ProdutoCategoriaViewModel, ProdutoCategoriaDTO>(produtoCategoriaViewModel);
            string retorno = intermediario.Criar(produtoCategoriaDTO);
            if (retorno != string.Empty)
            {
                ViewBag.status = "Falha ao criar registro " + retorno;
                return View(produtoCategoriaViewModel);
            }
            return RedirectToAction("index");
        }

        public ActionResult Delete(long id)
        {
            ProdutoCategoriaDTO produtoCategoriaDTO = intermediario.ConsultaId(id);
            if (produtoCategoriaDTO == null)
            {
                ViewBag.status =
                    "O código informado não existe, você foi redirecionado para a criar uma nova categoria!";
                return View("create");
            }
            ProdutoCategoriaViewModel produtoCategoriaViewModel =
                Mapper.Map<ProdutoCategoriaDTO, ProdutoCategoriaViewModel>(produtoCategoriaDTO);
            return View(produtoCategoriaViewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(ProdutoCategoriaViewModel produtoCategoriaViewModel)
        {
            ProdutoCategoriaDTO produtoCategoriaDTO =
                Mapper.Map<ProdutoCategoriaViewModel, ProdutoCategoriaDTO>(produtoCategoriaViewModel);
            ProdutoCategoriaDTO produtoCategoria = intermediario.ConsultaId(produtoCategoriaDTO.Id);
            string retorno = intermediario.Deletar(produtoCategoria);
            if (retorno != string.Empty)
            {
                ViewBag.status = "Falha ao deletar registro! " + retorno;
                return View(produtoCategoriaDTO);
            }
            return RedirectToAction("index");
        }

        public ActionResult Edit(long id)
        {
            ProdutoCategoriaDTO produtoCategoriaDTO = intermediario.ConsultaId(id);
            if (produtoCategoriaDTO == null)
            {
                ViewBag.status =
                    "O código informado não existe, você foi redirecionado para a criar uma nova categoria!";
                return View("create");
            }
            ProdutoCategoriaViewModel produtoCategoriaViewModel =
                Mapper.Map<ProdutoCategoriaDTO, ProdutoCategoriaViewModel>(produtoCategoriaDTO);
            return View(produtoCategoriaViewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoCategoriaViewModel produtoCategoriaViewModel)
        {
            if (!(ModelState.IsValid))
            {
                ViewBag.status = dadosInvalidos;
                return View(produtoCategoriaViewModel);
            }
            ProdutoCategoriaDTO produtoCategoriaDTO =
                Mapper.Map<ProdutoCategoriaViewModel, ProdutoCategoriaDTO>(produtoCategoriaViewModel);
            string retorno = intermediario.Alterar(produtoCategoriaDTO);
            if (retorno != string.Empty)
            {
                ViewBag.status = "Falha ao alterar registro " + retorno;
                return View(produtoCategoriaViewModel);
            }
            return RedirectToAction("index");
        }

        #endregion
    }
}