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
    public class ProdutoPrecoService : ServiceBase<ProdutoPreco>, IProdutoPrecoService
    {
        private readonly IProdutoPrecoRepository _modelRepository;
        private readonly IProdutoPrecoReadOnlyRepository _modelReadOnlyRepository;

        public ProdutoPrecoService(
            IProdutoPrecoRepository modelRepository,
            IProdutoPrecoReadOnlyRepository modelReadOnlyRepository)
            : base(modelRepository)
        {
            _modelRepository = modelRepository;
            _modelReadOnlyRepository = modelReadOnlyRepository;
        }

        public override ProdutoPreco GetById(Guid id)
        {
            //return _modelRepository.GetById(id);
            return _modelReadOnlyRepository.GetById(id);
        }

        public override IEnumerable<ProdutoPreco> GetAll()
        {
            //return _modelRepository.GetAll();
            return _modelReadOnlyRepository.GetAll();
        }

        public ValidationResult AdicionarProdutoPreco(ProdutoPreco model)
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

        public IEnumerable<ProdutoPreco> BuscarPrecosPorIdProduto(Guid idProduto)
        {
            return _modelRepository.BuscarPrecosPorIdProduto(idProduto);
        }
    }
}
