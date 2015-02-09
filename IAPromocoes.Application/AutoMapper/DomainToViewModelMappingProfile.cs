using AutoMapper;
using IAPromocoes.Application.ViewModels;
using IAPromocoes.Domain.Entities;

namespace IAPromocoes.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            //Mapper.CreateMap<Cliente, ClienteViewModel>()
            //    .ForMember(dest => dest.Enderecos, opt => opt.MapFrom(src => src.EnderecoList));

            Mapper.CreateMap<Cliente, ClienteViewModel>();
            Mapper.CreateMap<Categoria, CategoriaViewModel>();

            Mapper.CreateMap<ItemPedido, ItemPedidoViewModel>();
            Mapper.CreateMap<Produto, ProdutoViewModel>();
            Mapper.CreateMap<Pedido, PedidoViewModel>();
            Mapper.CreateMap<ProdutoPreco, ProdutoPrecoViewModel>();
            Mapper.CreateMap<ProdutoImagem, ProdutoImagemViewModel>();

            Mapper.CreateMap<FormaDePagamento, FormaDePagamentoViewModel>();
            Mapper.CreateMap<StatusPedido, StatusPedidoViewModel>();
        }
    }
}