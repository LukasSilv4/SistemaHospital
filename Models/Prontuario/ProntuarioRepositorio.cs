using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Projeto_Tela_PI.Services;

namespace Projeto_Tela_PI.Models.Prontuario
{
   public class ProntuarioRepositorio
    {
        
            DatabaseService _databaseService;

            public ProntuarioRepositorio(DatabaseService databaseService)
            {
                _databaseService = databaseService;
            }

            public bool Register(Prontuario prontuario)
            {
                try
                {
                    string query = @"INSERT INTO prontuario
                                (observacoes, exames, tratamento, consultas, patologia, cpfPaciente, crmMedico) 
                                VALUES 
                               (@observacoes, @exames, @tratamento, @consultas, @patologia, @cpfPaciente, @crmMedico)";

                    var parameters = new MySqlParameter[]

                    {
                    new MySqlParameter("observacoes", prontuario.Observacoes),
                    new MySqlParameter("exames", prontuario.Exames),
                    new MySqlParameter("tratamento", prontuario.Tratamento),
                    new MySqlParameter("consultas", prontuario.Consultas),
                    new MySqlParameter("patologioa", prontuario.Patologia),
                    new MySqlParameter("cpfPaciente", prontuario.CpfPaciente),
                    new MySqlParameter("crmMedico", prontuario.CpfPaciente)

                    };

                    int affectedRows = _databaseService.ExecuteNonQuery(query, parameters);
                    return affectedRows > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao registrar prontuário: " + ex.Message);
                }
            }
        }
}
