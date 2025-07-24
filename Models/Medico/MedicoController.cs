using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlX.XDevAPI.Common;
using Projeto_Tela_PI.Model;

namespace Projeto_Tela_PI.Models.Medico
{
    class MedicoController
    {
        private MedicoRepositorio _medicoRepositorio;

        public MedicoController(MedicoRepositorio medicoRepositorio)
        {
            this._medicoRepositorio = medicoRepositorio;
        }

        public bool InserirMedico(Medico medico, string password) {

           bool resultado = _medicoRepositorio.Register(medico, password);

            if (resultado)
            {
                MessageBox.Show("Médico registrado com sucesso");
                return true;
            }
            MessageBox.Show("Deu merda!!!");
            return false;
        }

        public Medico AutenticarLogin(string crmMedico, string password) {

           Medico medicoResult =  _medicoRepositorio.Authenticate(crmMedico, password);
                   
            return medicoResult;
        
        }
    }
}
