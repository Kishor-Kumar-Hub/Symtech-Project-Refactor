using Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    class TransactionDbContext : DbContext
    {
        public DbSet<Transactions> Transactions { get; set; }


        public TransactionDbContext() : base("name=AccountContext")
        {

        }
    }
}
