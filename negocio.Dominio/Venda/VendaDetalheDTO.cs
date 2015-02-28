namespace negocio.Dominio
{
    public class VendaDetalheDTO
    {
        public int Id { get; set; }
        public double Valor { get; set; }
        public long Quantidade { get; set; }

        public VendaDTO Venda { get; set; }
        public ProdutoDTO Produto { get; set; }
    }
}