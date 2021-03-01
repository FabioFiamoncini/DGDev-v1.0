using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGoDev.Model
{
    class EspacoCafe
    {
        public string Nome { get; set; }
        public int Lotação { get; set; }
        public int Etapa1 { get; set; }
        public int Etapa2 { get; set; }

        public EspacoCafe(string nome, int lotacao, int etapa1, int etapa2)
        {
            this.Nome = nome;
            this.Lotação = lotacao;
            this.Etapa1 = etapa1;
            this.Etapa2 = etapa2;
        }
    }
}
