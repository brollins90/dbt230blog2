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
                string value = Request.QueryString["Id"];
                value = (string.IsNullOrEmpty(value)) ? "a7e98090-1783-11e4-92ad-bf26edef3f23" : value;
                _db.CreateComment(postContent, Context.User.Identity.Name, value);
                Response.Redirect("/");
            }

        }
    }
}