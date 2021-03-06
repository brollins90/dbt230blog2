﻿using CassandraBlogStuff;
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
        public List<Comment> comments { get; set; }
        public CassDB _db { get; set; }
        public Post daPost { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            _db = new CassDB();
            comments = new List<Comment>();
            string value = Request.QueryString["Id"];
            value = (string.IsNullOrEmpty(value)) ? "afb1d270-1795-11e4-92ad-bf26edef3f23" : value;

            daPost = _db.GetPostByID(value);

            comments = _db.GetCommentsByID(value);

            comments = comments.OrderByDescending(c => c.posttime).ToList();


        }

        protected void editPostButton_Click(object sender, EventArgs e)
        {

        }
    }
}