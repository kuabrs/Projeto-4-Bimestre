using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DiretoriaAcademica
{
    class nDiretoria
    {
        private static List<Diretoria> Diretorias = new List<Diretoria>();
        public static void Inserir(Diretoria d)
        {
            Abrir();
            Diretorias.Add(d);
            Salvar();
        }
        public static List<Diretoria> Listar()
        {
            Abrir();
            return Diretorias;
        }
        public static Diretoria Listar(int id)
        {

            foreach (Diretoria obj in Diretorias)
                if (obj.id == id) return obj;
            return null;
        }
        public static void Atualizar(Diretoria d)
        {
            Abrir();
            // Percorrer a lista de Diretoria procurando o id informado (d.Id)
            foreach (Diretoria obj in Diretorias)
                if (obj.id == d.id)
                {
                    obj.nome = d.nome;
                    obj.sigla = d.sigla;
                }
            Salvar();
        }
        public static void Excluir(Diretoria d)
        {
            Abrir();
            // Percorrer a lista de Diretoria procurando o id informado (d.Id)
            Diretoria x = null;
            foreach (Diretoria obj in Diretorias)
                if (obj.id == d.id) x = obj;
            if (x != null) Diretorias.Remove(x);
            Salvar();
        }
        public static void Abrir()
        {
            StreamReader f = null;
            try
            {
                // Objeto que serializa (transforma) uma lista de Diretorias em um texto em XML
                XmlSerializer xml = new XmlSerializer(typeof(List<Diretoria>));
                // Objeto que abre um texto em um arquivo
                f = new StreamReader("./Diretorias.xml");
                // Chama a operação de desserialização informando a origem do texto XML
                Diretorias = (List<Diretoria>)xml.Deserialize(f);
            }
            catch
            {
                Diretorias = new List<Diretoria>();
            }
            // Fecha o arquivo
            if (f != null) f.Close();
        }
        public static void Salvar()
        {
            // Objeto que serializa (transforma) uma lista de Diretorias em um texto em XML
            XmlSerializer xml = new XmlSerializer(typeof(List<Diretoria>));
            // Objeto que grava um texto em um arquivo
            StreamWriter f = new StreamWriter("./Diretorias.xml", false);
            // Chama a operação de serialização informando o destino do texto XML
            xml.Serialize(f, Diretorias);
            // Fecha o arquivo
            f.Close();
        }
    }
}
