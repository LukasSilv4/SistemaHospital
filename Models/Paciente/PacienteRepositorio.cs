using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Projeto_Tela_PI.Services;

namespace Projeto_Tela_PI.Models.Paciente
{
    public class PacienteRepositorio
    {
        DatabaseService _databaseService;

        public PacienteRepositorio (DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }


        public Paciente BuscarPorCpf(string cpf)
        {
            using (MySqlConnection conn = _databaseService.GetConnectionString())
            {
                conn.Open();
                string query = "SELECT * FROM Paciente WHERE Cpf = @cpf";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@cpf", cpf);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Paciente
                            {
                                Nome = reader["nome"].ToString(),
                                DataNascimento = Convert.ToDateTime(reader["DataNascimento"]),
                                CartaoSus = reader["cartaoSus"].ToString(),
                                Cpf = reader["cpf"].ToString(),
                                Telefone = reader["telefone"].ToString()
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
        public bool Register(Paciente paciente)
        {
            try
            {
                string query = @"INSERT INTO paciente
                                (cpf, nome, dataNascimento, email, endereco, cartaoSus, telefone) 
                                VALUES 
                               (@cpf, @nome, @dataNascimento,  @email, @endereco, @cartaoSus, @telefone)";

                var parameters = new MySqlParameter[]

                {
                    new MySqlParameter("@cpf", paciente.Cpf),
                    new MySqlParameter("@nome", paciente.Nome),
                    new MySqlParameter("@dataNAscimento", paciente.DataNascimento),
                    new MySqlParameter("@email", paciente.Email),
                   // new MySqlParameter("@senha_hash",  Criptografia.HashPassword(password)),
                   new MySqlParameter("@endereco", paciente.Endereco),
                    new MySqlParameter("@cartaoSus", paciente.CartaoSus),
                    new MySqlParameter("@telefone", paciente.Telefone ),
                    
                };

                int affectedRows = _databaseService.ExecuteNonQuery(query, parameters);
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao registrar usuario: " + ex.Message);
            }
        }
        public Paciente Authenticate(string cpf, DateTime date)
        {
            
            try
            {
                // Primeiro busca o usuário pelo cpf
                string query = "SELECT * FROM paciente WHERE cpf = @cpfPaciente AND DataNascimento = @dataNascimento";
                var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@cpfPaciente", cpf),
                    new MySqlParameter("@dataNascimento", date.ToString("yyyy-MM-dd"))
                };

                using (var reader = _databaseService.ExecuteQuery(query, parameters))
                {
                    if (reader.Read())
                    {
                        // Verifica a senha
                        string storedDate = DateTime.Parse(reader["dataNascimento"].ToString()).ToString("yyyy-MM-dd");
                        string storedCPF = reader["cpf"].ToString();

                        MessageBox.Show((storedCPF == cpf).ToString());
                        MessageBox.Show(storedDate);




                        if (storedDate == date.ToString("yyyy-MM-dd") && storedCPF == cpf)
                        {
                            Paciente paciente = new Paciente
                            {
                                Cpf = reader["cpf"].ToString(),
                                Nome = reader["nome"].ToString(),
                                DataNascimento = DateTime.Parse(DateTime.Parse(reader["dataNascimento"].ToString()).ToString("dd/MM/yyyy")),
                                Email = reader["email"].ToString(),
                                Endereco = reader["endereco"].ToString(),
                                CartaoSus = reader["cartaoSus"].ToString(),
                                Telefone = reader["telefone"].ToString(),
                            };
                            SessionUser.SetUserPaciente(paciente);
                            MessageBox.Show(paciente.Nome);
                            return paciente;

                        }
                        


                            MessageBox.Show("Dados não conferem");
                                               



                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante autenticação: " + ex.Message);
            }
        }

       
    }
}
