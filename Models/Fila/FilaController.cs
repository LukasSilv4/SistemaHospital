using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Projeto_Tela_PI.Model;

namespace Projeto_Tela_PI.Models.Fila
{
    public class FilaController
    {
       
        private FilaRepositorio _filaRepositorio;

        public FilaController(FilaRepositorio filaRepositorio)
        {
            this._filaRepositorio = filaRepositorio ?? throw new ArgumentNullException(nameof(filaRepositorio)); ;
        }

        public  Fila BuscarProximoFila(int tipoFila)
        {
            return _filaRepositorio.BuscarProximoDaFila(tipoFila);
        }


        public void MoverParaProximaFila(string cpfPaciente)
        {
            _filaRepositorio.AtualizarTipoFila(cpfPaciente); 
        }

        public bool InserirFila(Fila fila)
        {
            try
            {

                if (fila == null)
                {
                    throw new ArgumentNullException("Objeto Fila não pode ser nulo");
                }
                if (string.IsNullOrEmpty(fila.CpfPaciente))
                {
                    throw new ArgumentException("CPF do Paciente é obrigatorio");
                }
                bool resultado = _filaRepositorio.Register(fila);
                return resultado;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao inserir fila: {ex.Message}");
                throw; // Re-lança para ser tratado na camada de UI
            }
        }

        public List<Paciente.Paciente> GetListaFila(int tipo)
        {
        List<Paciente.Paciente> listaPaciente = _filaRepositorio.GetListaFila(tipo);              
        return listaPaciente;
        }
        
    }
}
