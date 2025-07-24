
using Projeto_Tela_PI.Models;
using Projeto_Tela_PI.Services;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_Tela_PI.Models.Medico;
using System.Windows.Forms;

namespace Projeto_Tela_PI.Model
{
    public class MedicoRepositorio
    {
        DatabaseService _databaseService;

        public MedicoRepositorio(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public bool Register(Medico medico, string password)
        {
            try
            {
                string query = @"INSERT INTO medicos
                                (crmMedico, email, senha, nome, especialidade, idRegras) 
                                VALUES 
                               (@crmMedico, @email, @senha_hash, @nome, @especialidade, @idRegras)";

                var parameters = new MySqlParameter[]
                    
                {
                    new MySqlParameter("@crmMedico", medico.CrmMedico),
                    new MySqlParameter("@nome", medico.Nome),
                    new MySqlParameter("@email", medico.Email),
                    new MySqlParameter("@senha_hash",  Criptografia.HashPassword(password)),
                    new MySqlParameter("@especialidade", medico.Especialidade ),
                    new MySqlParameter("@idRegras", medico.Fk_idRegras )
                };

                int affectedRows = _databaseService.ExecuteNonQuery(query, parameters);
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao registrar usuário: " + ex.Message);
            }
        }

        public Medico Authenticate(string crmMedico, string password)
        {
            try
            {
                // Primeiro busca o usuário pelo email
                string query = "SELECT * FROM medicos WHERE crmMedico = @crmMedico";
                var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@crmMedico", crmMedico)
                };

                using (var reader = _databaseService.ExecuteQuery(query, parameters))
                {
                    if (reader.Read())
                    {
                        // Verifica a senha
                        string storedHash = reader["senha"].ToString();
                        string inputHash = Criptografia.HashPassword(password.Trim());

                        bool hashs = (storedHash == inputHash);

                       

                        if (storedHash == inputHash)
                        {
                             Medico medico = new Medico
                            {
                                CrmMedico = reader["crmMedico"].ToString(),
                                Nome = reader["nome"].ToString(),
                                Email = reader["email"].ToString(),
                                Senha = storedHash,
                                Especialidade = reader["especialidade"].ToString(),
                                Fk_idRegras = Convert.ToInt32(reader["idRegras"]),
                             };
                            SessionUser.Login(medico);
                            MessageBox.Show(medico.Nome);
                            return medico;

                        }
                        
                       
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
