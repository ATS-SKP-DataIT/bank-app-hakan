using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank_APP_Mobile_Dual.Models
{
    public class UserModel
    {
    }
    public class APILoginModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
    }

    public class CreateUserModel
    {
        public CreateUserModel(string email, string userName, string firstName, string lastName, string password)
        {
            Email = email;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
        }

        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }


}
