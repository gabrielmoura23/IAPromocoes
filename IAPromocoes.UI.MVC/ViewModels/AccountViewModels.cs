using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace IAPromocoes.UI.MVC.ViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Sobrenome")]
        public string LastName { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }

        [HiddenInput]
        public string UserId { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Código")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Lembrar este Browser?")]
        public bool RememberBrowser { get; set; }

        [HiddenInput]
        public string UserId { get; set; }

    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "E-mail")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Lembrar login?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Campo 'E-mail' é obrigatório.")]
        [EmailAddress(ErrorMessage = "Campo 'E-mail' é inválido.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo 'Nome' é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo 'Senha' é obrigatório.")]
        [StringLength(100, ErrorMessage = "A {0} precisa ter no mínimo {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a Senha")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Senha não confere.")]
        public string ConfirmPassword { get; set; }

        //[Required(ErrorMessage = "Preencha o campo [{0}]")]
        //[MaxLength(255, ErrorMessage = "Máximo 255 caracteres para o campo [{0}]")]
        //[Display("Nome")]
        //public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [MaxLength(255, ErrorMessage = "Máximo 255 caracteres para o campo [{0}]")]
        [Display(Name = "Sobrenome")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [MaxLength(15, ErrorMessage = "Máximo 15 caracteres para o campo [{0}]")]
        [RegularExpression("([0-9]*)", ErrorMessage = "Digite apenas números")]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [MaxLength(1, ErrorMessage = "Máximo 1 caracteres para o campo [{0}]")]
        [Display(Name = "Sexo")]
        public string Sexo { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        public System.DateTime DtNascimento { get; set; }

        //[Required(ErrorMessage = "Preencha o campo [{0}]")]
        //[MaxLength(255, ErrorMessage = "Máximo 255 caracteres para o campo [{0}]")]
        //[EmailAddress(ErrorMessage = "E-mail não é válido")]
        //[Display(Name = "E-mail")]
        //public string Email { get; set; }

        [MaxLength(2, ErrorMessage = "Máximo 2 caracteres para o campo [{0}]")]
        [RegularExpression("([0-9]*)", ErrorMessage = "Digite apenas números")]
        [Display(Name = "DDD Telefone")]
        public string DddTelefone { get; set; }

        [MaxLength(15, ErrorMessage = "Máximo 15 caracteres para o campo [{0}]")]
        [RegularExpression("([0-9]*)", ErrorMessage = "Digite apenas números")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [MaxLength(2, ErrorMessage = "Máximo 2 caracteres para o campo [{0}]")]
        [RegularExpression("([0-9]*)", ErrorMessage = "Digite apenas números")]
        [Display(Name = "DDD Celular")]
        public string DddCelular { get; set; }

        [MaxLength(15, ErrorMessage = "Máximo 15 caracteres para o campo [{0}]")]
        [RegularExpression("([0-9]*)", ErrorMessage = "Digite apenas números")]
        [Display(Name = "Celular")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [Display(Name = "Termos?")]
        public bool FlgAceitoTermos { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [Display(Name = "Newsletter?")]
        public bool FlgAceitoNewsletter { get; set; }

        [HiddenInput]
        public bool FlgAtivo { get; set; }

        [HiddenInput]
        public System.DateTime DtCadastro { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Senha")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "As senhas não se coincidem.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}