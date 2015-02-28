using System.ComponentModel.DataAnnotations;

namespace negocio.UI.Web.Areas.Admin.Models
{
    public class ProdutoCategoriaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Selecione uma categoria")]
        public string Categoria { get; set; }
    }
}