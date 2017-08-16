using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlHelper
{
    public class SqlHelper
    {
        private static IDbConnection _connection;
        private static IDbCommand _command;
        private static IDbTransaction _transaction;

        public SqlHelper(DbType dbType)
        {
            _connection = DBFactory.CreateDbConnection(dbType,
                ConfigHelper.ConnectionString);
            _command = DBFactory.CreateDbCommand(dbType);
        }

        private void OpenConnection()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        private void CloseConnection()
        {
            if (_connection.State != ConnectionState.Closed)
            {
                _connection.Close();
            }
        }

        public DataTable ExecuteReader(string sql)
        {
            OpenConnection();
            _command=_connection.CreateCommand();
            _command.CommandText = sql;
            var dr = _command.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            return dt;
        }
    }
}