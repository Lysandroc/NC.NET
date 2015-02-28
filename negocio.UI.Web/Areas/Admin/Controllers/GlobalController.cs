using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using negocio.Dominio;
using negocio.Intermediario;
using Ninject;

namespace negocio.UI.Web.Areas.Admin.Controllers
{
    public class GlobalController : Controller
    {
        #region Propriedades

        [Inject]
        public ICrud<ProdutoDTO> intermediarioProduto { get; set; }

        [Inject]
        public ICrud<ProdutoCategoriaDTO> intermediarioProdutoCategoria { get; set; }

        #endregion

        #region Ações

        public JsonResult ConsultaProdutoCategoria(string term)
        {
            IEnumerable<ProdutoCategoriaDTO> lista = intermediarioProdutoCategoria.ListarTodos();
            var ChaveValor = new List<KeyValuePair<string, string>>();

            foreach (ProdutoCategoriaDTO item in lista)
            {
                //ChaveValor.Add(new KeyValuePair<string, string>(item.Id.ToString(), item.Categoria + " - " + item.Marca + " - " + item.Modelo));
                ChaveValor.Add(new KeyValuePair<string, string>(item.Id.ToString(), item.Categoria));
            }
            List<KeyValuePair<string, string>> filtro =
                ChaveValor.Where(s => s.Value.ToLower().Contains(term.ToLower())).Select(w => w).ToList();

            return Json(filtro, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ProdutoCategoria()
        {
            return PartialView(intermediarioProdutoCategoria.ListarTodos());

            //<script type="text/javascript">
            //    $(document).ready(function () {
            //        $("#DescricaoCategoria").autocomplete({
            //            source: function (request, response) {
            //                var customer = new Array();
            //                $.ajax({
            //                    url: "@(Url.Action("ConsultaProdutoCategoria", "Global"))",
            //                    type: "POST",
            //                    minLength: 3,
            //                    async: false,
            //                    cache: false,
            //                    dataType: "json",
            //                    data: { term: request.term },
            //                    success: function (data) {
            //                        for (var i = 0; i < data.length ; i++) {
            //                            customer[i] = { label: data[i].Value, Key: data[i].Key };
            //                        }
            //                    }
            //                });
            //                response(customer);
            //            },
            //            messages: {
            //                noResults: "", results: ""
            //            },
            //            select: function (event, ui) {
            //                $("#CodigoCategoria").val(ui.item.Key);
            //            }

            //        });
            //    });

            //</script>
        }

        #endregion
    }
}