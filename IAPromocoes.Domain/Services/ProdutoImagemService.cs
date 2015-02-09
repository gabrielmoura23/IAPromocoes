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
    public class ProdutoImagemService : ServiceBase<ProdutoImagem>, IProdutoImagemService
    {
        private readonly IProdutoImagemRepository _modelRepository;
        private readonly IProdutoImagemReadOnlyRepository _modelReadOnlyRepository;

        public ProdutoImagemService(
            IProdutoImagemRepository modelRepository,
            IProdutoImagemReadOnlyRepository modelReadOnlyRepository)
            : base(modelRepository)
        {
            _modelRepository = modelRepository;
            _modelReadOnlyRepository = modelReadOnlyRepository;
        }

        public override ProdutoImagem GetById(Guid id)
        {
            //return _modelRepository.GetById(id);
            return _modelReadOnlyRepository.GetById(id);
        }

        public override IEnumerable<ProdutoImagem> GetAll()
        {
            //return _modelRepository.GetAll();
            return _modelReadOnlyRepository.GetAll();
        }

        public ValidationResult AdicionarProdutoImagem(ProdutoImagem model)
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
