using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank_App_Api.Models
{
    public class APIReqModel : IAPIReqModel
    {
        public string Json { get; set; }
    }
    public interface IAPIReqModel
    {
        public string Json { get; set; }
    }
}
