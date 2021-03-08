using Core;
using System;
using System.Collections.Generic;

namespace DataAccess
{
    interface ITransactionRepository
    {
        IEnumerable<Transactions> GetTransactions(Guid id);
        bool Add(Guid id, Transactions transaction);
    }
}
