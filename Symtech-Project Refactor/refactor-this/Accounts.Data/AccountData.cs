using Core;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace DataAccess
{
    public class AccountData : IAccountRepository, IDisposable
    {

        private AccountDbContext db;
        public AccountData()
        {
            this.db = new AccountDbContext();
        }
   
        public IEnumerable<Accounts> GetAccounts()
        {
            return db.Accounts.ToList();
        }

        public Accounts GetById(Guid id)
        {
            Accounts account = db.Accounts.SingleOrDefault(x => x.Id == id);
            return account;
        }

        public bool Update(Accounts updatedAccount)
        {
            try
            {
                db.Entry(updatedAccount).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Add(Accounts newAccount)
        {
            try
            {
                db.Accounts.Add(newAccount);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                Accounts account = db.Accounts.SingleOrDefault(x => x.Id == id);
                if (account == null)
                {
                    return false;
                }
                db.Accounts.Remove(account);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Dispose()
        {
            this.db.Dispose();
        }
    }
}

