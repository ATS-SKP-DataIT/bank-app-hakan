using System;
using System.Collections.Generic;
using System.Text;

namespace Bank_APP_Mobile_Dual.Models
{
    class FrontPageModels
    {
    }

    class UserInfos
    {
        public UserInfos(int accountNumber, string accountName)
        {
            this.AccountNumber = accountNumber;
            this.AccountName = accountName;
        }

        public int AccountNumber { get; set; }
        public string AccountName { get; set; } 
    }
}
