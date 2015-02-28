namespace negocio.Dominio
{
    public class CarroDTO
    {
        //public CarroDTO()
        //{
        //    this.Venda = new List<VendaDTO>();
        //}

        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }

        //public virtual ICollection<VendaDTO> Venda { get; set; }
    }
}