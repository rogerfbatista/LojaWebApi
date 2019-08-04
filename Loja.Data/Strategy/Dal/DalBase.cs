using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Loja.Data.Strategy.Dal
{


    public abstract class DalBase : IDisposable
    {
        private readonly SqlConnection _connection;

        private readonly SqlCommand _command;

        protected DalBase()
        {
            _connection = new SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["LojaContext"].ConnectionString
            };
            _command = new SqlCommand { CommandType = CommandType.StoredProcedure, Connection = _connection };
            _command.Connection.Open();
        }

        public void AddParametro(string nomeParamento, object valor)
        {
            _command.Parameters.AddWithValue(nomeParamento, valor);
        }

        public async Task AddParametroAsync(string nomeParamento, object valor)
        {
            await Task.Run(() => _command.Parameters.AddWithValue(nomeParamento, valor).Value);
        }


        public SqlDataReader GetLeitor(string procedure)
        {
            _command.CommandText = procedure;
            return _command.ExecuteReader();

        }

        public async Task<SqlDataReader> GetLeitorAsync(string procedure)
        {
            _command.CommandText = procedure;
            return await _command.ExecuteReaderAsync();

        }

        public void ExecuteNonQuery(string procedure)
        {
            _command.CommandText = procedure;
            _command.ExecuteNonQuery();

        }

        public async Task ExecuteNonQueryAsync(string procedure)
        {
            _command.CommandText = procedure;
            await _command.ExecuteNonQueryAsync();

        }

        public object ExecuteNonQueryOutput(string procedure, string parameterOutput)
        {
            _command.CommandText = procedure;
            _command.ExecuteNonQuery();
            return _command.Parameters[parameterOutput].Value;
        }


        public async Task<object> ExecuteNonQueryOutputAsync(string procedure, string parameterOutput)
        {
            _command.CommandText = procedure;
            _command.ExecuteNonQuery();
            return await Task.Run(() => _command.Parameters[parameterOutput].Value);
        }


        public void Dispose()
        {
            _connection.Close();
            _connection.Dispose();
        }
    }
}
