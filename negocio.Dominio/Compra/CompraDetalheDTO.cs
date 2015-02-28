namespace negocio.Dominio
{
    public class CompraDetalheDTO
    {
        public int Id { get; set; }
        public double ValorItem { get; set; }
        public long Quantidade { get; set; }

        public CompraDTO Compra { get; set; }
        public ProdutoDTO Produto { get; set; }
    }
}