using Bank_APP_Mobile_Dual.Models;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Bank_APP_Mobile_Dual.Helper_Classes.CRUDS
{
    public class LoginsideCrud
    {

        //logger
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        //DB Initialazation, with input saved in launchSettings.json
        private readonly IMongoCollection<LoginModel> _users;
        public LoginsideCrud(IDBSettings settings)
        {
            //   try
            // {
            /*
            using (StreamReader r = new StreamReader(@"C:\Users\Hakan\source\repos\bank-app-hakan\Bank APP Mobile Dual\Bank APP Mobile Dual\appsettings.json"))
            {
                string json = r.ReadToEnd();
                List<DBSettings> items = JsonConvert.DeserializeObject<List<DBSettings>>(json);
            } */
                string currentDir = Directory.GetCurrentDirectory();
                StreamReader r = new StreamReader($@"TextFile1.txt");
                string json = r.ReadToEnd();
                List<DBSettings> items = JsonConvert.DeserializeObject<List<DBSettings>>(json);



                var client = new MongoClient(settings.ConnectionString);
                var database = client.GetDatabase(settings.Database);
                _users = database.GetCollection<LoginModel>(settings.Collection);
     /*       }
            catch (Exception e)
            {
                logger.Error($"Error Code 4.1 - Database connection establishment\n{e.Message}");
                throw new Exception("Error Code 4.1 - Database connection establishment");

            }*/
        }

        //Get all users
        public async Task<List<LoginModel>> Get() =>
            await Task.Run(() =>
            _users.Find(x => true).ToList());

        //Get Specific user by Username (for loging mainly)
        public async Task<LoginModel> GetUser(string username) =>
          await Task.Run(() =>
          _users.Find(x => x.UserName == username).FirstOrDefault());

        //Get Specific user by Email (for loging mainly)
        public async Task<LoginModel> GetUserByEmail(string email) =>
          await Task.Run(() =>
          _users.Find(x => x.Email == email).FirstOrDefault());


        //Get specific user by Id
        public async Task<LoginModel> GetUserById(ObjectId id) =>
           await Task.Run(() =>
           _users.Find(x => x.Id == id).FirstOrDefault());

        //Create new user
        public async Task<LoginModel> Create(LoginModel user)
        {
            await Task.Run(() =>
            _users.InsertOne(user));
            return user;
        }

        //Update existing user
        public async void Update(string username, LoginModel updatedUser) =>
           await Task.Run(() =>
           _users.ReplaceOne(x => x.UserName == username, updatedUser));

        //Delete existing user
        public async void Delete(ObjectId id) =>
           await Task.Run(() =>
           _users.DeleteOne(x => x.Id == id));
    }
}