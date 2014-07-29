//using Microsoft.AspNet.Identity;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Web;

//namespace DBT230_blog.Models
//{

//    public class BlogUserStore : IUserStore<BlogUser>, IUserPasswordStore<BlogUser>//, IUserClaimStore<BlogUser>, IUserLoginStore<BlogUser>, IUserRoleStore<BlogUser>
//    {
//        public List<BlogUser> myusers;

//        public BlogUserStore()
//        {

//            myusers = new List<BlogUser>
//            {
//                new BlogUser("user1", "id1") { PasswordHash = "a" },
//                new BlogUser("user2", "id2") { PasswordHash = "a" }
//            };
//        }


//        public System.Threading.Tasks.Task CreateAsync(BlogUser user)
//        {
//            //user.Id = ObjectId.GenerateNewId();
//            //_db.Users.Insert(user);
//            //return Task.FromResult(0);
//            myusers.Add(user);
//            throw new NotImplementedException();
//        }

//        public System.Threading.Tasks.Task DeleteAsync(BlogUser user)
//        {
//            throw new NotImplementedException();
//        }

//        public System.Threading.Tasks.Task<BlogUser> FindByIdAsync(string userId)
//        {
//            return Task.FromResult(myusers.SingleOrDefault(u => u.Id == userId));
//        }

//        public System.Threading.Tasks.Task<BlogUser> FindByNameAsync(string userName)
//        {
//            return Task.FromResult(myusers.SingleOrDefault(u => u.UserName == userName));
//        }

//        public System.Threading.Tasks.Task UpdateAsync(BlogUser user)
//        {
//            throw new NotImplementedException();
//        }

//        public void Dispose()
//        {
//            throw new NotImplementedException();
//        }

//        public System.Threading.Tasks.Task AddClaimAsync(BlogUser user, System.Security.Claims.Claim claim)
//        {
//            throw new NotImplementedException();
//        }

//        public System.Threading.Tasks.Task<System.Collections.Generic.IList<System.Security.Claims.Claim>> GetClaimsAsync(BlogUser user)
//        {
//            throw new NotImplementedException();
//        }

//        public System.Threading.Tasks.Task RemoveClaimAsync(BlogUser user, System.Security.Claims.Claim claim)
//        {
//            throw new NotImplementedException();
//        }

//        public System.Threading.Tasks.Task AddLoginAsync(BlogUser user, UserLoginInfo login)
//        {
//            throw new NotImplementedException();
//        }

//        public System.Threading.Tasks.Task<BlogUser> FindAsync(UserLoginInfo login)
//        {
//            throw new NotImplementedException();
//        }

//        public System.Threading.Tasks.Task<System.Collections.Generic.IList<UserLoginInfo>> GetLoginsAsync(BlogUser user)
//        {
//            throw new NotImplementedException();
//        }

//        public System.Threading.Tasks.Task RemoveLoginAsync(BlogUser user, UserLoginInfo login)
//        {
//            throw new NotImplementedException();
//        }

//        public System.Threading.Tasks.Task AddToRoleAsync(BlogUser user, string role)
//        {
//            throw new NotImplementedException();
//        }

//        public System.Threading.Tasks.Task<System.Collections.Generic.IList<string>> GetRolesAsync(BlogUser user)
//        {
//            throw new NotImplementedException();
//        }

//        public System.Threading.Tasks.Task<bool> IsInRoleAsync(BlogUser user, string role)
//        {
//            throw new NotImplementedException();
//        }

//        public System.Threading.Tasks.Task RemoveFromRoleAsync(BlogUser user, string role)
//        {
//            throw new NotImplementedException();
//        }

//        public System.Threading.Tasks.Task<string> GetPasswordHashAsync(BlogUser user)
//        {
//            return Task.FromResult(myusers.SingleOrDefault(u => u.UserName == user.UserName).PasswordHash);
//        }

//        public System.Threading.Tasks.Task<bool> HasPasswordAsync(BlogUser user)
//        {
//            throw new NotImplementedException();
//        }

//        public System.Threading.Tasks.Task SetPasswordHashAsync(BlogUser user, string passwordHash)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}