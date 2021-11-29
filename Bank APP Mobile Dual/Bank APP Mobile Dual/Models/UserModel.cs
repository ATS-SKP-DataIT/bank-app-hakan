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

    public class LoginModel : ILoginModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
        public List<string> Recovery { get; set; }

    }
    public interface ILoginModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        ObjectId Id { get; set; }
        string UserName { get; set; }
        string Email { get; set; }

        string Password { get; set; }
        List<string> Recovery { get; set; }
    }


}
