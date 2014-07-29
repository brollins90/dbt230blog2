using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Web;
using System;
using DBT230_blog.Models;
using System.Threading.Tasks;

namespace DBT230_blog.Models
{
    // You can add User data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    //public class ApplicationUser : IdentityUser
    //{
    //}

    


    //public class BlogRole : IRole
    //{
    //    public BlogRole(string name, string id)
    //    {
    //        _Id = id;
    //        Name = name;
    //    }

    //    private string _Id;
    //    public string Id
    //    {
    //        get { return _Id; }
    //    }

    //    private string _Name;
    //    public string Name
    //    {
    //        get
    //        {
    //            return _Name;
    //        }
    //        set
    //        {
    //            _Name = value;
    //        }
    //    }
    //}

    //public class BlogRoleStore : IRoleStore<BlogRole>
    //{
    //    public System.Threading.Tasks.Task CreateAsync(BlogRole role)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public System.Threading.Tasks.Task DeleteAsync(BlogRole role)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public System.Threading.Tasks.Task<BlogRole> FindByIdAsync(string roleId)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public System.Threading.Tasks.Task<BlogRole> FindByNameAsync(string roleName)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public System.Threading.Tasks.Task UpdateAsync(BlogRole role)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Dispose()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}




    //public class ApplicationDbContext : IdentityDbContext<AspNet.Identity.Cassandra.IdentityUser>
    //{
    //    public ApplicationDbContext() : base("DefaultConnection")
    //    {
    //    }
    //}

    #region Helpers
    public class UserManager : UserManager<AspNet.Identity.Cassandra.IdentityUser>
    {
        public UserManager()
            : base(new AspNet.Identity.Cassandra.UserStore())
        {
            //Store = new AspNet.Identity.Cassandra.UserStore();
            PasswordHasher = new MyPasswordHasher();
        }
    }
}

namespace DBT230_blog
{
    public static class IdentityHelper
    {
        // Used for XSRF when linking external logins
        public const string XsrfKey = "XsrfId";

        public static void SignIn(UserManager manager, AspNet.Identity.Cassandra.IdentityUser user, bool isPersistent)
        {
            IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        public const string ProviderNameKey = "providerName";
        public static string GetProviderNameFromRequest(HttpRequest request)
        {
            return request[ProviderNameKey];
        }

        public static string GetExternalLoginRedirectUrl(string accountProvider)
        {
            return "/Account/RegisterExternalLogin?" + ProviderNameKey + "=" + accountProvider;
        }

        private static bool IsLocalUrl(string url)
        {
            return !string.IsNullOrEmpty(url) && ((url[0] == '/' && (url.Length == 1 || (url[1] != '/' && url[1] != '\\'))) || (url.Length > 1 && url[0] == '~' && url[1] == '/'));
        }

        public static void RedirectToReturnUrl(string returnUrl, HttpResponse response)
        {
            if (!String.IsNullOrEmpty(returnUrl) && IsLocalUrl(returnUrl))
            {
                response.Redirect(returnUrl);
            }
            else
            {
                response.Redirect("~/");
            }
        }
    }
    #endregion
}