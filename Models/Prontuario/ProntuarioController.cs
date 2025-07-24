using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_Tela_PI.Models.Prontuario;
using System.Windows.Forms;

namespace Projeto_Tela_PI.Models.Prontuario
{
    public class ProntuarioController
    {
      
            private ProntuarioRepositorio _prontuarioRepositorio;

            public ProntuarioController(ProntuarioRepositorio prontuarioRepositorio)
            {
                this._prontuarioRepositorio = prontuarioRepositorio;
            }

            public bool InserirProntuario(Prontuario prontuario)
            {

                bool resultado = _prontuarioRepositorio.Register(prontuario);

                if (resultado)
                {
                    MessageBox.Show("Prontuario registrado com sucesso");
                    return true;
                }
                MessageBox.Show("Deu merda!!!");
                return false;
            }
        
    }
}

