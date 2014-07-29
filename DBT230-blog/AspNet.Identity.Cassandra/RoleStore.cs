//using Microsoft.AspNet.Identity;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Claims;
//using System.Threading.Tasks;

//namespace AspNet.Identity.Cassandra
//{
//    public class RoleStore : IRoleStore<IdentityUser>
//    {
//        private RoleTable roleTable;
//        public MySQLDatabase Database { get; private set; }
//        public RoleStore()
//        {
//            new RoleStore(new MySQLDatabase());
//        }
//        public RoleStore(MySQLDatabase database)
//        {
//            Database = database;
//            roleTable = new RoleTable(database);
//        }
//        public Task CreateAsync(IdentityRole role)
//        {
//            if (role == null)
//            {
//                throw new ArgumentNullException("role");
//            }

//            roleTable.Insert(role);

//            return Task.FromResult<object>(null);
//        }
//        public Task DeleteAsync(IdentityRole role)
//        {
//            if (role == null)
//            {
//                throw new ArgumentNullException("user");
//            }

//            roleTable.Delete(role.Id);

//            return Task.FromResult<Object>(null);
//        }

//        public Task<IdentityRole> FindByIdAsync(string roleId)
//        {
//            IdentityRole result = roleTable.GetRoleById(roleId);

//            return Task.FromResult<IdentityRole>(result);
//        }

//        public Task<IdentityRole> FindByNameAsync(string roleName)
//        {
//            IdentityRole result = roleTable.GetRoleByName(roleName);

//            return Task.FromResult<IdentityRole>(result);
//        }

//        public Task UpdateAsync(IdentityRole role)
//        {
//            if (role == null)
//            {
//                throw new ArgumentNullException("user");
//            }

//            roleTable.Update(role);

//            return Task.FromResult<Object>(null);
//        }

//        public void Dispose()
//        {
//            if (Database != null)
//            {
//                Database.Dispose();
//                Database = null;
//            }
//        }
//    }
//}
