using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Projeto_Tela_PI.Model;

namespace Projeto_Tela_PI.Models
{
    public class TriagemController
    {
        private TriagemRepositorio _triagemRepositorio;

        public TriagemController(TriagemRepositorio triagemRepositorio)
        {
            this._triagemRepositorio = triagemRepositorio;
        }
        //public DataTable ObterDadosTriagem(int idFilaTriagem)
        //{
        //    return _triagemRepositorio.ObterDadosTriagem(idFilaTriagem);
        //}
        public bool CadastrarTriagem(Triagem triagem)
        {

            bool resultado = _triagemRepositorio.Register(triagem);

            if (resultado)
            {
                MessageBox.Show("Ficha do paciente registrada com sucesso");
                return true;
            }
            MessageBox.Show("Deu merda!!!");
            return false;
        }
    }
}