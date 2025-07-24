using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Org.BouncyCastle.Crypto.Utilities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace Projeto_Tela_PI.Models.Prontuario
{
    public class Prontuario
    {
        
        
            public int IdProntuario { get; set; }
            public string Observacoes { get; set; }
            public string Exames { get; set; }
            public string Tratamento { get; set; }
            public string Consultas { get; set; }
            public string Patologia { get; set; }
            public string CpfPaciente { get; set; }
            public string CrmMedico { get; set; }
        

    }
}
