using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_Tela_PI.Models.Medico;
using Projeto_Tela_PI.Models.Paciente;

namespace Projeto_Tela_PI.Services
{
    class SessionUser
    {
        public static Medico MedicoLogado { get; set; }
        public static Paciente PacienteLogado { get; set; }

        public static void Login(Medico medico)
        {

            MedicoLogado = medico;

        }
        public static void SetUserPaciente(Paciente paciente)
        {
            PacienteLogado = paciente;
        }
       
    }
}





