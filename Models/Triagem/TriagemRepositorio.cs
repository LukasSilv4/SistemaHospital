using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Projeto_Tela_PI.Services;

namespace Projeto_Tela_PI.Models
{
    public class TriagemRepositorio
    {
        DatabaseService _databaseService;

        public TriagemRepositorio(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        //public DataTable ObterDadosTriagem(int idFilaTriagem)
        //{
        //    using (MySqlConnection connection = new MySqlConnection(connectionString))
        //    {
        //        string queryTriagem = "SELECT Paciente.nome, Triagem.* FROM Triagem JOIN Paciente ON Triagem.idPaciente = Paciente.idPaciente WHERE Triagem.idFila = @idFila";
        //        MySqlDataAdapter adapterTriagem = new MySqlDataAdapter(queryTriagem, connection);
        //        adapterTriagem.SelectCommand.Parameters.AddWithValue("@idFila", idFilaTriagem);
        //        DataTable dtTriagem = new DataTable();
        //        adapterTriagem.Fill(dtTriagem);
        //        return dtTriagem;
        //    }
        //}
        public bool Register(Triagem triagem)
        {
            try
            {
                string query = @"INSERT INTO triagem
                                (observacoes, sintomas, data, temperaturaCorporal, pressaoArterial, peso, altura, cpfPaciente) 
                                VALUES 
                               (@observacoes, @sintomas, @data, @temperaturaCorporal, @pressaoArterial, @peso, @altura, @cpfPaciente)";

                var parameters = new MySqlParameter[]

                {
                    new MySqlParameter("@observacoes", triagem.Observacoes),
                    new MySqlParameter("@sintomas", triagem.Sintomas),
                    new MySqlParameter("@data", triagem.Data),
                    new MySqlParameter("@temperaturaCorporal", triagem.TemperaturaCorporal),

                   // new MySqlParameter("@senha_hash",  Criptografia.HashPassword(password)),
                    new MySqlParameter("@pressaoArterial", triagem.PressaoArterial),
                    new MySqlParameter("@peso", triagem.Peso),
                    new MySqlParameter("@altura", triagem.Altura),
                    new MySqlParameter("@cpfPaciente", triagem.fk_CpfPaciente),
               

                };

                int affectedRows = _databaseService.ExecuteNonQuery(query, parameters);
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao registrar Ficha: " + ex.Message);
            }
        }
    }
}
