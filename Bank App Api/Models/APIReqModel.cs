using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank_App_Api.Models
{
    public class APIReqModel : IAPIReqModel
    {
        public string Json { get; set; }
        public string Token { get; set; }
        public string Username { get; set; }
    }
    public interface IAPIReqModel
    {
        string Json { get; set; }
        string Token { get; set; }
        string Username { get; set; }
    }
}
