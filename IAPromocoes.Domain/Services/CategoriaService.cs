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
    public class CategoriaService : ServiceBase<Categoria>, ICategoriaService
    {
        private readonly ICategoriaRepository _modelRepository;
        private readonly ICategoriaReadOnlyRepository _modelReadOnlyRepository;

        public CategoriaService(
            ICategoriaRepository modelRepository,
            ICategoriaReadOnlyRepository modelReadOnlyRepository)
            : base(modelRepository)
        {
            _modelRepository = modelRepository;
            _modelReadOnlyRepository = modelReadOnlyRepository;
        }

        public override Categoria GetById(Guid id)
        {
            //return _modelRepository.GetById(id);
            return _modelReadOnlyRepository.GetById(id);
        }

        public override IEnumerable<Categoria> GetAll()
        {
            //return _modelRepository.GetAll();
            return _modelReadOnlyRepository.GetAll();
        }

        public ValidationResult AdicionarCategoria(Categoria model)
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
