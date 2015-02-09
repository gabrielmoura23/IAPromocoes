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
    public class ProdutoService : ServiceBase<Produto>, IProdutoService
    {
        private readonly IProdutoRepository _modelRepository;
        //private readonly IEstudanteReadOnlyRepository _estudanteReadOnlyRepository;
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

        public ProdutoService(
            IProdutoRepository modelRepository)
            : base(modelRepository)
        {
            _modelRepository = modelRepository;
        }

        public override Produto GetById(Guid id)
        {
            return _modelRepository.GetById(id);
        }

        public override IEnumerable<Produto> GetAll()
        {
            return _modelRepository.GetAll();
        }

        public IEnumerable<Produto> BuscarPorDescricao(string descricao)
        {
            return _modelRepository.BuscarPorDescricao(descricao);
        }

        public ValidationResult AdicionarProduto(Produto model)
        {
            var resultadoValidacao = new ValidationResult();

            if (!model.IsValid())
            {
                resultadoValidacao.AdicionarErro(model.ResultadoValidacao);
                return resultadoValidacao;
            }
            
            //Coloca a hora no padrão 01/01/1900
            model.Hora = new DateTime().AddYears(1899).AddHours(model.Hora.Hour).AddMinutes(model.Hora.Minute);

            base.Add(model);

            return resultadoValidacao;
        }

        public ValidationResult CancelarProduto(Produto model, Guid idUsuarioAlteracao)
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


        public void DarBaixaNoProduto(Guid idProduto, int qtd)
        {
            throw new NotImplementedException();
        }

        public void ReajustarPrecoDeUmProduto(Guid idProduto, decimal percentual)
        {
            throw new NotImplementedException();
        }

        public void ReajustarPrecoDosProdutos(decimal percentual)
        {
            throw new NotImplementedException();
        }


        public void RealizarVenda(Guid idPedido, DateTime data, decimal valor, Guid idCliente, int qtdProduto,
                                    Guid idProduto, decimal precoVenda)
        {
            throw new NotImplementedException();
        }
    }
}
