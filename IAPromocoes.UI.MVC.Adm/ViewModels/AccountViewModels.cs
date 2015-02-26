using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace IAPromocoes.UI.MVC.Adm.ViewModels
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
        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Sobrenome")]
        public string Sobrenome { get; set; }

        [Required]
        [Display(Name = "Cpf")]
        public string Cpf { get; set; }
        
        [MaxLength(2, ErrorMessage = "Máximo 2 caracteres para o campo [{0}]")]
        [RegularExpression("([0-9]*)", ErrorMessage = "Digite apenas números")]
        [DisplayName("DDD Telefone")]
        public string DddTelefone { get; set; }

        [MaxLength(15, ErrorMessage = "Máximo 15 caracteres para o campo [{0}]")]
        [RegularExpression("([0-9]*)", ErrorMessage = "Digite apenas números")]
        [DisplayName("Telefone")]
        public string Telefone { get; set; }

        [MaxLength(2, ErrorMessage = "Máximo 2 caracteres para o campo [{0}]")]
        [RegularExpression("([0-9]*)", ErrorMessage = "Digite apenas números")]
        [DisplayName("DDD Celular")]
        public string DddCelular { get; set; }

        [MaxLength(15, ErrorMessage = "Máximo 15 caracteres para o campo [{0}]")]
        [RegularExpression("([0-9]*)", ErrorMessage = "Digite apenas números")]
        [DisplayName("Celular")]
        public string Celular { get; set; }

        [Required]
        [Display(Name = "Ativo?")]
        public bool FlgAtivo { get; set; }

        [HiddenInput]
        public System.DateTime DtCadastro { get; set; }

        [HiddenInput]
        public System.Nullable<Guid> IdUsuarioCadastro { get; set; }

        [HiddenInput]
        public System.Nullable<Guid> IdUsuarioAlteracao { get; set; }

        [HiddenInput]
        public System.Nullable<System.DateTime> DtAlteracao { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Senha")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "As senhas não se coincidem.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Required]
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

    public class AlterarViewModel
    {
        [HiddenInput]
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Sobrenome")]
        public string Sobrenome { get; set; }

        [Required]
        [Display(Name = "Cpf")]
        public string Cpf { get; set; }

        [MaxLength(2, ErrorMessage = "Máximo 2 caracteres para o campo [{0}]")]
        [RegularExpression("([0-9]*)", ErrorMessage = "Digite apenas números")]
        [DisplayName("DDD Telefone")]
        public string DddTelefone { get; set; }

        [MaxLength(15, ErrorMessage = "Máximo 15 caracteres para o campo [{0}]")]
        [RegularExpression("([0-9]*)", ErrorMessage = "Digite apenas números")]
        [DisplayName("Telefone")]
        public string Telefone { get; set; }

        [MaxLength(2, ErrorMessage = "Máximo 2 caracteres para o campo [{0}]")]
        [RegularExpression("([0-9]*)", ErrorMessage = "Digite apenas números")]
        [DisplayName("DDD Celular")]
        public string DddCelular { get; set; }

        [MaxLength(15, ErrorMessage = "Máximo 15 caracteres para o campo [{0}]")]
        [RegularExpression("([0-9]*)", ErrorMessage = "Digite apenas números")]
        [DisplayName("Celular")]
        public string Celular { get; set; }

        [Required]
        [Display(Name = "Ativo?")]
        public bool FlgAtivo { get; set; }

        [HiddenInput]
        public System.DateTime DtCadastro { get; set; }

        [HiddenInput]
        public System.Nullable<Guid> IdUsuarioCadastro { get; set; }

        [HiddenInput]
        public System.Nullable<Guid> IdUsuarioAlteracao { get; set; }

        [HiddenInput]
        public System.Nullable<System.DateTime> DtAlteracao { get; set; }

        [StringLength(100, ErrorMessage = "A {0} deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Senha")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "As senhas não se coincidem.")]
        public string ConfirmPassword { get; set; }
    }

    public class AlterarSenhaViewModel
    {
        [HiddenInput]
        public string Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Senha")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "As senhas não se coincidem.")]
        public string ConfirmPassword { get; set; }

        [HiddenInput]
        public System.Nullable<Guid> IdUsuarioAlteracao { get; set; }

        [HiddenInput]
        public System.Nullable<System.DateTime> DtAlteracao { get; set; }
    }
}