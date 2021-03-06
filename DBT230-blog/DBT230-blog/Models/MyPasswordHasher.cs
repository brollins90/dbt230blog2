﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBT230_blog.Models
{
    public class MyPasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return password;
        }

        public PasswordVerificationResult VerifyHashedPassword
                      (string hashedPassword, string providedPassword)
        {
            if (hashedPassword == HashPassword(providedPassword))
                return PasswordVerificationResult.Success;
            else
                return PasswordVerificationResult.Failed;
        }
    }
}