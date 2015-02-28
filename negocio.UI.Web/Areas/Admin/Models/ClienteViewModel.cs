using System;
using System.ComponentModel.DataAnnotations;

namespace negocio.UI.Web.Areas.Admin.Models
{
    public class ClienteViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe um nome")]
        public string Nome { get; set; }

        public string Sexo { get; set; }

        [Required(ErrorMessage = "Informe uma data de nascimento"), Display(Name = "Data Nascimento"),
         DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Informe o numero do cpf")]
        public string Cpf { get; set; }

        public string Telefone { get; set; }

        [Required(ErrorMessage = "Informe o numero do celular")]
        public string Celular { get; set; }

        public string Email { get; set; }
        public string Endereco { get; set; }
    }
}