using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Projeto_Tela_PI
{
    public class Triagem
    {
        public Triagem(
            )
        {
           
        }

        public int IdTriagem { get; set; }
        public string Observacoes { get; set; }
        public string Sintomas { get; set; }
        public DateTime Data { get; set; }
        public string TemperaturaCorporal { get; set; }
        public string PressaoArterial { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }
        public int Senha { get; set; }
        public string fk_CpfPaciente { get; set; }
       
    }

}

