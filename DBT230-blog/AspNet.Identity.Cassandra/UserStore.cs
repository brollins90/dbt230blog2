using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AspNet.Identity.Cassandra
{
    public class UserStore : IUserStore<IdentityUser>,
                             IUserPasswordStore<IdentityUser>//,
                             //IUserClaimStore<IdentityUser>,
                             //IUserLoginStore<IdentityUser>,
                             //IUserRoleStore<IdentityUser>
    {
        private UserTable userTable;
        //private RoleTable roleTable;
        //private UserRolesTable userRolesTable;
        //private UserClaimsTable userClaimsTable;
        //private UserLoginsTable userLoginsTable;

        public CassandraDatabase Database { get; private set; }

        public UserStore() : this(new CassandraDatabase())
        {

        }

        public UserStore(CassandraDatabase database)
        {
            Database = database;
            userTable = new UserTable(database);
            //roleTable = new RoleTable(database);
            //userRolesTable = new UserRolesTable(database);
            //userClaimsTable = new UserClaimsTable(database);
            //userLoginsTable = new UserLoginsTable(database);
        }

        public Task CreateAsync(IdentityUser user)
        {
            throw new NotImplementedException();
            //if (user == null)
            //{
            //    throw new ArgumentNullException("user");
            //}

            //userTable.Insert(user);

            //return Task.FromResult<object>(null);
        }

        public Task<IdentityUser> FindByIdAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("Null or empty argument: userId");
            }

            IdentityUser result = userTable.GetUserById(userId);
            if (result != null)
            {
                return Task.FromResult<IdentityUser>(result);
            }

            return Task.FromResult<IdentityUser>(null);
        }

        public Task<IdentityUser> FindByNameAsync(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("Null or empty argument: userName");
            }

            List<IdentityUser> result = userTable.GetUserByName(userName);

            // Should I throw if > 1 user?
            if (result != null && result.Count == 1)
            {
                return Task.FromResult<IdentityUser>(result[0]);
            }

            return Task.FromResult<IdentityUser>(null);
        }
        public Task UpdateAsync(IdentityUser user)
        {
            throw new NotImplementedException();
            //if (user == null)
            //{
            //    throw new ArgumentNullException("user");
            //}

            //userTable.Update(user);

            //return Task.FromResult<object>(null);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
            //if (Database != null)
            //{
            //    Database.Dispose();
            //    Database = null;
            //}
        }
        public Task AddClaimAsync(IdentityUser user, Claim claim)
        {
            throw new NotImplementedException();
            //if (user == null)
            //{
            //    throw new ArgumentNullException("user");
            //}

            //if (claim == null)
            //{
            //    throw new ArgumentNullException("user");
            //}

            //userClaimsTable.Insert(claim, user.Id);

            //return Task.FromResult<object>(null);
        }
        public Task<IList<Claim>> GetClaimsAsync(IdentityUser user)
        {
            throw new NotImplementedException();
            //ClaimsIdentity identity = userClaimsTable.FindByUserId(user.Id);

            //return Task.FromResult<IList<Claim>>(identity.Claims.ToList());
        }
        public Task RemoveClaimAsync(IdentityUser user, Claim claim)
        {
            throw new NotImplementedException();
            //if (user == null)
            //{
            //    throw new ArgumentNullException("user");
            //}

            //if (claim == null)
            //{
            //    throw new ArgumentNullException("claim");
            //}

            //userClaimsTable.Delete(user, claim);

            //return Task.FromResult<object>(null);
        }
        public Task AddLoginAsync(IdentityUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
            //if (user == null)
            //{
            //    throw new ArgumentNullException("user");
            //}

            //if (login == null)
            //{
            //    throw new ArgumentNullException("login");
            //}

            //userLoginsTable.Insert(user, login);

            //return Task.FromResult<object>(null);
        }
        public Task<IdentityUser> FindAsync(UserLoginInfo login)
        {
            throw new NotImplementedException();
            //if (login == null)
            //{
            //    throw new ArgumentNullException("login");
            //}

            //var userId = userLoginsTable.FindUserIdByLogin(login);
            //if (userId != null)
            //{
            //    IdentityUser user = userTable.GetUserById(userId);
            //    if (user != null)
            //    {
            //        return Task.FromResult<IdentityUser>(user);
            //    }
            //}

            //return Task.FromResult<IdentityUser>(null);
        }
        public Task<IList<UserLoginInfo>> GetLoginsAsync(IdentityUser user)
        {
            throw new NotImplementedException();
            //List<UserLoginInfo> userLogins = new List<UserLoginInfo>();
            //if (user == null)
            //{
            //    throw new ArgumentNullException("user");
            //}

            //List<UserLoginInfo> logins = userLoginsTable.FindByUserId(user.Id);
            //if (logins != null)
            //{
            //    return Task.FromResult<IList<UserLoginInfo>>(logins);
            //}

            //return Task.FromResult<IList<UserLoginInfo>>(null);
        }
        public Task RemoveLoginAsync(IdentityUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
            //if (user == null)
            //{
            //    throw new ArgumentNullException("user");
            //}

            //if (login == null)
            //{
            //    throw new ArgumentNullException("login");
            //}

            //userLoginsTable.Delete(user, login);

            //return Task.FromResult<Object>(null);
        }
        public Task AddToRoleAsync(IdentityUser user, string roleName)
        {
            throw new NotImplementedException();
            //if (user == null)
            //{
            //    throw new ArgumentNullException("user");
            //}

            //if (string.IsNullOrEmpty(roleName))
            //{
            //    throw new ArgumentException("Argument cannot be null or empty: roleName.");
            //}

            //string roleId = roleTable.GetRoleId(roleName);
            //if (!string.IsNullOrEmpty(roleId))
            //{
            //    userRolesTable.Insert(user, roleId);
            //}

            //return Task.FromResult<object>(null);
        }
        public Task<IList<string>> GetRolesAsync(IdentityUser user)
        {
            throw new NotImplementedException();
            //if (user == null)
            //{
            //    throw new ArgumentNullException("user");
            //}

            //List<string> roles = userRolesTable.FindByUserId(user.Id);
            //{
            //    if (roles != null)
            //    {
            //        return Task.FromResult<IList<string>>(roles);
            //    }
            //}

            //return Task.FromResult<IList<string>>(null);
        }
        public Task<bool> IsInRoleAsync(IdentityUser user, string role)
        {
            throw new NotImplementedException();
            //if (user == null)
            //{
            //    throw new ArgumentNullException("user");
            //}

            //if (string.IsNullOrEmpty(role))
            //{
            //    throw new ArgumentNullException("role");
            //}

            //List<string> roles = userRolesTable.FindByUserId(user.Id);
            //{
            //    if (roles != null && roles.Contains(role))
            //    {
            //        return Task.FromResult<bool>(true);
            //    }
            //}

            //return Task.FromResult<bool>(false);
        }
        public Task RemoveFromRoleAsync(IdentityUser user, string role)
        {
            throw new NotImplementedException();
        }
        public Task DeleteAsync(IdentityUser user)
        {
            throw new NotImplementedException();
            //if (user != null)
            //{
            //    userTable.Delete(user);
            //}

            //return Task.FromResult<Object>(null);
        }
        public Task<string> GetPasswordHashAsync(IdentityUser user)
        {
            //throw new NotImplementedException();
            string passwordHash = userTable.GetPasswordHash(user.Id);

            return Task.FromResult<string>(passwordHash);
        }
        public Task<bool> HasPasswordAsync(IdentityUser user)
        {
            throw new NotImplementedException();
            //var hasPassword = !string.IsNullOrEmpty(userTable.GetPasswordHash(user.Id));

            //return Task.FromResult<bool>(hasPassword);
        }
        public Task SetPasswordHashAsync(IdentityUser user, string passwordHash)
        {
            throw new NotImplementedException();
            //user.PasswordHash = passwordHash;

            //return Task.FromResult<Object>(null);
        }
    }
}
