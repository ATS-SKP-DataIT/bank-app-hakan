﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Newtonsoft.Json;
using Bank_App_Api.Crud;
using Bank_App_Api.Models;

using static Bank_App_Api.Helper_Classes.RecoveryKeyGen;
using static Bank_App_Api.Helper_Classes.Salting;
using System.Net.Http;
using System.Net.Http.Headers;
using Bank_App_Api.Helper_Classes;
using System.Text;

namespace Bank_App_Api.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserCrud _users;
        private readonly LoginCrud _login;
        private readonly SaltCrud _salt;

        public UserController(UserCrud users, LoginCrud login, SaltCrud salt)
        {
            _users = users;
            _login = login;
            _salt = salt;
        }
        

        //Get all users
        [HttpGet]
         public ActionResult<List<UserModel>> Get() =>
           _users.Get().Result;

        [HttpGet("{username}")]
        public ActionResult Get(string username) =>
           Ok(_users.GetUser(username).Result);

        /*
        //Create
        [HttpPost]
        public ActionResult Create([FromBody] JsonElement EncryptedMsg)
        {
            try
            {
                //Checking if user already exits by username or email

                //Converts from bytes and enables it into the req model
                var ApiReqModelEnc = JsonConvert.DeserializeObject<APIReqModel>(EncryptedMsg.GetString());
                
                //Standard salt for user creation only
                var salt = "13334448853"; 

                //Matches requirements for tokenid + creation info
                if (ApiReqModelEnc.Token != "1666723Dx" && ApiReqModelEnc.Username != "UserCreationTemp563") 
                    return BadRequest();

                //Decrypts the json
                var crypt = new Crypt();
                var stringConvertedDeC = Convert.ToBase64String( crypt.Decrypter(ApiReqModelEnc.Json, salt));
                var user = JsonConvert.DeserializeObject<NewUserModel>(stringConvertedDeC);

                var matchUserName = _users.GetUser(user.UserName).Result;
                if (matchUserName != null || _users.GetUserByEmail(user.Email).Result != null)
                {
                    if (matchUserName != null)
                        return BadRequest("UserName already exists!");
                    else
                    {
                        return BadRequest("Email already exists!");
                    }
                }
                var recoveryCodes = GenerateRecovery();

                _users.Create(new UserModel
                {
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    UserType = user.UserType,
                }).Wait();

                var id = _users.GetUserByEmail(user.Email).Result.Id;
                var hash = HashSalt(user.Password, null);

                _login.Create(new LoginModel { Id = id, UserName = user.UserName, Email = user.Email, Password = hash.Pass, Recovery = recoveryCodes.HashKey });
                Task.Run(() => _salt.Create(new SaltModel(id, Convert.ToBase64String(GenerateSalt()), hash.Salt, recoveryCodes.SaltKey)));
                Task.WaitAll();
                return Ok(new APIReqModel { Json = string.Join(",", recoveryCodes.Key.ToArray()) });
            }
            catch
            {
                //  return BadRequest();
                throw new Exception("Error code 3.2 - UserController Post Create user error");
            }
        }

        */
        //Create
        [HttpPost]
        public ActionResult Create([FromBody] JsonElement jsUser)
        {
            try
            {

                var testing = 
                    Encoding.Unicode.GetString(
                        Convert.FromBase64String(
                            JsonConvert.DeserializeObject<EncAPIReqModel>(
                                jsUser.GetRawText()).Json));

                //Checking if user already exits by username or email
              //  var APIReq = JsonConvert.DeserializeObject<APIReqModel>(jsUser.GetRawText());
                var APIReq = JsonConvert.DeserializeObject<APIReqModel>(testing);

                var accessCode = Encoding.UTF8.GetString(APIReq.Username);
                if (APIReq.Token != "1666723Dx" && accessCode != "UserCreationTemp563")
                    return BadRequest();

                Crypt crypt = new Crypt();
                var decryptedJson = Encoding.UTF8.GetString(crypt.Decrypter(APIReq.Json, "13334448853"));
                var decryptedUser = JsonConvert.DeserializeObject<NewUserModel>(decryptedJson);
                var test = _users.GetUser(decryptedUser.UserName).Result;
                if ( test != null)
                        return BadRequest("UserName already exists!");

                if (_users.GetUserByEmail(decryptedUser.Email).Result != null) 
                        return BadRequest("Email already exists!");
                
                var recoveryCodes = GenerateRecovery();

                _users.Create(new UserModel
                {
                    UserName = decryptedUser.UserName,
                    FirstName = decryptedUser.FirstName,
                    LastName = decryptedUser.LastName,
                    Email = decryptedUser.Email,
                    UserType = decryptedUser.UserType,
                }).Wait();
                
                var id = _users.GetUserByEmail(decryptedUser.Email).Result.Id;
                var hash = HashSalt(decryptedUser.Password, null);

                _login.Create(new LoginModel { Id = id, UserName = decryptedUser.UserName, Email = decryptedUser.Email, Password = hash.Pass, Recovery = recoveryCodes.HashKey });
                Task.Run(() => _salt.Create(new SaltModel(id, Convert.ToBase64String(GenerateSalt()), hash.Salt, recoveryCodes.SaltKey)));
                Task.WaitAll();
                return Ok(new APIReqModel { Json = string.Join(",", recoveryCodes.Key.ToArray()) });
              //  return Ok();
            }
            catch
            {
                //  return BadRequest();
                throw new Exception("Error code 3.2 - UserController Post Create user error");
            }
        }

        [HttpPut]
        public ActionResult Update(string username, JsonElement jsUser)
        {
            try
            {
                var UserIn = JsonConvert.DeserializeObject<UserModel>(jsUser.GetRawText());

                if (_users.GetUser(username).Result == null)
                    return NotFound();
                _users.Update(username, UserIn);
                return NoContent();
            }
            catch (Exception e)
            {
                throw new Exception($"Error code 3.3 - UserController Put Update user error - {e.Message}");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(ObjectId id)
        {
            //Checks if user exists
            if (_users.GetUserById(id).Result == null)
                return NotFound();
            Task.Run(() => _users.Delete(id));
            Task.Run(() => _login.Delete(id));
            Task.Run(() => _salt.Delete(id));
            return NoContent();
        }
    }
}