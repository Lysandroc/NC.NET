using System;

namespace negocio.Dominio
{
    public class PagamentoDetalheDTO
    {
        public int id { get; set; }
        public bool Pago { get; set; }
        public double Valor { get; set; }
        public int NumeroParcela { get; set; }
        public DateTime DataPagamento { get; set; }

        public PagamentoDTO Pagamento { get; set; }
    }
}