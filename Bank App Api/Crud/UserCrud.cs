using MongoDB.Bson;
using MongoDB.Driver;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank_App_Api.Models;

namespace Bank_App_Api.Crud
{
    public class UserCrud
    {

        //logger
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        //DB Initialazation, with input saved in launchSettings.json
        private readonly IMongoCollection<UserModel> _users;
        public UserCrud(IDBElements settings)
        {
            try
            {
                var client = new MongoClient(settings.ConnectionString);
                var database = client.GetDatabase(settings.Database);
                _users = database.GetCollection<UserModel>("User");
            }
            catch (Exception e)
            {
                logger.Error($"Error Code 4.1 - Database connection establishment\n{e.Message}");
                throw new Exception("Error Code 4.1 - Database connection establishment");

            }
        }

        //Get all users
        public async Task<List<UserModel>> Get() =>
            await Task.Run(() =>
            _users.Find(x => true).ToList());

        //Get Specific user by Username (for loging mainly)
        public async Task<UserModel> GetUser(string username) =>
          await Task.Run(() =>
          _users.Find(x => x.UserName == username).FirstOrDefault());

        //Get Specific user by Email (for loging mainly)
        public async Task<UserModel> GetUserByEmail(string email) =>
          await Task.Run(() =>
          _users.Find(x => x.Email == email).FirstOrDefault());


        //Get specific user by Id
        public async Task<UserModel> GetUserById(ObjectId id) =>
           await Task.Run(() =>
           _users.Find(x => x.Id == id).FirstOrDefault());

        //Create new user
        public async Task<UserModel> Create(UserModel user)
        {
            await Task.Run(() =>
            _users.InsertOne(user));
            return user;
        }

        //Update existing user
        public async void Update(string username, UserModel updatedUser) =>
           await Task.Run(() =>
           _users.ReplaceOne(x => x.UserName == username, updatedUser));

        //Delete existing user
        public async void Delete(ObjectId id) =>
           await Task.Run(() =>
           _users.DeleteOne(x => x.Id == id));
    }
}