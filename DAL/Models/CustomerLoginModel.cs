using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class CustomerLoginModel
    {
        public string AccountNo { get; set; }
        public string CustomerName { get; set; }
        public string Psswrd { get; set; }

        public static int GetCusLogIns(CustomerLoginModel Clm)
        {
            BankDBOEntities bms = new BankDBOEntities();
            var login = bms.Customers;

            var counter = login.Where(x => x.CustomerName == Clm.CustomerName && x.Psswrd == Clm.Psswrd).Count();

            if (counter == 1)
            {
                int accountNumber = login.Where(x => x.CustomerName == Clm.CustomerName && x.Psswrd == Clm.Psswrd).Select(x => x.AccountNo).FirstOrDefault();
                return accountNumber;
            }
            else
                return 0;
        }
    
}
}
