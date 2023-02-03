using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiretoriaAcademica
{
    class Diretoria
    {
        public int id { get; set; }
        public string sigla { get; set; }
        public string nome { get; set; }
        public override string ToString()
        {
            return $"ID: {id} - Nome: {nome} - Sigla: {sigla} ";

        }
    }
}
