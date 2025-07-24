using Projeto_Tela_PI.Models.Paciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Tela_PI.Services
{ 
    public static class SessionPaciente
    {
      
            public static Paciente PacienteAtual { get; set; }

            public static void Limpar()
            {
                PacienteAtual = null;
            }
        }
    }

