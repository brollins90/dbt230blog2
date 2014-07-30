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
    public partial class AddPost : Page
    {
         public CassDB _db {get; set;}

        protected void Page_Load(object sender, EventArgs e)
         {
             if (string.IsNullOrEmpty(Context.User.Identity.Name))
             {
                 Response.Redirect("/");
             }

            _db = new CassDB();
            if (!IsPostBack)
            {

            }
            else
            {
                string postTitle = Request.Form["title"];
                string postContent = Request.Form["content"];
                //string tempContent = postContent.Replace("\n", "<br/>");
                _db.CreatePost(postTitle, postContent, Context.User.Identity.Name);
                Response.Redirect("/");
            }

        }
    }
}