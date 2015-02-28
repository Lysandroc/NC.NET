using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using negocio.Dominio;
using negocio.Intermediario;
using negocio.UI.Web.Areas.Admin.Models;
using Ninject;

namespace negocio.UI.Web.Areas.Admin.Controllers
{
    public class CarroController : Controller
    {
        #region Propriedades

        private string dadosInvalidos = "Os dados são inválidos!";

        [Inject]
        public ICrud<CarroDTO> intermediario { get; set; }

        #endregion

        #region Ações

        public ActionResult Index()
        {
            IEnumerable<CarroViewModel> carroViewModel =
                Mapper.Map<IEnumerable<CarroDTO>, IEnumerable<CarroViewModel>>(intermediario.ListarTodos());
            return View(carroViewModel);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(CarroViewModel carroViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.status = dadosInvalidos;
                return View(carroViewModel);
            }
            CarroDTO carroDTO = Mapper.Map<CarroViewModel, CarroDTO>(carroViewModel);
            string retorno = intermediario.Criar(carroDTO);
            if (retorno != string.Empty)
            {
                ViewBag.status = "Falha ao criar registro! " + retorno;
                return View(carroViewModel);
            }
            return RedirectToAction("index");
        }


        public ActionResult Edit(long id)
        {
            CarroDTO carroDTO = intermediario.ConsultaId(id);
            if (carroDTO == null)
            {
                ViewBag.status = "O código informado não existe, você foi redirecionado para o cadastrado!";
                return View("create");
            }
            CarroViewModel carroViewModel = Mapper.Map<CarroDTO, CarroViewModel>(carroDTO);
            return View(carroViewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(CarroViewModel carroViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.status = dadosInvalidos;
                return View(carroViewModel);
            }
            CarroDTO carroDTO = Mapper.Map<CarroViewModel, CarroDTO>(carroViewModel);
            string retorno = intermediario.Alterar(carroDTO);
            if (retorno != string.Empty)
            {
                ViewBag.status = "Falha ao alterar registro! " + retorno;
                return View(carroViewModel);
            }
            return RedirectToAction("index");
        }


        public ActionResult Delete(long id)
        {
            CarroDTO carroDTO = intermediario.ConsultaId(id);
            if (carroDTO == null)
            {
                ViewBag.status = "O código informado não existe, você foi redirecionado para o cadastrado!";
                return View("create");
            }
            CarroViewModel carroViewModel = Mapper.Map<CarroDTO, CarroViewModel>(carroDTO);
            return View(carroViewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(CarroViewModel carroViewModel)
        {
            CarroDTO carroDTO = Mapper.Map<CarroViewModel, CarroDTO>(carroViewModel);
            string retorno = intermediario.Deletar(intermediario.ConsultaId(carroDTO.Id));
            if (retorno != string.Empty)
            {
                ViewBag.status = "Falha ao deletar registro! " + retorno;
                return View(carroViewModel);
            }
            return RedirectToAction("index");
        }

        #endregion
    }
}