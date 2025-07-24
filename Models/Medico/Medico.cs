using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Tela_PI.Models.Medico
{
    public class Medico
    {

        public string CrmMedico { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Especialidade { get; set; }
        public int Fk_idRegras { get; set; }

        public Medico()
        {
            
        }

       

    }
}

