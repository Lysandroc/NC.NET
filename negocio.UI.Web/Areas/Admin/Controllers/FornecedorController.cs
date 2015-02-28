using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using negocio.Dominio;
using negocio.Intermediario;
using negocio.UI.Web.Areas.Admin.Models;
using Ninject;

namespace negocio.UI.Web.Areas.Admin.Controllers
{
    public class FornecedorController : Controller
    {
        #region Propriedades

        private string dadosInvalidos = "Os dados são inválidos!";

        [Inject]
        public ICrud<FornecedorDTO> intermediarioFornecedor { get; set; }

        #endregion

        #region Ações

        public ActionResult Index()
        {
            IEnumerable<FornecedorDTO> fornecedorDTO = intermediarioFornecedor.ListarTodos();
            IEnumerable<FornecedorViewModel> fornecedorViewModel =
                Mapper.Map<IEnumerable<FornecedorDTO>, IEnumerable<FornecedorViewModel>>(fornecedorDTO);
            return View(fornecedorViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(FornecedorViewModel fornecedorViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.status = dadosInvalidos;
                return View(fornecedorViewModel);
            }
            FornecedorDTO fornecedorDTO = Mapper.Map<FornecedorViewModel, FornecedorDTO>(fornecedorViewModel);
            string retorno = intermediarioFornecedor.Criar(fornecedorDTO);
            if (retorno != string.Empty)
            {
                ViewBag.status = "Falha ao criar registro " + retorno;
                return View(fornecedorViewModel);
            }
            return RedirectToAction("index");
        }

        public ActionResult Edit(long id)
        {
            FornecedorDTO fornecedorDTO = intermediarioFornecedor.ConsultaId(id);
            if (fornecedorDTO == null)
            {
                ViewBag.status =
                    "O código informado não existe, você foi redirecionado para a criar um novo fornecedor!";
                return View("create");
            }
            FornecedorViewModel fornecedorViewModel = Mapper.Map<FornecedorDTO, FornecedorViewModel>(fornecedorDTO);
            return View(fornecedorViewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(FornecedorViewModel fornecedorViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.status = dadosInvalidos;
                return View(fornecedorViewModel);
            }
            FornecedorDTO fornecedorDTO = Mapper.Map<FornecedorViewModel, FornecedorDTO>(fornecedorViewModel);
            string retorno = intermediarioFornecedor.Alterar(fornecedorDTO);
            if (retorno != string.Empty)
            {
                ViewBag.status = "Falha ao alterar registro " + retorno;
                return View(fornecedorViewModel);
            }
            return RedirectToAction("index");
        }

        public ActionResult Delete(long id)
        {
            FornecedorDTO fornecedorDTO = intermediarioFornecedor.ConsultaId(id);
            if (fornecedorDTO == null)
            {
                ViewBag.status =
                    "O código informado não existe, você foi redirecionado para a criar um novo fornecedor!";
                return View("create");
            }
            FornecedorViewModel fornecedorViewModel = Mapper.Map<FornecedorDTO, FornecedorViewModel>(fornecedorDTO);
            return View(fornecedorViewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(FornecedorViewModel fornecedorViewModel)
        {
            FornecedorDTO fornecedorDTO = Mapper.Map<FornecedorViewModel, FornecedorDTO>(fornecedorViewModel);
            string retorno = intermediarioFornecedor.Deletar(intermediarioFornecedor.ConsultaId(fornecedorDTO.Id));
            if (retorno != string.Empty)
            {
                ViewBag.status = "Falha ao excluir registro " + retorno;
                return View(fornecedorViewModel);
            }
            return RedirectToAction("index");
        }

        #endregion
    }
}