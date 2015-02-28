using System.Collections.Generic;

namespace negocio.Dominio
{
    public class VendaDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Placa { get; set; }

        public PagamentoDTO Pagamento { get; set; }
        public ClienteDTO Cliente { get; set; }
        public virtual CarroDTO Carro { get; set; }
        public virtual ICollection<VendaDetalheDTO> VendaDetalhe { get; set; }
    }
}