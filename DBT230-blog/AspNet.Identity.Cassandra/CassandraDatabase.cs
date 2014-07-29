using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;

namespace AspNet.Identity.Cassandra
{
    public class CassandraDatabase : IDisposable
    {
        private Cluster _cluster;
        private Session _session;
        //private MySqlConnection _connection;

        public CassandraDatabase() : this("eb-cas.cloudapp.net", "abc")
        {
        }

        public CassandraDatabase(string node, string keyspace)
        {
            _cluster = Cluster.Builder().AddContactPoint(node).Build();
            Metadata metadata = _cluster.Metadata;
            //Console.WriteLine("Connected to cluster: {0}", metadata.ClusterName.ToString());
            _session = (Session)_cluster.Connect(keyspace);

            //string connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            //_connection = new MySqlConnection(connectionString);
        }

        public RowSet Execute(string cqlQuery)
        {
            RowSet result = null;

            if (String.IsNullOrEmpty(cqlQuery))
            {
                throw new ArgumentException("cqlQuery cannot be null or empty.");
            }

            //try
            //{
                EnsureConnectionOpen();
                return _session.Execute(cqlQuery);
            //}
            //finally
            //{
            //    _session.Dispose();
            //    _cluster.Dispose();
            //}

            return result;
        }

        //public object QueryValue(string commandText, Dictionary<string, object> parameters)
        //{
        //    object result = null;

        //    if (String.IsNullOrEmpty(commandText))
        //    {
        //        throw new ArgumentException("Command text cannot be null or empty.");
        //    }

        //    try
        //    {
        //        EnsureConnectionOpen();
        //        var command = CreateCommand(commandText, parameters);
        //        result = command.ExecuteScalar();
        //    }
        //    finally
        //    {
        //        EnsureConnectionClosed();
        //    }

        //    return result;
        //}

        //public List<Dictionary<string, string>> Query(string commandText, Dictionary<string, object> parameters)
        //{
        //    List<Dictionary<string, string>> rows = null;
        //    if (String.IsNullOrEmpty(commandText))
        //    {
        //        throw new ArgumentException("Command text cannot be null or empty.");
        //    }

        //    try
        //    {
        //        EnsureConnectionOpen();
        //        var command = CreateCommand(commandText, parameters);
        //        using (MySqlDataReader reader = command.ExecuteReader())
        //        {
        //            rows = new List<Dictionary<string, string>>();
        //            while (reader.Read())
        //            {
        //                var row = new Dictionary<string, string>();
        //                for (var i = 0; i < reader.FieldCount; i++)
        //                {
        //                    var columnName = reader.GetName(i);
        //                    var columnValue = reader.IsDBNull(i) ? null : reader.GetString(i);
        //                    row.Add(columnName, columnValue);
        //                }
        //                rows.Add(row);
        //            }
        //        }
        //    }
        //    finally
        //    {
        //        EnsureConnectionClosed();
        //    }

        //    return rows;
        //}

        private void EnsureConnectionOpen()
        {
            //return _session != null;

            //var retries = 3;
            //if (_connection.State == ConnectionState.Open)
            //{
            //    return;
            //}
            //else
            //{
            //    while (retries >= 0 && _connection.State != ConnectionState.Open)
            //    {
            //        _connection.Open();
            //        retries--;
            //        Thread.Sleep(30);
            //    }
            //}
        }

        public void EnsureConnectionClosed()
        {
            if (_session != null)
                _session.Dispose();

            //if (_connection.State == ConnectionState.Open)
            //{
            //    _connection.Close();
            //}
        }

        //private MySqlCommand CreateCommand(string commandText, Dictionary<string, object> parameters)
        //{
        //    MySqlCommand command = _connection.CreateCommand();
        //    command.CommandText = commandText;
        //    AddParameters(command, parameters);

        //    return command;
        //}

        //private static void AddParameters(MySqlCommand command, Dictionary<string, object> parameters)
        //{
        //    if (parameters == null)
        //    {
        //        return;
        //    }

        //    foreach (var param in parameters)
        //    {
        //        var parameter = command.CreateParameter();
        //        parameter.ParameterName = param.Key;
        //        parameter.Value = param.Value ?? DBNull.Value;
        //        command.Parameters.Add(parameter);
        //    }
        //}
        public string GetStrValue(string cqlQuery, string columnName)
        {
            RowSet rows = Execute(cqlQuery);
            foreach (Row row in rows.GetRows())
            {
                return row.GetValue<string>(columnName);
            }
            return null;
        }

        public void Dispose()
        {
            if (_session != null)
            {
                _session.Dispose();
                _session = null;
            }
            if (_cluster != null)
            {
                _cluster.Dispose();
                _cluster = null;
            }
        }

    }
}
