using CassandraBlogStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBT230_blog
{
    public partial class P : Page
    {

        public CassDB _db { get; set; }
        public Post daPost { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            _db = new CassDB();
            string value = Request.QueryString["Id"];
            value = (string.IsNullOrEmpty(value)) ? "a7e98090-1783-11e4-92ad-bf26edef3f23" : value;

            daPost = _db.GetPostByID(value);





        }
    }
}