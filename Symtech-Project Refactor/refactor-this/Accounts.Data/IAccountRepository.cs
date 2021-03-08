using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    interface IAccountRepository
    {
        IEnumerable<Accounts> GetAccounts();
        Accounts GetById(Guid id);
        bool Update(Accounts updatedAccount);
        bool Add(Accounts newAccount);
        bool Delete(Guid id);
    }
}
