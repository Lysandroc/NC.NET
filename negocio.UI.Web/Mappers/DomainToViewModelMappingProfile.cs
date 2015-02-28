using AutoMapper;
using negocio.Dominio;
using negocio.UI.Web.Areas.Admin.Models;

namespace negocio.UI.Web.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<CarroDTO, CarroViewModel>();
            Mapper.CreateMap<ClienteDTO, ClienteViewModel>();
            Mapper.CreateMap<FornecedorDTO, FornecedorViewModel>();
            Mapper.CreateMap<ProdutoCategoriaDTO, ProdutoCategoriaViewModel>();
            Mapper.CreateMap<ProdutoDTO, ProdutoViewModel>();
        }
    }
}