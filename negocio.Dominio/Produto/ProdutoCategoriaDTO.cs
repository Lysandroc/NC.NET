using System.Collections.Generic;

namespace negocio.Dominio
{
    public class ProdutoCategoriaDTO
    {
        public ProdutoCategoriaDTO()
        {
            Produtos = new List<ProdutoDTO>();
        }

        public int Id { get; set; }
        public string Categoria { get; set; }

        public virtual ICollection<ProdutoDTO> Produtos { get; set; }
    }
}