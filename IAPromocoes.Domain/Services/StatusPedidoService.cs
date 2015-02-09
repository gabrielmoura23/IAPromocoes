using System;
using System.Collections.Generic;
using System.Linq;
using IAPromocoes.Domain.Entities;
using IAPromocoes.Domain.Interfaces.Repository;
//using IAPromocoes.Domain.Interfaces.Repository.ADO;
using IAPromocoes.Domain.Interfaces.Repository.ReadOnly;
using IAPromocoes.Domain.Interfaces.Services;
using IAPromocoes.Domain.ValueObjects;

namespace IAPromocoes.Domain.Services
{
    public class StatusPedidoService : ServiceBase<StatusPedido>, IStatusPedidoService
    {
        private readonly IStatusPedidoRepository _modelRepository;
        private readonly IStatusPedidoReadOnlyRepository _modelReadOnlyRepository;

        public StatusPedidoService(
            IStatusPedidoRepository modelRepository,
            IStatusPedidoReadOnlyRepository modelReadOnlyRepository)
            : base(modelRepository)
        {
            _modelRepository = modelRepository;
            _modelReadOnlyRepository = modelReadOnlyRepository;
        }

        public override StatusPedido GetById(Guid id)
        {
            //return _modelRepository.GetById(id);
            return _modelReadOnlyRepository.GetById(id);
        }

        public override IEnumerable<StatusPedido> GetAll()
        {
            //return _modelRepository.GetAll();
            return _modelReadOnlyRepository.GetAll();
        }

        public ValidationResult AdicionarStatusPedido(StatusPedido model)
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

    }
}
