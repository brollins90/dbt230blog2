﻿using Microsoft.AspNet.Identity;
using System;

namespace AspNet.Identity.Cassandra
{
    public class IdentityUser : IUser
    {
        public IdentityUser()
        {
            Id = Guid.NewGuid().ToString();
        }
        public IdentityUser(string userName)
            : this()
        {
            UserName = userName;
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }

    }
}
