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
            // write a cql statement that will INSERT a new post
            string cql = string.Format("insert into post (postid, posttitle, content, poster, posttime) values (now(), '" + postTitle + "', '" + postContent + "', '" + username + "', '" + Environment.TickCount + "');");

            Execute(cql);
        }


        public void CreateComment(string postContent, string username, string postid)
        {
            // write a cql statement that will INSERT a new comment
            string cql = string.Format("insert into comment (commentid, content, poster, posttime, postid) values (now(), '" + postContent + "', '" + username + "', '" + Environment.TickCount + "', " + postid + ");");

            Execute(cql);
        }

        public List<Comment> GetCommentsByID(string value)
        {
            string cql = "SELECT * FROM comment WHERE postid = " + value;
            List<Comment> commentsList = new List<Comment>();

            RowSet res = Execute(cql);
            foreach (Row r in res.GetRows())
            {
                commentsList.Add(Comment.FromRow(r));
            }
            return commentsList;
        }

        public Post GetPostByID(string value)
        {
            string cql = "SELECT * FROM post WHERE postid = " + value;

            RowSet res = Execute(cql);
            foreach (Row r in res.GetRows())
            {
                return Post.FromRow(r);
            }
            return null;
        }

        public void CreateC(string postTitle, string postContent, string p)
        {
            throw new NotImplementedException();
        }
    }
}
