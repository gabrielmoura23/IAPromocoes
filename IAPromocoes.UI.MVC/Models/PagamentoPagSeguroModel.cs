using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IAPromocoes.UI.MVC.Models
{
    public class PagamentoPagSeguroModel
    {
        public PagamentoPagSeguroProduto Produto { get; set; }
        public PagamentoPagSeguroEndereco Endereco { get; set; }
        public PagamentoPagSeguroPedido Pedido { get; set; }
        public PagamentoPagSeguroCobrador Cobrador { get; set; }
    }

    public class PagamentoPagSeguroEndereco
    {
        public string Pais { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
    }

    public class PagamentoPagSeguroProduto
    {
        int id { get; set; }
        public int ID_PRODUTO { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
    }

    public class PagamentoPagSeguroCobrador
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public int TelefonePrevixo { get; set; }
        public int TelefoneNumero { get; set; }
        public string CPF { get; set; }
    }

    public class PagamentoPagSeguroPedido
    {
        public string Reference { get; set; }
        public string RedirectUri { get; set; }
    }
}