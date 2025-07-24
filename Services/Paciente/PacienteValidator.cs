using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Projeto_Tela_PI.Models.Services
{
    class PacienteValidator
    {
        //verificar numero digitos cpf 
        public static bool ValidadarCpf(string cpf)
        {
            cpf = Regex.Replace(cpf, "[^0-9]", "");

            if (cpf.Length != 11)
            {
                return false;
            }
            


            return true; // O CPF TEM 11 NUMEROS 

        } 




        //111.222.333-45

    }
}
