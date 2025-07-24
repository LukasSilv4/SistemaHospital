using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Projeto_Tela_PI.Services;

namespace Projeto_Tela_PI.Models.Regras
{
    public class RegrasRepositorio
    {
        DatabaseService _databaseService;

        public RegrasRepositorio(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public bool Register(Regras regras)
        {

            {
                try
                {
                    string query = @"INSERT INTO regras
                                (idRegras, nomeRegras) 
                                VALUES 
                               (@idRegras, @nomeRegras)";

                    var parameters = new MySqlParameter[]

                    {
                    new MySqlParameter("@idRegras", regras.IdRegras),
                    new MySqlParameter("@nomeRegras", regras.NomeRegras),
                   

                    };


                    int affectedRows = _databaseService.ExecuteNonQuery(query, parameters);
                    return affectedRows > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao registrar usuário: " + ex.Message);
                }
            }
        }
    }
}
