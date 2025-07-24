using Projeto_Tela_PI.Models;
using Projeto_Tela_PI.Services;
using Projeto_Tela_PI.Models.Paciente;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_Tela_PI.Models.Medico;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Data.SqlClient;
using System.Collections;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
namespace Projeto_Tela_PI.Models.Fila
{
    
    public class FilaRepositorio
    {
        
        
        private readonly DatabaseService _databaseService;

            
        public FilaRepositorio(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }



        public Fila BuscarProximoDaFila(int tipoFila)
        {
            
            if(tipoFila == 1) // If foi improviso por que @tipo tava quebrando e temos pouco tempo , kkkk
            {
                using (MySqlConnection conn = _databaseService.GetConnectionString())
                {
                    conn.Open();

                    string query = "SELECT * FROM Fila WHERE TipoFila = 1 ORDER BY IdFila ASC LIMIT 1;";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@tipoFila", tipoFila);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                return new Fila
                                {
                                    IdFila = Convert.ToInt32(reader["IdFila"]),
                                    CpfPaciente = reader["CpfPaciente"].ToString(),
                                    Prioridade = Convert.ToInt32(reader["Prioridade"]),
                                    // Adicione outros campos se necessário
                                };
                            }
                        }
                        return null;
                    }
                    
                }
            }
            else if (tipoFila == 2)
            {
                using (MySqlConnection conn = _databaseService.GetConnectionString())
                {
                    conn.Open();

                    string query = "SELECT * FROM Fila WHERE TipoFila = 2 ORDER BY IdFila ASC LIMIT 1;";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@tipoFila", tipoFila);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                return new Fila
                                {
                                    IdFila = Convert.ToInt32(reader["IdFila"]),
                                    CpfPaciente = reader["CpfPaciente"].ToString(),
                                    Prioridade = Convert.ToInt32(reader["Prioridade"]),
                                    // Adicione outros campos se necessário
                                };
                            }
                        }
                        return null;
                    }

                }
            }
            return null; 



        }
        public void AtualizarTipoFila(string cpfPaciente)
        {
            using (MySqlConnection conn = _databaseService.GetConnectionString())
            {
                conn.Open();
                string query = "UPDATE Fila SET TipoFila = 2 WHERE CpfPaciente = @CpfPaciente";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CpfPaciente", cpfPaciente);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        //comentarios para o git respeitar a pequena mudança 
        public bool Register(Fila fila)
        {
            fila.HoraCadastro = DateTime.Now;
            
            const string query = @"INSERT INTO fila
                                (cpfPaciente, prioridade, tipoFila, horaCadastro ) 
                                VALUES 
                                (@cpfPaciente, @prioridade, @tipoFila, @horaCadastro)";
                
            try
            {
                       
                
                var parameters = new MySqlParameter[]

                {

                new MySqlParameter("@cpfPaciente", fila.CpfPaciente),
                new MySqlParameter("@prioridade", fila.Prioridade),     
                new MySqlParameter("@tipoFila", fila.TipoFila),
                new MySqlParameter("@horaCadastro", fila.HoraCadastro),

                };
                   

                int affectedRows = _databaseService.ExecuteNonQuery(query, parameters);
                return affectedRows > 0;
            }
            catch (Exception ex)
            {

                Console.WriteLine("Erro ao registrar usuário: " + ex.Message);
                Console.WriteLine("Stack Trace: " + ex.StackTrace);
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
                }
                throw new Exception("Erro ao registrar usuário: " + ex.StackTrace, ex);

            }
        }



    public List<Paciente.Paciente> GetListaFila(int tipo)
    {
        List<Paciente.Paciente> listaPacientes = new List<Paciente.Paciente>();

        try
        {

            string query = $"SELECT * FROM fila f JOIN paciente p ON p.cpf = f.cpfPaciente WHERE tipoFila = {tipo} ORDER BY f.horaCadastro ASC";


            MySqlDataReader reader = _databaseService.ExecuteQuery(query);

            while (reader.Read())
            {
                Paciente.Paciente paciente =  Paciente.Paciente.PacienteFromDataReader(reader);
                listaPacientes.Add(paciente);

            }

            return listaPacientes;




        }
        catch (Exception ex)
            {
                throw new Exception("Erro ao registrar usuário: " + ex.Message);
            }

        }

        internal List<Paciente.Paciente> GetListaFila()
        {
            throw new NotImplementedException();
        }
    }
}


