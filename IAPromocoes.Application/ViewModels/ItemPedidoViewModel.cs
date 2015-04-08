using IAPromocoes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IAPromocoes.Application.ViewModels
{
    public class ItemPedidoViewModel
    {
        public ItemPedidoViewModel()
        {
            
        }

        [Key]
        public Guid IdItemPedido { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [DisplayName("ID Pedido")]
        public Guid IdPedido { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [DisplayName("ID Produto")]
        public Guid IdProduto { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [DisplayName("ID Produto Preço")]
        public Guid IdProdutoPreco { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [RegularExpression(@"^(0|\d{0,16}(\.\d{0,2})?)$")]
        [DisplayName("Valor Unitário")]
        public decimal ValorUnitario { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [Range(0, int.MaxValue, ErrorMessage = "Digite apenas números no campo [{0}]")]
        //[RegularExpression("([0-9]+)")]
        [DisplayName("Quantidade")]
        public int QtdProduto { get; set; }

        [ScaffoldColumn(false)]
        public Guid IdUsuarioCadastro { get; set; }

        [ScaffoldColumn(false)]
        public System.DateTime DtCadastro { get; set; }

        [ScaffoldColumn(false)]
        public System.Nullable<Guid> IdUsuarioAlteracao { get; set; }

        [ScaffoldColumn(false)]
        public System.Nullable<System.DateTime> DtAlteracao { get; set; }

        public PedidoViewModel PedidoViewModel { get; set; }
        public ProdutoViewModel ProdutoViewModel { get; set; }
        public ProdutoPrecoViewModel ProdutoPrecoViewModel { get; set; }
    }
}