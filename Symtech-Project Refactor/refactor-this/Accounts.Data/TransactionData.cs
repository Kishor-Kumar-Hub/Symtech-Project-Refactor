using Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccess
{
    public class TransactionData : ITransactionRepository, IDisposable
    {
        private TransactionDbContext db;
        public TransactionData()
        {
            this.db = new TransactionDbContext();
        }

        public IEnumerable<Transactions> GetTransactions(Guid id)
        {
            var param = new SqlParameter("@AccountId", id);
            var transactions = db.Transactions.SqlQuery("GetTransactionsForAccount @AccountId", param).ToList();
            return transactions;
        }

        public bool Add(Guid id, Transactions transaction)
        {
            var newaccountId = Guid.NewGuid();

            DateTime dateTime = DateTime.Now;
            var updateAccount = db.Database.ExecuteSqlCommand("UPDATE Accounts SET Amount = Amount - @Amount where Id = @AccountId",
                new SqlParameter("@Amount", transaction.Amount),
                new SqlParameter("@AccountId", id));
                
            if (updateAccount != 1)
            {
                return false;
            }
            var insertTransaction = db.Database.ExecuteSqlCommand("INSERT INTO Transactions (Id, Amount, Date, AccountId) VALUES  (@Id, @Amount, @Date, @AccountId)",
                new SqlParameter("@Id", newaccountId),
                new SqlParameter("@Amount", transaction.Amount),
                new SqlParameter("@Date", dateTime),
                new SqlParameter("@AccountId", id));
            if (updateAccount != 1)
            {
                return false;
            }

            return true;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
