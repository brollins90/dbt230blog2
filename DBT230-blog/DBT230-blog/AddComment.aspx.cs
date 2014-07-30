using CassandraBlogStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBT230_blog
{
    public partial class AddComment : Page
    {
         public CassDB _db {get; set;}

        protected void Page_Load(object sender, EventArgs e)
        {
            _db = new CassDB();
            if (!IsPostBack)
            {

            }
            else
            {
                string postTitle = Request.Form["title"];
                string postContent = Request.Form["content"];
                _db.CreateComment(postContent, Context.User.Identity.Name);
                Response.Redirect("/");
            }

        }
    }
}