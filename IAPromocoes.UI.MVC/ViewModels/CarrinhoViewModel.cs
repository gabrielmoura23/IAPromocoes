using IAPromocoes.Application.ViewModels;
using IAPromocoes.UI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IAPromocoes.UI.MVC.ViewModels
{
    public class CarrinhoViewModel
    {
        public Carrinho Carrinho { get; set; }

        public string ReturnUrl { get; set; }
    }
}