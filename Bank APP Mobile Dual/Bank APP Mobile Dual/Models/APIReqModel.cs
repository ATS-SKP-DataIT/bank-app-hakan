using System;
using System.Collections.Generic;
using System.Text;

namespace Bank_APP_Mobile_Dual.Models
{
    public class APIReqModel : IAPIReqModel
    {
        public string Json { get; set; }
    }
    public interface IAPIReqModel
    {
        string Json { get; set; }
    }
}
