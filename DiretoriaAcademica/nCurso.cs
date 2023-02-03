using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace DiretoriaAcademica
{
    class nCurso
    {
        private static List<Curso> Cursos = new List<Curso>();
        public static void Inserir(Curso C)
        {
            Abrir();
            Cursos.Add(C);
            Salvar();
        }
        public static List<Curso> Listar()
        {
            Abrir();
            return Cursos;
        }
        public static Curso Listar(int id)
        {
          
            foreach (Curso obj in Cursos)
                if (obj.id == id) return obj;
            return null;
        }
        public static void Atualizar(Curso c)
        {
            Abrir();
            
            foreach (Curso obj in Cursos)
                if (obj.id == c.id)
                {
                    obj.nome = c.nome;
                    obj.sigla = c.sigla;
                }
            Salvar();
        }
        public static void Excluir(Curso c)
        {
            Abrir();
           
            Curso x = null;
            foreach (Curso obj in Cursos)
                if (obj.id == c.id) x = obj;
            if (x != null) Cursos.Remove(x);
            Salvar();
        }
        public static void Abrir()
        {
            StreamReader f = null;
            try
            {
                // Objeto que serializa (transforma) uma lista de Cursos em um texto em XML
                XmlSerializer xml = new XmlSerializer(typeof(List<Curso>));
                // Objeto que abre um texto em um arquivo
                f = new StreamReader("./Cursos.xml");
                // Chama a operação de desserialização informando a origem do texto XML
                Cursos = (List<Curso>)xml.Deserialize(f);
            }
            catch
            {
                Cursos = new List<Curso>();
            }
            // Fecha o arquivo
            if (f != null) f.Close();
        }
        public static void Salvar()
        {
            // Objeto que serializa (transforma) uma lista de Cursos em um texto em XML
            XmlSerializer xml = new XmlSerializer(typeof(List<Curso>));
            // Objeto que grava um texto em um arquivo
            StreamWriter f = new StreamWriter("./Cursos.xml", false);
            // Chama a operação de serialização informando o destino do texto XML
            xml.Serialize(f, Cursos);
            // Fecha o arquivo
            f.Close();
        }
        public static void Matricular(Curso c, Diretoria d)
        {
            c.idDiretoria = d.id;
            Atualizar(c);
        }
        public static List<Curso> Listar(Diretoria d)
        {
            Abrir();
            List<Curso> listcursos = new List<Curso>();
            foreach (Curso obj in Cursos)
                if (obj.idDiretoria == d.id) listcursos.Add(obj);
            return listcursos;
        }
    }
}
