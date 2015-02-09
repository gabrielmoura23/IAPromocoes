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
    public class ClienteService : ServiceBase<Cliente>, IClienteService
    {
        private readonly IClienteRepository _modelRepository;
        private readonly IClienteReadOnlyRepository _modelReadOnlyRepository;
        //private readonly IEstudanteADORepository _estudanteAdoRepository;

        //public EstudanteService(
        //    IEstudanteRepository estudanteRepository, 
        //    IClienteReadOnlyRepository clienteReadOnlyRepository, 
        //    IClienteADORepository clienteAdoRepository)
        //    : base(clienteRepository)
        //{
        //    _estudanteRepository = estudanteRepository;
        //    _estudanteReadOnlyRepository = clienteReadOnlyRepository;
        //    _estudanteAdoRepository = clienteAdoRepository;
        //}

        public ClienteService(
            IClienteRepository modelRepository,
            IClienteReadOnlyRepository modelReadOnlyRepository)
            : base(modelRepository)
        {
            _modelRepository = modelRepository;
            _modelReadOnlyRepository = modelReadOnlyRepository;
        }

        public override Cliente GetById(Guid id)
        {
            return _modelRepository.GetById(id);
        }

        public override IEnumerable<Cliente> GetAll()
        {
            return _modelRepository.GetAll();
        }

        public IEnumerable<Cliente> BuscarPorNome(string nome)
        {
            return _modelRepository.BuscarPorNome(nome);
        }

        public ValidationResult AdicionarCliente(Cliente model)
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
