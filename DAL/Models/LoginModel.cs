using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class LoginModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Psswrd { get; set; }
        

        public static int GetLogIns(LoginModel Lm)
        {
            BankDBOEntities bms = new BankDBOEntities();
            var login = bms.Admins;

            var counter = login.Where(x => x.Name == Lm.Name && x.Psswrd == Lm.Psswrd).Count();

            if (counter == 1)
            {
                return 1;
            }
            else
                return 0;
        }
    }
}