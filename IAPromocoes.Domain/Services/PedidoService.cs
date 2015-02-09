using System;
using System.Collections.Generic;
using System.Linq;
using IAPromocoes.Domain.Entities;
using IAPromocoes.Domain.Interfaces.Repository;
//using IAPromocoes.Domain.Interfaces.Repository.ADO;
//using IAPromocoes.Domain.Interfaces.Repository.ReadOnly;
using IAPromocoes.Domain.Interfaces.Services;
using IAPromocoes.Domain.ValueObjects;

namespace IAPromocoes.Domain.Services
{
    public class PedidoService : ServiceBase<Pedido>, IPedidoService
    {
        private readonly IPedidoRepository _modelRepository;
        
        public PedidoService(
            IPedidoRepository modelRepository)
            : base(modelRepository)
        {
            _modelRepository = modelRepository;
        }

        public override Pedido GetById(Guid id)
        {
            return _modelRepository.GetById(id);
        }

        public override IEnumerable<Pedido> GetAll()
        {
            return _modelRepository.GetAll();
        }

        public IEnumerable<Pedido> BuscarPedidosPorIdCliente(Guid idCliente)
        {
            return _modelRepository.BuscarPedidosPorIdCliente(idCliente);
        }

        public ValidationResult AdicionarPedido(Pedido model)
        {
            var resultadoValidacao = new ValidationResult();

            if (!model.IsValid())
            {
                resultadoValidacao.AdicionarErro(model.ResultadoValidacao);
                return resultadoValidacao;
            }

            base.Add(model);

            return resultadoValidacao;
        }

        public ValidationResult CancelarPedido(Pedido model, Guid idUsuarioAlteracao)
        {
            var resultadoValidacao = new ValidationResult();

            if (!model.IsValid())
            {
                resultadoValidacao.AdicionarErro(model.ResultadoValidacao);
                return resultadoValidacao;
            }

            //if (model.Status != "Aberto")
            //{
            //    resultadoValidacao.AdicionarErro(new ValidationError("Status não permitido para cancelamento."));
            //    return resultadoValidacao;
            //}

            //model.Status = "Cancelado";
            //model.DtAlteracao = DateTime.Now;
            //model.DtFechamento = DateTime.Now;
            //model.IdUsuarioAlteracao = IdUsuarioAlteracao;
            
            base.Update(model);

            return resultadoValidacao;
        }


        public ValidationResult FinalizarPedido(Pedido model)
        {
            throw new NotImplementedException();
        }


        public ValidationResult AdicionarProdutoNoCarrinho(Guid idProduto)
        {
            throw new NotImplementedException();
        }

        public ValidationResult RemoverProdutoDoCarrinho(Guid idProduto)
        {
            throw new NotImplementedException();
        }
    }
}
