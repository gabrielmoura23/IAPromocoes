using IAPromocoes.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IAPromocoes.UI.MVC.Models
{
    public class Carrinho
    {

        private readonly List<ItemCarrinho> _itemCarrinho = new List<ItemCarrinho>();

        //Adicionar

        public void AdicionarItem(ProdutoViewModel produto, int quantidade)
        {
            ItemCarrinho item = _itemCarrinho.FirstOrDefault(p => p.Produto.IdProduto == produto.IdProduto);

            if (item == null)
            {
                _itemCarrinho.Add(new ItemCarrinho
                {
                    Produto = produto,
                    Quantidade = quantidade
                });
            }
            else
            {
                item.Quantidade += quantidade;
            }


        }

        public void AtualizarItem(ProdutoViewModel produto, int quantidade)
        {
            ItemCarrinho item = _itemCarrinho.FirstOrDefault(p => p.Produto.IdProduto == produto.IdProduto);

            if (item == null)
            {
                _itemCarrinho.Add(new ItemCarrinho
                {
                    Produto = produto,
                    Quantidade = quantidade
                });
            }
            else
            {
                item.Quantidade = quantidade;
            }


        }

        // Remover item

        public void RemevorItem(ProdutoViewModel produto)
        {
            _itemCarrinho.RemoveAll(l => l.Produto.IdProduto == produto.IdProduto);
        }



        //Obter o valor total

        public decimal ObterValorTotal()
        {
            return _itemCarrinho.Sum(e => e.Produto.Preco * e.Quantidade);
        }

        //Limpar carrinho

        public void LimparCarrinho()
        {
            _itemCarrinho.Clear();
        }

        //Itens carrinho

        public IEnumerable<ItemCarrinho> ItensCarrinho
        {
            get { return _itemCarrinho; }
        }


    }


    public class ItemCarrinho
    {
        public ProdutoViewModel Produto { get; set; }

        public int Quantidade { get; set; }
    }
}