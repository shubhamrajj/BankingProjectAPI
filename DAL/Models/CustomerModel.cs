using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class CustomerModel
    {
        public int AccountNo { get; set; }
        public string CustomerName { get; set; }
        public int PhoneNo { get; set; }
        public string Addrss { get; set; }
        public string MailId { get; set; }
        public DateTime DtOfOpeningAccnt { get; set; }
        public string AccountType { get; set; }
        public string Psswrd { get; set; }
        public long Balance { get; set; }

        public static List<Customer> GetAllCustomerProfile()
        {
            BankDBOEntities bankingEntities = new BankDBOEntities();

            var dbData = bankingEntities.Customers;

            List<Customer> lstCustomer = new List<Customer>();

            foreach (var cust in dbData)
            {
                Customer c = new Customer();

                c.AccountNo = cust.AccountNo;
                c.AccountType = cust.AccountType;
                c.Addrss = cust.Addrss;
                c.Balance = cust.Balance;
                c.CustomerName = cust.CustomerName;
                c.DtOfOpeningAccnt = cust.DtOfOpeningAccnt;
                c.MailId = cust.MailId;
                c.PhoneNo = cust.PhoneNo;
                c.Psswrd = cust.Psswrd;

                lstCustomer.Add(c);
            }
            return lstCustomer;
        }

        public static Customer GetCustomerProfile(int id)
        {
            BankDBOEntities bankingEntities = new BankDBOEntities();

            var cust = bankingEntities.Customers.Find(id);

            //List<Customer> lstCustomer = new List<Customer>();

            //foreach (var cust in dbData)
            //{
                Customer c = new Customer();

                c.AccountNo = cust.AccountNo;
                c.AccountType = cust.AccountType;
                c.Addrss = cust.Addrss;
                c.Balance = cust.Balance;
                c.CustomerName = cust.CustomerName;
                c.DtOfOpeningAccnt = cust.DtOfOpeningAccnt;
                c.MailId = cust.MailId;
                c.PhoneNo = cust.PhoneNo;
                c.Psswrd = cust.Psswrd;

            //    lstCustomer.Add(c);
            //}
            return c;
        }

        public static int CreateCustomerProfile(CustomerModel cust)
        {
            BankDBOEntities bankingEntities = new BankDBOEntities();

            Customer c = new Customer();
            c.AccountNo = cust.AccountNo;
            c.AccountType = cust.AccountType;
            c.Addrss = cust.Addrss;
            c.Balance = cust.Balance;
            c.CustomerName = cust.CustomerName;
            c.DtOfOpeningAccnt = cust.DtOfOpeningAccnt;
            c.MailId = cust.MailId;
            c.PhoneNo = cust.PhoneNo;
            c.Psswrd = cust.Psswrd;




            bankingEntities.Customers.Add(c);
            bankingEntities.SaveChanges();

            return 1;

        }

        public static int DeleteCustomerProfile(int id)
        {
            BankDBOEntities bankingEntities = new BankDBOEntities();

            
                Customer c = bankingEntities.Customers.Find(id);
            if (c == null)
            {
                return 0;
            }
            
            bankingEntities.Customers.Remove(c);
            bankingEntities.SaveChanges();
            return 1;
        }

        public static int UpdateCustomerProfile(CustomerModel cust)
        {
            BankDBOEntities bankingEntities = new BankDBOEntities();

            Customer c = new Customer();
            c.AccountNo = cust.AccountNo;
            c.AccountType = cust.AccountType;
            c.Addrss = cust.Addrss;
            c.Balance = cust.Balance;
            c.CustomerName = cust.CustomerName;
            c.DtOfOpeningAccnt = cust.DtOfOpeningAccnt;
            c.MailId = cust.MailId;
            c.PhoneNo = cust.PhoneNo;
            c.Psswrd = cust.Psswrd;

           // Customer.E(bankingEntities).State = EntityState.Modified;

            bankingEntities.Entry(c).State = EntityState.Modified;


            //bankingEntities.Customers.Add(c);
            bankingEntities.SaveChanges();

            return 1;

        }
    }
}
