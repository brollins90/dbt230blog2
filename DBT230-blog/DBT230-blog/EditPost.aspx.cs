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
    public partial class EditPost : Page
    {
         public CassDB _db {get; set;}
         public Post daPost { get; set; }

        protected void Page_Load(object sender, EventArgs e)
         {
             if (string.IsNullOrEmpty(Context.User.Identity.Name))
             {
                 Response.Redirect("/");
             }

            _db = new CassDB();
            if (!IsPostBack)
            {
                string value = Request.QueryString["Id"];
                value = (string.IsNullOrEmpty(value)) ? "afb1d270-1795-11e4-92ad-bf26edef3f23" : value;

                daPost = _db.GetPostByID(value);
                title.InnerHtml = daPost.posttitle;
                content.InnerHtml = daPost.content;
                posttime.InnerHtml = daPost.posttime.Ticks.ToString();
            }
            else
            {
                string id = Request.QueryString["Id"];
                string postTitle = title.InnerHtml;// Request.Form["title"];
                string postContent = content.InnerHtml;// Request.Form["content"];
                string timestring = posttime.InnerHtml;// Request.Form["posttime"];
                _db.UpdatePost(postTitle, postContent, id, timestring);
                Response.Redirect("/");
            }

        }
    }
}