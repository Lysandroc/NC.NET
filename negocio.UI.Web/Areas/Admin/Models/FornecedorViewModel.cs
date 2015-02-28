using System.ComponentModel.DataAnnotations;

namespace negocio.UI.Web.Areas.Admin.Models
{
    public class FornecedorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe uma descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe um Cnpj")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "Informe um telefone")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Informe um endereço")]
        public string Endereco { get; set; }
    }
}