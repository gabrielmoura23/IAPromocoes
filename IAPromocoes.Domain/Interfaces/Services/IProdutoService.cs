using System.Collections.Generic;
using IAPromocoes.Domain.Entities;
using IAPromocoes.Domain.ValueObjects;
using System;

namespace IAPromocoes.Domain.Interfaces.Services
{
    public interface IProdutoService : IServiceBase<Produto>
    {
        ValidationResult AdicionarProduto(Produto model);
        IEnumerable<Produto> BuscarPorDescricao(string descricao);
        ValidationResult CancelarProduto(Produto model, Guid idUsuarioAlteracao);

        void DarBaixaNoProduto(Guid idProduto, int qtd);
        void ReajustarPrecoDeUmProduto(Guid idProduto, decimal percentual);
        void ReajustarPrecoDosProdutos(decimal percentual);

        void RealizarVenda(Guid idPedido, DateTime data, decimal valor, Guid idCliente,
                            int qtdProduto, Guid idProduto, decimal precoVenda);
    }
}
