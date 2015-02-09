using IAPromocoes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IAPromocoes.Application.ViewModels
{
    public class ClienteViewModel
    {
        public ClienteViewModel()
        {
            this.PedidoViewModel = new List<PedidoViewModel>();
        }

        [Key]
        public Guid IdCliente { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [MaxLength(255, ErrorMessage = "Máximo 255 caracteres para o campo [{0}]")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [MaxLength(255, ErrorMessage = "Máximo 255 caracteres para o campo [{0}]")]
        [DisplayName("Sobrenome")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [MaxLength(15, ErrorMessage = "Máximo 15 caracteres para o campo [{0}]")]
        [DisplayName("CPF")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [MaxLength(1, ErrorMessage = "Máximo 1 caracteres para o campo [{0}]")]
        [DisplayName("Sexo")]
        public string Sexo { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [DisplayName("Data de Nascimento")]
        public System.DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [MaxLength(255, ErrorMessage = "Máximo 255 caracteres para o campo [{0}]")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [MaxLength(2, ErrorMessage = "Máximo 2 caracteres para o campo [{0}]")]
        [DisplayName("DDD Telefone")]
        public string DddTelefone { get; set; }

        [MaxLength(15, ErrorMessage = "Máximo 15 caracteres para o campo [{0}]")]
        [DisplayName("Telefone")]
        public string Telefone { get; set; }

        [MaxLength(2, ErrorMessage = "Máximo 2 caracteres para o campo [{0}]")]
        [DisplayName("DDD Celular")]
        public string DddCelular { get; set; }

        [MaxLength(15, ErrorMessage = "Máximo 15 caracteres para o campo [{0}]")]
        [DisplayName("Celular")]
        public string Celular { get; set; }

        [MaxLength(255, ErrorMessage = "Máximo 255 caracteres para o campo [{0}]")]
        [DisplayName("Link Imagem")]
        public string LinkImagem { get; set; }

        [MaxLength(255, ErrorMessage = "Máximo 255 caracteres para o campo [{0}]")]
        [DisplayName("Link Facebook")]
        public string LinkFacebook { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres para o campo [{0}]")]
        [DisplayName("Senha")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [DisplayName("Termos?")]
        public bool FlgAceitoTermos { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [DisplayName("Newsletter?")]
        public bool FlgAceitoNewsletter { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [DisplayName("Ativo?")]
        public bool FlgAtivo { get; set; }

        [ScaffoldColumn(false)]
        public System.DateTime DtCadastro { get; set; }

        [ScaffoldColumn(false)]
        public System.Nullable<Guid> IdUsuarioAlteracao { get; set; }

        [ScaffoldColumn(false)]
        public System.Nullable<System.DateTime> DtAlteracao { get; set; }

        public ICollection<PedidoViewModel> PedidoViewModel { get; set; }
    }
}