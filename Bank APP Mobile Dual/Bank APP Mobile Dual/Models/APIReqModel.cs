using System;
using System.Collections.Generic;
using System.Text;

namespace Bank_APP_Mobile_Dual.Models
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
}
