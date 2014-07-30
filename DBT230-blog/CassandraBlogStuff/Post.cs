using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassandraBlogStuff
{
    public class Post
    {
        public Guid postid { get; set; }
        public string content { get; set; }
        public string poster { get; set; }
        public DateTimeOffset posttime { get; set; }
        public string posttitle { get; set; }

        public static Post FromRow(Row r)
        {
            if (r != null)
            {
                Post p = new Post()
                {
                    postid = r.GetValue<Guid>("postid"),
                    content = (string.IsNullOrEmpty(r.GetValue<string>("content"))) ? null : r.GetValue<string>("content"),
                    poster = (string.IsNullOrEmpty(r.GetValue<string>("poster"))) ? null : r.GetValue<string>("poster"),
                    posttime = r.GetValue<DateTimeOffset>("posttime"),
                    posttitle = (string.IsNullOrEmpty(r.GetValue<string>("posttitle"))) ? null : r.GetValue<string>("posttitle"),
                };
                return p;
            }
            return null;
        }
        public override string ToString()
        {
            if (content.Length < 35)
            {
                return string.Format("{0} {1}", posttitle + "<br/>", content);
            }
            return string.Format("{0} {1}", posttitle + "<br/>", content.Substring(0,35) + "...");
        }
    }
}
