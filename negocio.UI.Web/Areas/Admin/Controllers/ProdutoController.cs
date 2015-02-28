using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using negocio.Dominio;
using negocio.Intermediario;
using negocio.UI.Web.Areas.Admin.Models;
using Ninject;

namespace negocio.UI.Web.Areas.Admin.Controllers
{
    public class ProdutoController : Controller
    {
        #region Propriedades

        private string dadosInvalidos = "Os dados são inválidos!";

        [Inject]
        public ICrud<ProdutoDTO> intermediarioProduto { get; set; }

        [Inject]
        public ICrud<ProdutoCategoriaDTO> intermediarioProdutoCategoria { get; set; }

        #endregion

        #region Ações

        public ActionResult Index()
        {
            IEnumerable<ProdutoDTO> produtoDTO = intermediarioProduto.ListarTodos();
            IEnumerable<ProdutoViewModel> produtoViewModel =
                Mapper.Map<IEnumerable<ProdutoDTO>, IEnumerable<ProdutoViewModel>>(produtoDTO);
            return View(produtoViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel produtoViewModel)
        {
            if (!(ModelState.IsValid))
            {
                ViewBag.status = dadosInvalidos;
                return View(produtoViewModel);
            }
            //Converte de ViewModel para ModelDominio
            ProdutoDTO produtoDTO = Mapper.Map<ProdutoViewModel, ProdutoDTO>(produtoViewModel);
            string retorno = intermediarioProduto.Criar(produtoDTO);
            if (retorno != string.Empty)
            {
                ViewBag.status = "Falha ao criar registro " + retorno;
                return View(produtoViewModel);
            }
            return RedirectToAction("index");
        }

        public ActionResult Edit(long id)
        {
            ProdutoDTO produtoDTO = intermediarioProduto.ConsultaId(id);
            if (produtoDTO == null)
            {
                ViewBag.status = "O código informado não existe, você foi redirecionado para a criar um novo produto!";
                return View("create");
            }
            ProdutoViewModel produtoViewModel = Mapper.Map<ProdutoDTO, ProdutoViewModel>(produtoDTO);
            //produtoViewModel.idProdutoCategoria = produtoDTO.ProdutoCategoria.Id;
            produtoViewModel.DescricaoCategoria = produtoDTO.ProdutoCategoria.Categoria;
            return View(produtoViewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel produtoViewModel)
        {
            if (!(ModelState.IsValid))
            {
                ViewBag.status = dadosInvalidos;
                return View(produtoViewModel);
            }
            ProdutoDTO produtoDTO = Mapper.Map<ProdutoViewModel, ProdutoDTO>(produtoViewModel);
            string retorno = intermediarioProduto.Alterar(produtoDTO);
            if (retorno != string.Empty)
            {
                ViewBag.status = "Falha ao alterar registro " + retorno;
                return View(produtoViewModel);
            }
            return RedirectToAction("index");
        }

        public ActionResult Delete(long id)
        {
            ProdutoDTO produtoDTO = intermediarioProduto.ConsultaId(id);
            if (produtoDTO == null)
            {
                ViewBag.status = "O código informado não existe, você foi redirecionado para a criar um novo produto!";
                return View("create");
            }
            ProdutoViewModel produtoViewModel = Mapper.Map<ProdutoDTO, ProdutoViewModel>(produtoDTO);
            produtoViewModel.DescricaoCategoria = produtoDTO.ProdutoCategoria.Categoria;
            return View(produtoViewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(ProdutoViewModel produtoViewModel)
        {
            ProdutoDTO produtoDTO = Mapper.Map<ProdutoViewModel, ProdutoDTO>(produtoViewModel);
            string resultado = intermediarioProduto.Deletar(intermediarioProduto.ConsultaId(produtoDTO.Id));
            if (resultado != string.Empty)
            {
                ViewBag.status = "Falha ao deletar registro " + resultado;
                return View(produtoViewModel);
            }
            return RedirectToAction("index");
        }

        #endregion
    }
}