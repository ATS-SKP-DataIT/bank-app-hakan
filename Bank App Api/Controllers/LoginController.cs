using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NLog;
using Bank_App_Api.Crud;
using Bank_App_Api.Models;

using static Bank_App_Api.Helper_Classes.Salting;
namespace Bank_App_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        //   readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly LoginCrud _login;
        private readonly SaltCrud _salt;
        public LoginController(LoginCrud login, SaltCrud salt)
        {
            _login = login;
            _salt = salt;
        }

        //Get list of all users
        [HttpGet]
        public ActionResult<List<LoginModel>> Get() =>
                _login.Get();

        [HttpPost]
        public ActionResult LoginConfirm([FromBody] JsonElement LoginJson)
        {
            try
            {
                //Crypto?
                var content = JsonConvert.DeserializeObject<APILoginModel>(LoginJson.GetRawText());
                LoginModel SavedContent = _login.GetUserByUserName(content.UserName);
                if (SavedContent == null)
                    SavedContent = _login.GetUser(content.UserName);
                if (SavedContent == null)
                    return NotFound();

                //salting
                bool loginResult = false;
                //    if (HashSalt(content.Password, Convert.FromBase64String(_salt.GetUserById(SavedContent.Id).SaltPass)).Pass == SavedContent.Password)

                var id = _salt.GetUserById(SavedContent.Id).SaltPass;
                var passTest = Convert.FromBase64String(id);
                var result = HashSalt(content.Password, passTest).Pass == SavedContent.Password;
                if (result)
                    loginResult = true;
                return Ok(loginResult);
            }
            catch (Exception e)
            {
                throw new Exception($"Error Code 1.2 - Error at HTTPPOST - {e.Message}");
            }
        }
    }
}
