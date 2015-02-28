using System.ComponentModel.DataAnnotations;

namespace negocio.UI.Web.Areas.Admin.Models
{
    public class CarroViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe a marca do veiculo")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Informe o modelo do veiculo")]
        public string Modelo { get; set; }
    }
}