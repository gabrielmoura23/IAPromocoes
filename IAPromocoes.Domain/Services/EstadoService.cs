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
    public class EstadoService : ServiceBase<Estado>, IEstadoService
    {
        //private readonly IEstadoRepository _modelRepository;
        private readonly IEstadoReadOnlyRepository _modelReadOnlyRepository;

        public EstadoService(
            IEstadoReadOnlyRepository modelReadOnlyRepository)
            : base(null)
        {
            //_modelRepository = modelRepository;
            _modelReadOnlyRepository = modelReadOnlyRepository;
        }

        public override IEnumerable<Estado> GetAll()
        {
            //return _modelRepository.GetAll();
            return _modelReadOnlyRepository.GetAll();
        }


        public Estado GetByIdTipoString(string id)
        {
            return _modelReadOnlyRepository.GetByIdTipoString(id);
        }
    }
}
