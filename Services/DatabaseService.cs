﻿// Services/DatabaseService.cs
using System;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;

namespace Projeto_Tela_PI.Services
{
    public class DatabaseService : IDisposable
    {
        private readonly MySqlConnection _connection;
        private bool _disposed = false;
        

        public DatabaseService()
        {
            // Configura a string de conexão no arquivo App.config
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            _connection = new MySqlConnection(connectionString);
        }

        public MySqlConnection GetConnectionString()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            return new MySqlConnection(connectionString);
        }



        public void OpenConnection()
        {
            if (_connection.State != System.Data.ConnectionState.Open)
            {
                _connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (_connection.State != System.Data.ConnectionState.Closed)
            {
                _connection.Close();
            }
        }

        public MySqlDataReader ExecuteQuery(string query, MySqlParameter[] parameters = null)
        {
            try
            {
                OpenConnection();
                var command = new MySqlCommand(query, _connection);
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                return command.ExecuteReader();
            }
            catch (Exception ex)
            {
                CloseConnection();
                throw new Exception("Erro ao executar consulta: " + ex.Message);
            }
        }

        public int ExecuteNonQuery(string commandText, MySqlParameter[] parameters = null)
        {
            try
            {
                OpenConnection();
                var command = new MySqlCommand(commandText, _connection);
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao executar comando: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        
        public object ExecuteScalar(string commandText, MySqlParameter[] parameters = null)
        {
            try
            {
                OpenConnection();
                var command = new MySqlCommand(commandText, _connection);
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                return command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao executar scalar: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _connection.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}