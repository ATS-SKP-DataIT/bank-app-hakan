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
        public byte[] Username { get; set; }
    }
    public interface IAPIReqModel
    {
        string Json { get; set; }
        string Token { get; set; }
        byte[] Username { get; set; }
    }
    public class EncAPIReqModel
    {
        public string Json { get; set; }
    }
}
