using IAPromocoes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IAPromocoes.Application.ViewModels
{
    public class FormaDePagamentoViewModel
    {
        public FormaDePagamentoViewModel()
        {
            this.PedidoViewModel = new List<PedidoViewModel>();
        }

        [Key]
        public int IdFormaDePagamento { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [MaxLength(200, ErrorMessage = "Máximo 200 caracteres para o campo [{0}]")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

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

        public ICollection<PedidoViewModel> PedidoViewModel { get; set; }
    }
}