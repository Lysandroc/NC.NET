using System.Collections.Generic;

namespace negocio.Dominio
{
    public class CompraDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public FornecedorDTO Fornecedor { get; set; }
        public PagamentoDTO Pagamento { get; set; }
        public virtual ICollection<CompraDetalheDTO> CompraDetalhe { get; set; }
    }
}