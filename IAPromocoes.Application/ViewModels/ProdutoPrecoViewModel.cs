using IAPromocoes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IAPromocoes.Application.ViewModels
{
    public class ProdutoPrecoViewModel
    {
        public ProdutoPrecoViewModel()
        {
            this.ItensPedidoViewModel = new List<ItemPedidoViewModel>();
        }

        [Key]
        public Guid IdProdutoPreco { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [DisplayName("ID Produto")]
        public Guid IdProduto { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [MaxLength(200, ErrorMessage = "Máximo 200 caracteres para o campo [{0}]")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        //[RegularExpression(@"^(0|\d{0,16}(\.\d{0,2})?)$")]
        //[RegularExpression(@"[0-9]*(\.[0-9]{3})*,([0-9]{2})?")]
        [DisplayName("Valor Unitário")]
        public decimal ValorUnitario { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [MaxLength(255, ErrorMessage = "Máximo 255 caracteres para o campo [{0}]")]
        [DisplayName("Instruções Valor")]
        public string InstrucoesValor { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [DisplayName("Instruções Outros")]
        public string InstrucoesOutros { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [Range(0, int.MaxValue, ErrorMessage = "Digite apenas números no campo [{0}]")]
        [DisplayName("Quantidade")]
        public int QtdProduto { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [DisplayName("Ativo?")]
        public bool FlgAtivo { get; set; }

        [ScaffoldColumn(false)]
        public Guid IdUsuarioCadastro { get; set; }

        [ScaffoldColumn(false)]
        public System.DateTime DtCadastro { get; set; }

        [ScaffoldColumn(false)]
        public System.Nullable<Guid> IdUsuarioAlteracao { get; set; }

        [ScaffoldColumn(false)]
        public System.Nullable<System.DateTime> DtAlteracao { get; set; }

        public ProdutoViewModel ProdutoViewModel { get; set; }
        public virtual ICollection<ItemPedidoViewModel> ItensPedidoViewModel { get; set; }
    }
}