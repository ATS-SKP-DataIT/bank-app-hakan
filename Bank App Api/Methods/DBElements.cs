using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank_App_Api.Methods
{
    public class DBElements : IDBElements
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
        public string Collection { get; set; }
    }
    public interface IDBElements
    {
        string ConnectionString { get; set; }
        string Database { get; set; }
        string Collection { get; set; }
    }
}
