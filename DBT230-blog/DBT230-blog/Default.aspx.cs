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
        protected void Page_Load(object sender, EventArgs e)
        {

            titles = new List<string>();
            titles.Add("title 1");
            titles.Add("title 2");
            titles.Add("title 3");
        }
    }
}