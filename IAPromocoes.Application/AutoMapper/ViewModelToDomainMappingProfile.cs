using AutoMapper;
using IAPromocoes.Application.ViewModels;
using IAPromocoes.Domain.Entities;

namespace IAPromocoes.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ClienteViewModel, Cliente>();
            Mapper.CreateMap<CategoriaViewModel, Categoria>();

            Mapper.CreateMap<ItemPedidoViewModel, ItemPedido>();
            Mapper.CreateMap<ProdutoViewModel, Produto>();
            Mapper.CreateMap<PedidoViewModel, Pedido>();
            Mapper.CreateMap<ProdutoPrecoViewModel, ProdutoPreco>();
            Mapper.CreateMap<ProdutoImagemViewModel, ProdutoImagem>();

            Mapper.CreateMap<FormaDePagamentoViewModel, FormaDePagamento>();
            Mapper.CreateMap<StatusPedidoViewModel, StatusPedido>();
        }
    }
}