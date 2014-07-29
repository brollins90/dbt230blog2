using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DBT230_blog.Startup))]
namespace DBT230_blog
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
