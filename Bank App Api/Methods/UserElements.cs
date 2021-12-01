using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank_App_Api.Methods
{
    public class UserElements
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

