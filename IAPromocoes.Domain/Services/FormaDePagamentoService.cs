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
    public class FormaDePagamentoService : ServiceBase<FormaDePagamento>, IFormaDePagamentoService
    {
        private readonly IFormaDePagamentoRepository _modelRepository;
        private readonly IFormaDePagamentoReadOnlyRepository _modelReadOnlyRepository;

        public FormaDePagamentoService(
            IFormaDePagamentoRepository modelRepository,
            IFormaDePagamentoReadOnlyRepository modelReadOnlyRepository)
            : base(modelRepository)
        {
            _modelRepository = modelRepository;
            _modelReadOnlyRepository = modelReadOnlyRepository;
        }

        public override FormaDePagamento GetById(Guid id)
        {
            //return _modelRepository.GetById(id);
            return _modelReadOnlyRepository.GetById(id);
        }

        public override IEnumerable<FormaDePagamento> GetAll()
        {
            //return _modelRepository.GetAll();
            return _modelReadOnlyRepository.GetAll();
        }

        public ValidationResult AdicionarFormaDePagamento(FormaDePagamento model)
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
