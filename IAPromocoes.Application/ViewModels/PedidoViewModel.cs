using IAPromocoes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IAPromocoes.Application.ViewModels
{
    public class PedidoViewModel
    {
        public PedidoViewModel()
        {
            this.ItensPedido = new List<ItemPedidoViewModel>();
        }

        [Key]
        public Guid IdPedido { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [DisplayName("ID Cliente")]
        public Guid IdCliente { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [DisplayName("Status do Pedido")]
        public int IdStatusPedido { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [DisplayName("Forma de Pagamento")]
        public int IdFormaDePagamento { get; set; }

        [DisplayName("Outras Informações")]
        public string OutrasInformacoes { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [DisplayName("Data do Pedido")]
        public System.DateTime DataPedido { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm}")]
        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [DisplayName("Hora do Pedido")]
        public System.DateTime HoraPedido { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Data de Pagamento")]
        public System.Nullable<System.DateTime> DtPagamento { get; set; }

        [RegularExpression(@"^(0|\d{0,16}(\.\d{0,2})?)$")]
        [DisplayName("Valor Total")]
        public System.Nullable<Decimal> ValorTotal { get; set; }

        [ScaffoldColumn(false)]
        public System.DateTime DtCadastro { get; set; }

        [ScaffoldColumn(false)]
        public System.Nullable<Guid> IdUsuarioAlteracao { get; set; }

        [ScaffoldColumn(false)]
        public System.Nullable<System.DateTime> DtAlteracao { get; set; }

        public ICollection<ItemPedidoViewModel> ItensPedido { get; set; }
    }
}