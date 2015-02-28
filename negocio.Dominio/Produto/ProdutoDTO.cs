namespace negocio.Dominio
{
    public class ProdutoDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Tamanho { get; set; }
        public string Referencia { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int idProdutoCategoria { get; set; }
        public virtual ProdutoCategoriaDTO ProdutoCategoria { get; set; }

        //public virtual ICollection<VendaDetalheDTO> VendaDetalhe { get; set; }
        //public virtual ICollection<CompraDetalheDTO> CompraDetalhe { get; set; }
    }
}