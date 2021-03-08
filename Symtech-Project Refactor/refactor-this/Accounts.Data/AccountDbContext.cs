using Core;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AccountDbContext : DbContext
    {
        public DbSet<Accounts> Accounts { get; set; }


        public AccountDbContext() : base("name=AccountContext")
        {
           
        }


        // factory method
        public static AccountDbContext create()
        {
            var context = new AccountDbContext();
            return context;
        }
    }
}
