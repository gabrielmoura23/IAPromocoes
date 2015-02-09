using Ninject.Modules;
using IAPromocoes.Application.Interfaces;
using IAPromocoes.Domain.Interfaces.Repository;
//using IAPromocoes.Domain.Interfaces.Repository.ADO;
using IAPromocoes.Domain.Interfaces.Repository.ReadOnly;
using IAPromocoes.Domain.Interfaces.Services;
using IAPromocoes.Domain.Services;
using IAPromocoes.Infra.Data.Context;
using IAPromocoes.Infra.Data.Interfaces;
using IAPromocoes.Infra.Data.Repositories;
//using IAPromocoes.Infra.Data.Repositories.ADO;
using IAPromocoes.Infra.Data.Repositories.ReadOnly;
using IAPromocoes.Infra.Data.UoW;
using IAPromocoes.Application.Services;

namespace IAPromocoes.Infra.CrossCutting.IoC
{
    public class NinjectModulo : NinjectModule
    {
        public override void Load()
        {
            // app
            Bind<IProdutoAppService>().To<ProdutoAppService>();
            Bind<IPedidoAppService>().To<PedidoAppService>();
            Bind<IItemPedidoAppService>().To<ItemPedidoAppService>();
            Bind<IClienteAppService>().To<ClienteAppService>();
            Bind<ICategoriaAppService>().To<CategoriaAppService>();
            Bind<IStatusPedidoAppService>().To<StatusPedidoAppService>();
            Bind<IFormaDePagamentoAppService>().To<FormaDePagamentoAppService>();
            Bind<IProdutoImagemAppService>().To<ProdutoImagemAppService>();

            // service
            Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            Bind<IProdutoService>().To<ProdutoService>();
            Bind<IPedidoService>().To<PedidoService>();
            Bind<IItemPedidoService>().To<ItemPedidoService>();
            Bind<ICategoriaService>().To<CategoriaService>();
            Bind<IClienteService>().To<ClienteService>();
            Bind<IStatusPedidoService>().To<StatusPedidoService>();
            Bind<IFormaDePagamentoService>().To<FormaDePagamentoService>();
            Bind<IProdutoImagemService>().To<ProdutoImagemService>();

            // data repos
            Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<,>));
            Bind<IProdutoRepository>().To<ProdutoRepository>();
            Bind<IPedidoRepository>().To<PedidoRepository>();
            Bind<IItemPedidoRepository>().To<ItemPedidoRepository>();
            Bind<ICategoriaRepository>().To<CategoriaRepository>();
            Bind<IClienteRepository>().To<ClienteRepository>();
            Bind<IStatusPedidoRepository>().To<StatusPedidoRepository>();
            Bind<IFormaDePagamentoRepository>().To<FormaDePagamentoRepository>();
            Bind<IProdutoImagemRepository>().To<ProdutoImagemRepository>();

            // data repos read only
            Bind<ICategoriaReadOnlyRepository>().To<CategoriaReadOnlyRepository>();
            Bind<IClienteReadOnlyRepository>().To<ClienteReadOnlyRepository>();
            Bind<IStatusPedidoReadOnlyRepository>().To<StatusPedidoReadOnlyRepository>();
            Bind<IFormaDePagamentoReadOnlyRepository>().To<FormaDePagamentoReadOnlyRepository>();
            Bind<IProdutoImagemReadOnlyRepository>().To<ProdutoImagemReadOnlyRepository>();

            // ado repos only
            //Bind<IClienteADORepository>().To<ClienteADORepository>();

            // data configs
            Bind(typeof(IContextManager<>)).To(typeof(ContextManager<>));
            Bind<IDbContext>().To<IAPromocoesContext>();
            Bind(typeof(IUnitOfWork<>)).To(typeof(UnitOfWork<>));

        }
    }
}
