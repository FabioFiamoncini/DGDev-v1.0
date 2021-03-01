using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGoDev.Model
{
    class Pessoa
    {
        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string SalaEtapa1 { get; set; }
        public string SalaEtapa2 { get; set; }
        public string EspacoEtapa1 { get; set; }
        public string EspacoEtapa2 { get; set; }

        public Pessoa(int id, string nome, string sobrenome, string salaEtapa1, string salaEtapa2, string espacoEtapa1, string espacoEtapa2)
        {
            this.IdPessoa = id;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.SalaEtapa1 = salaEtapa1;
            this.SalaEtapa2 = salaEtapa2;
            this.EspacoEtapa1 = espacoEtapa1;
            this.EspacoEtapa2 = espacoEtapa2;
        }
    }
}
