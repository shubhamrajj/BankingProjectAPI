using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class TransactionModel
    {
        
        public int TransactionId { get; set; }
        public Nullable<System.DateTime> DateOfTransaction { get; set; }
        public string TypeOfTransaction { get; set; }
        public Nullable<double> Amount_transacted { get; set; }
        public Nullable<int> AccountNo { get; set; }

        public static List<Transaction_Bank> GetAllTransaction(int accountNumber)
        {
            BankDBOEntities bankingEntities = new BankDBOEntities();

            var dbData = bankingEntities.Transaction_Bank.Where(x=>x.AccountNo == accountNumber);

            List<Transaction_Bank> transaction_s = new List<Transaction_Bank>();

            foreach (var trans in dbData)
            {
                Transaction_Bank t = new Transaction_Bank();

                t.TransactionId = trans.TransactionId;
                t.DateOfTransaction = trans.DateOfTransaction;
                t.TypeOfTransaction = trans.TypeOfTransaction;
                t.Amount_transacted = trans.Amount_transacted;
                t.AccountNo = trans.AccountNo;


                transaction_s.Add(t);
            }
            return transaction_s;
        }

        public static int CreateTransactionProfile(TransactionModel trans)
        {
            BankDBOEntities bankingEntities = new BankDBOEntities();

            Transaction_Bank t = new Transaction_Bank();
            t.TransactionId = trans.TransactionId;
            t.DateOfTransaction = DateTime.Now; //trans.DateOfTransaction;
            t.TypeOfTransaction = trans.TypeOfTransaction;
            t.Amount_transacted = trans.Amount_transacted;
            t.AccountNo = trans.AccountNo;




            bankingEntities.Transaction_Bank.Add(t);
            bankingEntities.SaveChanges();

            return 1;

        }
    }
}
