using AutoMapper;
using negocio.Dominio;
using negocio.UI.Web.Areas.Admin.Models;

namespace negocio.UI.Web.Mappers
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<CarroViewModel, CarroDTO>();
            Mapper.CreateMap<ClienteViewModel, ClienteDTO>();
            Mapper.CreateMap<FornecedorViewModel, FornecedorDTO>();
            Mapper.CreateMap<ProdutoCategoriaViewModel, ProdutoCategoriaDTO>();
            Mapper.CreateMap<ProdutoViewModel, ProdutoDTO>();
        }
    }
}