using System;
using System.Collections.Generic;
using System.Text;

namespace Bank_APP_Mobile_Dual.Models
{
    class DBModelElements
    {
    }

    public class DBSettings : IDBSettings
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
        public string Collection { get; set; }
    }
    public interface IDBSettings
    {
        string ConnectionString { get; set; }
        string Database { get; set; }
        string Collection { get; set; }
    }
}
