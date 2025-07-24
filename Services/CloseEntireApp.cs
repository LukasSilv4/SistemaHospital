using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Tela_PI.Services
{
    public static class CloseEntireApp
    {

        public static void CloseAllApp(object sender, FormClosingEventArgs e) { 
        
            Application.ExitThread();
        
        }

    }
}
