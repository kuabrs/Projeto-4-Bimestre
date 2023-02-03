using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DiretoriaAcademica
{
    class nProfessor
    {
        private static List<Professor> Professores = new List<Professor>();
        public static void Inserir(Professor P)
        {
            Abrir();
            Professores.Add(P);
            Salvar();
        }
        public static List<Professor> Listar()
        {
            Abrir();
            return Professores;
        }
        public static Professor Listar(int id)
        {

            foreach (Professor obj in Professores)
                if (obj.id == id) return obj;
            return null;
        }
        public static void Atualizar(Professor p)
        {
            Abrir();
            // Percorrer a lista de Professores procurando o id informado (a.Id)
            foreach (Professor obj in Professores)
                if (obj.id == p.id)
                {
                    obj.nome = p.nome;
                    obj.matricula = p.matricula;
                }
            Salvar();
        }
        public static void Excluir(Professor p)
        {
            Abrir();
            // Percorrer a lista de Professores procurando o id informado (a.Id)
            Professor x = null;
            foreach (Professor obj in Professores)
                if (obj.id == p.id) x = obj;
            if (x != null) Professores.Remove(x);
            Salvar();
        }
        public static void Abrir()
        {
            StreamReader f = null;
            try
            {
                // Objeto que serializa (transforma) uma lista de Professores em um texto em XML
                XmlSerializer xml = new XmlSerializer(typeof(List<Professor>));
                // Objeto que abre um texto em um arquivo
                f = new StreamReader("./Professores.xml");
                // Chama a operação de desserialização informando a origem do texto XML
                Professores = (List<Professor>)xml.Deserialize(f);
            }
            catch
            {
                Professores = new List<Professor>();
            }
            // Fecha o arquivo
            if (f != null) f.Close();
        }
        public static void Salvar()
        {
            // Objeto que serializa (transforma) uma lista de Professores em um texto em XML
            XmlSerializer xml = new XmlSerializer(typeof(List<Professor>));
            // Objeto que grava um texto em um arquivo
            StreamWriter f = new StreamWriter("./Professores.xml", false);
            // Chama a operação de serialização informando o destino do texto XML
            xml.Serialize(f, Professores);
            // Fecha o arquivo
            f.Close();
        }
        public static void Matricular(Professor p, Diretoria d)
        {
            p.idDiretoria = d.id;
            Atualizar(p);
        }
        public static List<Professor> Listar(Diretoria d)
        {
            Abrir();
            List<Professor> listProfessores = new List<Professor>();
            foreach (Professor obj in Professores)
                if (obj.idDiretoria == d.id) listProfessores.Add(obj);
            return listProfessores;
        }
    }
}