using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using negocio.Dominio;
using negocio.Intermediario;
using negocio.UI.Web.Areas.Admin.Models;
using Ninject;

namespace negocio.UI.Web.Areas.Admin.Controllers
{
    public class ClienteController : Controller
    {
        #region Propriedades

        private string dadosInvalidos = "Os dados são inválidos!";

        [Inject]
        public ICrud<ClienteDTO> intermediario { get; set; }

        #endregion

        #region Ações

        public ActionResult Index()
        {
            IEnumerable<ClienteViewModel> clienteViewModel =
                Mapper.Map<IEnumerable<ClienteDTO>, IEnumerable<ClienteViewModel>>(intermediario.ListarTodos());
            return View(clienteViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel clienteViewModel)
        {
            if (!(ModelState.IsValid))
            {
                ViewBag.status = dadosInvalidos;
                return View(clienteViewModel);
            }
            ClienteDTO clienteDTO = Mapper.Map<ClienteViewModel, ClienteDTO>(clienteViewModel);
            string retorno = intermediario.Criar(clienteDTO);
            if (retorno != string.Empty)
            {
                ViewBag.status = "Falha ao criar registro! " + retorno;
                return View(clienteViewModel);
            }
            return RedirectToAction("index");
        }

        public ActionResult Edit(long id)
        {
            ClienteDTO clienteDTO = intermediario.ConsultaId(id);
            if (clienteDTO == null)
            {
                ViewBag.status = "O código informado não existe, você foi redirecionado para a criar um novo cliente!";
                return View("create");
            }
            ClienteViewModel clienteViewModel = Mapper.Map<ClienteDTO, ClienteViewModel>(clienteDTO);

            return View(clienteViewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (!(ModelState.IsValid))
            {
                ViewBag.status = dadosInvalidos;
                return View(clienteViewModel);
            }
            ClienteDTO clienteDTO = Mapper.Map<ClienteViewModel, ClienteDTO>(clienteViewModel);
            string retorno = intermediario.Alterar(clienteDTO);
            if ((retorno != string.Empty))
            {
                ViewBag.status = "Falha ao alterar registro! " + retorno;
                return View(clienteViewModel);
            }
            return RedirectToAction("index");
        }

        public ActionResult Delete(long id)
        {
            ClienteDTO clienteDTO = intermediario.ConsultaId(id);
            if (clienteDTO == null)
            {
                ViewBag.status = "O código informado não existe, você foi redirecionado para a criar um novo cliente!";
                return View("create");
            }
            ClienteViewModel clienteViewModel = Mapper.Map<ClienteDTO, ClienteViewModel>(clienteDTO);
            return View(clienteViewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(ClienteViewModel clienteViewModel)
        {
            ClienteDTO clienteDTO = Mapper.Map<ClienteViewModel, ClienteDTO>(clienteViewModel);
            string retorno = intermediario.Deletar(intermediario.ConsultaId(clienteDTO.Id));
            if (retorno != string.Empty)
            {
                ViewBag.status = "Falha ao deletar registro! " + retorno;
                return View(clienteViewModel);
            }
            return RedirectToAction("index");
        }

        #endregion
    }
}