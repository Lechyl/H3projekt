using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
   public static class Role
    {
        public const string Admin = "Admin";
        public const string User = "User";
        public const string AdminOrUser = Admin + ", " + User;
    }
}
