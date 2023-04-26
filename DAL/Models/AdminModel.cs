using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    class AdminModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Psswrd { get; set; }


        public static int CreateAdminProfile(AdminModel am)
        {
            BankDBOEntities bankingEntities = new BankDBOEntities();
            Admin a = new Admin();
            a.ID = am.ID;
            a.Name = am.Name;
            a.Psswrd = am.Psswrd;

            bankingEntities.Admins.Add(a);
            bankingEntities.SaveChanges();

            return 1;
        }
    }
}
