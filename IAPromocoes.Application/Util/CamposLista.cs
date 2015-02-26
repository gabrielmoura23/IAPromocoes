using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAPromocoes.Application.Util
{
    public class CamposLista
    {
        public static List<dynamic> GetListaSexo()
        {
            var SexoList = new List<dynamic>();
            SexoList.Add(new { Id = "", Text = "(Selecione)" });
            SexoList.Add(new { Id = "M", Text = "Masculino" });
            SexoList.Add(new { Id = "F", Text = "Feminino" });
            return SexoList;
        }
    }
}
