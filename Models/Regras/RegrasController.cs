using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_Tela_PI.Models.Fila;
using System.Windows.Forms;

namespace Projeto_Tela_PI.Models.Regras
{
    public class RegrasController
    {
        private RegrasRepositorio _regrasRepositorio;

        public RegrasController(RegrasRepositorio regrasRepositorio)
        {
            this._regrasRepositorio = regrasRepositorio;
        }

        public bool InserirMedico(Regras regras)
        {

            bool resultado = _regrasRepositorio.Register(regras);

            if (resultado)
            {
                MessageBox.Show("Paciente Adicionado a Fila Com Sucesso");
                return true;
            }
            MessageBox.Show("Deu merda!!!");
            return false;
        }
    }
}
