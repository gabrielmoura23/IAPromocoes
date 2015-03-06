using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IAPromocoes.Application.ViewModels
{
    public class ProdutoViewModel
    {
        public ProdutoViewModel()
        {
            this.ItensPedidoViewModel = new List<ItemPedidoViewModel>();
            this.ProdutoPrecosViewModel = new List<ProdutoPrecoViewModel>();
            this.ProdutoImagensViewModel = new List<ProdutoImagemViewModel>();
        }

        [Key]
        public Guid IdProduto { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [DisplayName("ID Categoria")]
        public Guid IdCategoria { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [MaxLength(200, ErrorMessage = "Máximo 200 caracteres para o campo [{0}]")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres para o campo [{0}]")]
        [DisplayName("Sub Descrição")]
        public string SubDescricao { get; set; }

        [MaxLength(255, ErrorMessage = "Máximo 255 caracteres para o campo [{0}]")]
        [DisplayName("Link da Imagem")]
        public string LinkImagem { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [MaxLength(200, ErrorMessage = "Máximo 200 caracteres para o campo [{0}]")]
        [DisplayName("Descrição")]
        public string Atracao { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres para o campo [{0}]")]
        [DisplayName("Dia")]
        public string Dia { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [DisplayName("Data")]
        public System.DateTime Data { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [DisplayName("Hora")]
        [DataType(DataType.Time)]
        public System.DateTime Hora { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [MaxLength(200, ErrorMessage = "Máximo 200 caracteres para o campo [{0}]")]
        [DisplayName("Data em formato Texto")]
        public string DataTexto { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [MaxLength(200, ErrorMessage = "Máximo 200 caracteres para o campo [{0}]")]
        [DisplayName("Local")]
        public string Local { get; set; }

        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres para o campo [{0}]")]
        [DisplayName("Preço")]
        public string PrecoTexto { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [DisplayName("Instruções Outros")]
        public string InstrucoesOutros { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [DisplayName("Data Disponibilidade Inicial")]
        public System.DateTime DataDisponibilidadeInicial { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [DisplayName("Data Disponibilidade Final")]
        public System.DateTime DataDisponibilidadeFinal { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [DisplayName("Ativo?")]
        public bool FlgAtivo { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [DisplayName("Em Promoção?")]
        public bool FlgEmPromocao { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Digite apenas números no campo [{0}]")]
        [DisplayName("Quantidade de Curtidas")]
        public System.Nullable<int> QtdCurtidas { get; set; }

        [ScaffoldColumn(false)]
        public Guid IdUsuarioCadastro { get; set; }

        [ScaffoldColumn(false)]
        public System.DateTime DtCadastro { get; set; }

        [ScaffoldColumn(false)]
        public System.Nullable<Guid> IdUsuarioAlteracao { get; set; }

        [ScaffoldColumn(false)]
        public System.Nullable<System.DateTime> DtAlteracao { get; set; }

        public CategoriaViewModel CategoriaViewModel { get; set; }
        public ICollection<ItemPedidoViewModel> ItensPedidoViewModel { get; set; }
        public ICollection<ProdutoPrecoViewModel> ProdutoPrecosViewModel { get; set; }
        public ICollection<ProdutoImagemViewModel> ProdutoImagensViewModel { get; set; }



        [Required(ErrorMessage = "Digite o valor")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Valor inválido")]
        public decimal Preco { get; set; }
    }
}