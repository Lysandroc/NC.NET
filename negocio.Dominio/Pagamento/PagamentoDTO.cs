using System;
using System.Collections.Generic;

namespace negocio.Dominio
{
    public class PagamentoDTO
    {
        public int Id { get; set; }
        public DateTime Data { get; set; } //Dat
        public double ValorTotal { get; set; }
        public string FormaPagamento { get; set; }
        // Cartão ou Avista, se cartão então mostrar Cartão Visa, MasterCard, Hiper...
        public int QuantidadeParcela { get; set; } //Numero total de parcelas
        public string TipoNegocio { get; set; } // Compra ou Venda ou Troca

        public virtual ICollection<PagamentoDetalheDTO> PagamentoDetalhe { get; set; }
        public virtual ICollection<CompraDTO> Compra { get; set; }
        public virtual ICollection<VendaDTO> Venda { get; set; }
    }
}