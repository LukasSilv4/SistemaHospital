using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Tela_PI.Models.Fila
{
    public class Fila
    {
        public string Nome { get; set; }
        public int IdFila { get; set; }
        public string CpfPaciente { get; set; }
        public int Prioridade { get; set; }
        public int TipoFila { get; set; }
        public DateTime HoraCadastro { get; set; }

        
        
        public string infoFila
        {
            get
            {
                TimeSpan tempo = DateTime.Now - HoraCadastro;
                return $"{Nome} - {tempo.TotalMinutes:F0} min na fila";
            }
                
            
        }

        public Fila()
        {

        }
    }
}
