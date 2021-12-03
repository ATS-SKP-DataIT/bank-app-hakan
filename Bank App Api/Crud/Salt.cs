using MongoDB.Bson;
using MongoDB.Driver;
using NLog;
using Bank_App_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank_App_Api.Crud
{
    public class SaltCrud
    {

        //logger
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private readonly IMongoCollection<SaltModel> _salt;

        //DB Initialazation, with input saved in launchSettings.json
        public SaltCrud(IDBElements settings)
        {
            try
            {
                var client = new MongoClient(settings.ConnectionString);
                var database = client.GetDatabase(settings.Database);
                _salt = database.GetCollection<SaltModel>("Salt");
            }
            catch (Exception e)
            {
                logger.Error($"Error Code 3.1 - Database connection establishment\n{e.Message}");
                throw new Exception("Error Code 3.1 - Database connection establishment");

            }
        }

        //Get All salt info
        public List<SaltModel> Get() =>
           Task.Run(() => _salt.Find(x => true).ToList()).Result;

        //Get a Specific user salt by Id 
        public SaltModel GetUserById(ObjectId id) =>
           Task.Run(() => _salt.Find(x => x.Id == id).FirstOrDefault()).Result;

        //Add new user salt 
        public string Create(SaltModel salt)
        {
            Task.Run(() =>
            _salt.InsertOne(salt));
            return "";
        }


        //Update existing salt
        public async void Update(ObjectId id, SaltModel salt) =>
           await Task.Run(() =>
           _salt.ReplaceOne(x => x.Id == id, salt));

        //Delete existing salt
        public void Delete(ObjectId id) =>
           Task.Run(() => _salt.DeleteOne(x => x.Id == id));

    }
}
