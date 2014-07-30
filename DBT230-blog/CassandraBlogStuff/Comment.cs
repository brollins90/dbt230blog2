using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassandraBlogStuff
{
    class Comment
    {
        public Guid commentid { get; set; }
        public string content { get; set; }
        public string poster { get; set; }
        public DateTimeOffset posttime { get; set; }

        public static Comment FromRow(Row r)
        {
            if (r != null)
            {
                Comment p = new Comment()
                {
                    commentid = r.GetValue<Guid>("commentid"),
                    content = (string.IsNullOrEmpty(r.GetValue<string>("content"))) ? null : r.GetValue<string>("content"),
                    poster = (string.IsNullOrEmpty(r.GetValue<string>("poster"))) ? null : r.GetValue<string>("poster"),
                    posttime = r.GetValue<DateTimeOffset>("posttime")
                };
                return p;
            }
            return null;
        }
        public override string ToString()
        {
            return string.Format("{0} <br/> -- {1}({2})", content, poster, posttime);
        }
    }
}
