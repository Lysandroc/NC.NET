namespace negocio.Dominio
{
    public class FornecedorDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }

        //public virtual ICollection<CompraDTO> Compra { get; set; }
    }
}