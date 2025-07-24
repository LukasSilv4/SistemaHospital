// Models/Usuario.cs
using System;

namespace Projeto_Tela_PI.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string SenhaHash { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        //internal static Usuario UserFromDataReader(MySqlDataReader resultadoBanco)
        //{
        //    throw new NotImplementedException();
        //}
    }
}