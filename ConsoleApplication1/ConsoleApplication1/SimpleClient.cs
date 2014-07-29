using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class SimpleClient
    {
        private Cluster _cluster;
        private Session _session;

        public Cluster Cluster { get { return _cluster; } }
        public Session Session { get { return _session; } }

        public void Connect(String node)
        {
            _cluster = Cluster.Builder().AddContactPoint(node).Build();
            Metadata metadata = _cluster.Metadata;
            Console.WriteLine("Connected to cluster: {0}", metadata.ClusterName.ToString());
            _session = (Session)_cluster.Connect("simplex");
        }

        public void Close()
        {
            _cluster.Shutdown();
        }

        public void CreatSchema()
        {
            _session.Execute("CREATE KEYSPACE simplex WITH replication = {'class':'SimpleStrategy', 'replication_factor':3};");
            _session.Execute(
      "CREATE TABLE simplex.songs (" +
            "id uuid PRIMARY KEY," +
            "title text," +
            "album text," +
            "artist text," +
            "tags set<text>," +
            "data blob" +
            ");");
            _session.Execute(
                  "CREATE TABLE simplex.playlists (" +
                        "id uuid," +
                        "title text," +
                        "album text, " +
                        "artist text," +
                        "song_id uuid," +
                        "PRIMARY KEY (id, title, album, artist)" +
                        ");");

            _session.Execute(
          "INSERT INTO simplex.songs (id, title, album, artist, tags) " +
          "VALUES (" +
              "756716f7-2e54-4715-9f00-91dcbea6cf50," +
              "'La Petite Tonkinoise'," +
              "'Bye Bye Blackbird'," +
              "'Joséphine Baker'," +
              "{'jazz', '2013'})" +
              ";");
            _session.Execute(
                  "INSERT INTO simplex.playlists (id, song_id, title, album, artist) " +
                  "VALUES (" +
                      "2cc9ccb7-6221-4ccb-8387-f22b6a1b354d," +
                      "756716f7-2e54-4715-9f00-91dcbea6cf50," +
                      "'La Petite Tonkinoise'," +
                      "'Bye Bye Blackbird'," +
                      "'Joséphine Baker'" +
                      ");");
        }

        public void CreateIDSpace()
        {
            _session.Execute("CREATE KEYSPACE blogtest WITH replication = {'class':'SimpleStrategy', 'replication_factor':3};");
            _session.Execute("CREATE TABLE blogtest.users (" +
            "id uuid," +
            "username text," +
            "passwordhash text," +
            "securitystamp text," +
            "PRIMARY KEY(id)" +
            ");");

            _session.Execute("CREATE TABLE blogtest.roles (" +
            "id uuid," +
            "name text," +
            "PRIMARY KEY(id)" +
            ");");

            _session.Execute("CREATE TABLE blogtest.userclaims (" +
            "id uuid," +
            "userid uuid," +
            "claimtype text," +
            "claimvalue text," +
            "PRIMARY KEY(id)" +
            ");");

            _session.Execute("CREATE TABLE blogtest.userlogins (" +
            "userid uuid," +
            "providerkey text," +
            "loginprovider text," +
            "PRIMARY KEY(userid)" +
            ");");

            _session.Execute("CREATE TABLE blogtest.userroles (" +
            "userid uuid," +
            "roleid uuid," +
            "PRIMARY KEY(userid, roleid)" +
            ");");

          //  _session.Execute(
          //"INSERT INTO simplex.songs (id, title, album, artist, tags) " +
          //"VALUES (" +
          //    "756716f7-2e54-4715-9f00-91dcbea6cf50," +
          //    "'La Petite Tonkinoise'," +
          //    "'Bye Bye Blackbird'," +
          //    "'Joséphine Baker'," +
          //    "{'jazz', '2013'})" +
          //    ";");
          //  _session.Execute(
          //        "INSERT INTO simplex.playlists (id, song_id, title, album, artist) " +
          //        "VALUES (" +
          //            "2cc9ccb7-6221-4ccb-8387-f22b6a1b354d," +
          //            "756716f7-2e54-4715-9f00-91dcbea6cf50," +
          //            "'La Petite Tonkinoise'," +
          //            "'Bye Bye Blackbird'," +
          //            "'Joséphine Baker'" +
          //            ");");
        }

        public virtual void LoadData() {
        }

        public void QuerySchema()
        {
            RowSet results = _session.Execute("SELECT * FROM playlists " +
        "WHERE id = 2cc9ccb7-6221-4ccb-8387-f22b6a1b354d;");
            Console.WriteLine(String.Format("{0, -30}\t{1, -20}\t{2, -20}\t{3, -30}",
        "title", "album", "artist", "tags"));
            Console.WriteLine("-------------------------------+-----------------------+--------------------+-------------------------------");
            foreach (Row row in results.GetRows())
            {
                Console.WriteLine(row.ToString());
               // Console.WriteLine(String.Format("{0, -30}\t{1, -20}\t{2, -20}\t{3}",
                        //row.GetValue<String>("title"), row.GetValue<String>("album"),
                        //row.GetValue<String>("artist"), row.GetValue<List<String>>("tags").ToString()));
            }
        }


    }
}
