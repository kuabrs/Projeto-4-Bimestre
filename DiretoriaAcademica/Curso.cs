using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiretoriaAcademica
{
    class Curso
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string sigla { get; set; }
        public int idDiretoria { get; set; }
        public override string ToString()
        {
            if (idDiretoria == 0)
                return $"Id: {id} - Nome: {nome} - Sigla: {sigla} ";
            else
                return $"Id: {id} - Nome: {nome} - Sigla: {sigla} - Diretoria: {idDiretoria}";
        }

    }
}
