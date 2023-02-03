using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiretoriaAcademica
{
    class Professor
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string matricula { get; set; }
        public int idDiretoria { get; set; }
        public override string ToString()
        {
            if (idDiretoria == 0)
                return $"Id: {id} - Nome: {nome} - Matrícula: {matricula} ";
            else
                return $"Id: {id} - Nome: {nome} - Matrícula: {matricula} - Diretoria: {idDiretoria}";
        }

    }
}
