using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;

namespace CassandraBlogStuff
{
    public class CassDB : IDisposable
    {
        private Cluster _cluster;
        private Session _session;

        public CassDB() : this("eb-cas.cloudapp.net", "abc")
        {
        }

        public CassDB(string node, string keyspace)
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
        private void EnsureConnectionOpen()
        {
        }
        public void EnsureConnectionClosed()
        {
            if (_session != null)
                _session.Dispose();
        }
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

        public void CreatePost(string postTitle, string postContent, string username)
        {
            throw new NotImplementedException();
        }
    }
}
