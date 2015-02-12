using IAPromocoes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IAPromocoes.Application.ViewModels
{
    public class ProdutoImagemViewModel
    {
        public ProdutoImagemViewModel()
        {
 
        }

        [Key]
        public Guid IdProdutoImagem { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [DisplayName("ID Produto")]
        public Guid IdProduto { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [MaxLength(200, ErrorMessage = "Máximo 200 caracteres para o campo [{0}]")]
        [DisplayName("Nome do Arquivo")]
        public string NomeArquivo { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [MaxLength(200, ErrorMessage = "Máximo 200 caracteres para o campo [{0}]")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [DisplayName("Caminho Físico")]
        public string CaminhoFisico { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [Range(0, int.MaxValue, ErrorMessage = "Digite apenas números no campo [{0}]")]
        [DisplayName("Ordem")]
        public int Ordem { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [DisplayName("Foto Principal?")]
        public bool FotoPrincipal { get; set; }

        [ScaffoldColumn(false)]
        public Guid IdUsuarioCadastro { get; set; }

        [ScaffoldColumn(false)]
        public System.DateTime DtCadastro { get; set; }

        [ScaffoldColumn(false)]
        public System.Nullable<Guid> IdUsuarioAlteracao { get; set; }

        [ScaffoldColumn(false)]
        public System.Nullable<System.DateTime> DtAlteracao { get; set; }

        public ProdutoViewModel ProdutoViewModel { get; set; }
    }
}