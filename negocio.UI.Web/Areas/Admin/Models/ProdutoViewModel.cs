using System.ComponentModel.DataAnnotations;

namespace negocio.UI.Web.Areas.Admin.Models
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe uma descrição")]
        public string Descricao { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe um tamanho")]
        public int? Tamanho { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe uma referência")]
        public string Referencia { get; set; }

        [Required(ErrorMessage = "Informe uma marca")]
        public string Marca { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe um modelo")]
        public string Modelo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Selecione uma categoria")]
        public int idProdutoCategoria { get; set; }

        public string DescricaoCategoria { get; set; }
    }
}