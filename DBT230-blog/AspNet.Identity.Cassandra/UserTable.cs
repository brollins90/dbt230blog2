using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Identity.Cassandra
{
    public class UserTable
    {
        private CassandraDatabase _database;

        public UserTable(CassandraDatabase database)
        {
            _database = database;
        }

        public string GetUserName(string userId)
        {
            string commandText = string.Format("SELECT username FROM user WHERE userid = {0};", userId);
            return _database.GetStrValue(commandText, "username");
        }

        public string GetUserId(string userName)
        {
            string commandText = string.Format("SELECT userid FROM user WHERE username = '{0}';", userName);
            return _database.GetStrValue(commandText, "userid");
        }

        public IdentityUser GetUserById(string userId)
        {
            IdentityUser user = null;
            string commandText = string.Format("SELECT * FROM user WHERE userid = {0};", userId);

            RowSet rows = _database.Execute(commandText);
            foreach (Row row in rows.GetRows())
            {
                user = new IdentityUser();
                user.Id = row.GetValue<String>("userid");
                user.UserName = row.GetValue<String>("username");
                user.PasswordHash = string.IsNullOrEmpty(row.GetValue<String>("password")) ? null : row.GetValue<String>("PasswordHash");
                user.SecurityStamp = null;// string.IsNullOrEmpty(row.GetValue<String>("SecurityStamp")) ? null : row.GetValue<String>("SecurityStamp");

                return user;
            }
            return user;

        }

        public List<IdentityUser> GetUserByName(string userName)
        {
            List<IdentityUser> users = new List<IdentityUser>();
            string commandText = string.Format("SELECT * FROM user WHERE username = '{0}';", userName);

            RowSet rows = _database.Execute(commandText);
            foreach (Row row in rows.GetRows())
            {
                IdentityUser user = new IdentityUser();
                user.Id = row.GetValue<System.Guid>("userid").ToString();
                user.UserName = row.GetValue<String>("username");
                user.PasswordHash = string.IsNullOrEmpty(row.GetValue<String>("password")) ? null : row.GetValue<String>("password");
                user.SecurityStamp = null;// string.IsNullOrEmpty(row.GetValue<String>("SecurityStamp")) ? null : row.GetValue<String>("SecurityStamp");
                users.Add(user);
            }

            return users;
        }

        public string GetPasswordHash(string userId)
        {
            string commandText = string.Format("SELECT password FROM user WHERE userid = {0};", userId);
            return _database.GetStrValue(commandText, "password");
        }

        //public int SetPasswordHash(string userId, string passwordHash)
        //{
        //    string commandText = "Update Users set PasswordHash = @pwdHash where Id = @id";
        //    Dictionary<string, object> parameters = new Dictionary<string, object>();
        //    parameters.Add("@pwdHash", passwordHash);
        //    parameters.Add("@id", userId);

        //    return _database.Execute(commandText, parameters);
        //}

        public string GetSecurityStamp(string userId)
        {
            string commandText = string.Format("SELECT securitystamp FROM user WHERE userid = {0};", userId);
            return _database.GetStrValue(commandText, "securitystamp");
        }

        //public int Insert(IdentityUser user)
        //{
        //    string commandText = "Insert into Users (UserName, Id, PasswordHash, SecurityStamp) values (@name, @id, @pwdHash, @SecStamp)";
        //    Dictionary<string, object> parameters = new Dictionary<string, object>();
        //    parameters.Add("@name", user.UserName);
        //    parameters.Add("@id", user.Id);
        //    parameters.Add("@pwdHash", user.PasswordHash);
        //    parameters.Add("@SecStamp", user.SecurityStamp);

        //    return _database.Execute(commandText, parameters);
        //}
        //private int Delete(string userId)
        //{
        //    string commandText = "Delete from Users where Id = @userId";
        //    Dictionary<string, object> parameters = new Dictionary<string, object>();
        //    parameters.Add("@userId", userId);

        //    return _database.Execute(commandText, parameters);
        //}
        //public int Delete(IdentityUser user)
        //{
        //    return Delete(user.Id);
        //}
        //public int Update(IdentityUser user)
        //{
        //    string commandText = "Update Users set UserName = @userName, PasswordHash = @pswHash, SecurityStamp = @secStamp WHERE Id = @userId";
        //    Dictionary<string, object> parameters = new Dictionary<string, object>();
        //    parameters.Add("@userName", user.UserName);
        //    parameters.Add("@pswHash", user.PasswordHash);
        //    parameters.Add("@secStamp", user.SecurityStamp);
        //    parameters.Add("@userId", user.Id);

        //    return _database.Execute(commandText, parameters);
        //}
    }
}
