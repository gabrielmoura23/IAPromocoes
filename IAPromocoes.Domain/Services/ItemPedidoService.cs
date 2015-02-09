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
    public class ItemPedidoService : ServiceBase<ItemPedido>, IItemPedidoService
    {
        private readonly IItemPedidoRepository _modelRepository;
        
        public ItemPedidoService(
            IItemPedidoRepository modelRepository)
            : base(modelRepository)
        {
            _modelRepository = modelRepository;
        }

        public override ItemPedido GetById(Guid id)
        {
            return _modelRepository.GetById(id);
        }

        public override IEnumerable<ItemPedido> GetAll()
        {
            return _modelRepository.GetAll();
        }

        public IEnumerable<ItemPedido> BuscarItensPorIdPedido(Guid idPedido)
        {
            return _modelRepository.BuscarItensPorIdPedido(idPedido);
        }

        public ValidationResult AdicionarItemPedido(ItemPedido model)
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

        public ValidationResult CancelarItemPedido(ItemPedido model, Guid idUsuarioAlteracao)
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
    }
}
