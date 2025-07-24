using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Utilities;
using ZstdSharp.Unsafe;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Projeto_Tela_PI.Models.Paciente
{
    public class Paciente
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Senha { get; set; }
        public string CartaoSus { get; set; }
        public string Telefone { get; set; }
        public int IdRegras { get; set; } //Estrangeira


        public Paciente() { }


        public static Paciente PacienteFromDataReader(MySqlDataReader reader) {

            return new Paciente { 
            
                   Cpf = reader["cpfPaciente"].ToString(),
                   Nome = reader["nome"].ToString(),
                   DataNascimento = Convert.ToDateTime(reader["DataNascimento"]),
                   Email = reader["email"].ToString(),
                   Endereco = reader["endereco"].ToString(),
                   CartaoSus = reader["cartaoSus"].ToString(),
                   Telefone = reader["telefone"].ToString(),

            };
        
        }

        public int CalcularIdade() {
            int idade = 0;

            //DataNascimento = Convert.ToDateTime(reader["DataNascimento"]);
            


            return idade;

        }


    }
}

 


        

