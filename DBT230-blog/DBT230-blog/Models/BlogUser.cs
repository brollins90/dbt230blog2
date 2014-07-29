//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
//using Microsoft.Owin.Security;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;


//namespace DBT230_blog.Models
//{
//    public class BlogUser : IUser
//    {
//        public BlogUser()
//        {
            
//        }
//        public BlogUser(string username, string id)
//        {
//            _Id = id;
//            UserName = username;
//        }

//        private string _Id;
//        public string Id
//        {
//            get { return _Id; }
//        }

//        private string _UserName;
//        public string UserName
//        {
//            get
//            {
//                return _UserName;
//            }
//            set
//            {
//                _UserName = value;
//            }
//        }

//        public string PasswordHash { get; set; }
//    }
//}