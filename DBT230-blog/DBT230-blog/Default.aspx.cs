using Cassandra;
using CassandraBlogStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBT230_blog
{
    public partial class _Default : Page
    {
        public List<string> titles;
        public List<Post> posts { get; set; }
        public CassDB _db { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            _db = new CassDB();



            RowSet res = _db.Execute("SELECT * FROM post");
            posts = new List<Post>();
            foreach (Row r in res)
            {
                posts.Add(Post.FromRow(r));
            }

        }
    }
}