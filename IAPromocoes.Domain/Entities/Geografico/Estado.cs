using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAPromocoes.Domain.Entities
{
    public class Estado
    {
        public Estado()
        {
            this.Cidades = new List<Cidade>();
        }

        public string IdEstado { get; set; }
        public string Descricao { get; set; }
        public bool FlgAtivo { get; set; }
        public int Ordem { get; set; }
        public Guid IdUsuarioCadastro { get; set; }
        public System.DateTime DtCadastro { get; set; }
        public System.Nullable<Guid> IdUsuarioAlteracao { get; set; }
        public System.Nullable<System.DateTime> DtAlteracao { get; set; }

        public virtual ICollection<Cidade> Cidades { get; set; }

    }
}
