using IAPromocoes.Domain.Validation;
using IAPromocoes.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAPromocoes.Domain.Entities
{
    public class Produto
    {
        public Produto()
        {
            this.ItensPedido = new List<ItemPedido>();
            this.ProdutoPrecos = new List<ProdutoPreco>();
            this.ProdutoImagens = new List<ProdutoImagem>();
        }

        public Guid IdProduto { get; set; }
        public Guid IdCategoria { get; set; }
        public string Descricao { get; set; }
        public string SubDescricao { get; set; }
        public string LinkImagem { get; set; }
        public string Atracao { get; set; }
        public string Dia { get; set; }
        public System.DateTime Data { get; set; }
        public System.DateTime Hora { get; set; }
        public string DataTexto { get; set; }
        public string Local { get; set; }
        public string PrecoTexto { get; set; }
        //public System.Nullable<decimal> ValorUnitarioMasculino { get; set; }
        //public System.Nullable<decimal> ValorUnitarioFeminino { get; set; }
        //public string InstrucoesValor { get; set; }
        public string InstrucoesOutros { get; set; }
        //public int QtdProduto { get; set; }
        public System.DateTime DataDisponibilidadeInicial { get; set; }
        public System.DateTime DataDisponibilidadeFinal { get; set; }
        public bool FlgAtivo { get; set; }
        public System.Nullable<int> QtdCurtidas { get; set; }
        public bool FlgEmPromocao { get; set; }
        public Guid IdUsuarioCadastro { get; set; }
        public System.DateTime DtCadastro { get; set; }
        public System.Nullable<Guid> IdUsuarioAlteracao { get; set; }
        public System.Nullable<System.DateTime> DtAlteracao { get; set; }

        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<ItemPedido> ItensPedido { get; set; }
        public virtual ICollection<ProdutoPreco> ProdutoPrecos { get; set; }
        public virtual ICollection<ProdutoImagem> ProdutoImagens { get; set; }

        public ValidationResult ResultadoValidacao { get; private set; }
        public bool IsValid()
        {
            var fiscal = new ProdutoEstaAptoParaCadastroNoSistema();
            ResultadoValidacao = fiscal.Validar(this);
            return ResultadoValidacao.IsValid;
        }


        public decimal Preco { get; set; }
    }
}
