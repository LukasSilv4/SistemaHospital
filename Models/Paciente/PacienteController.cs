using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Projeto_Tela_PI.Models.Paciente
{
   public class PacienteController
    {
        private PacienteRepositorio _pacienteRepositorio;

        public PacienteController(PacienteRepositorio pacienteRepositorio)
        {
            this._pacienteRepositorio = pacienteRepositorio;
        }

        public bool InserirPaciente(Paciente paciente)
        {

            bool resultado = _pacienteRepositorio.Register(paciente);

            if (resultado)
            {
                MessageBox.Show("Paciente registrado com sucesso");
                return true;
            }
            MessageBox.Show("Deu merda!!!");
            return false;

        }
        public Paciente BuscarPorCpf(string cpf)
        {
            return _pacienteRepositorio.BuscarPorCpf(cpf);
        }
        public Paciente AutenticarLogin(string cpf, DateTime dateTime)
        {

            Paciente pacienteResult = _pacienteRepositorio.Authenticate(cpf, dateTime);

            return pacienteResult;
        }
    }
}
