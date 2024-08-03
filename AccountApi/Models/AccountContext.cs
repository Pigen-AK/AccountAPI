using Microsoft.EntityFrameworkCore;

namespace AccountApi.Models
{
    public class AccountContext : DbContext
    {
        public AccountContext(DbContextOptions<AccountContext> options)
            : base(options)
        {
        }

        public DbSet<Account> AccountItems { get; set; } = null!;
        public DbSet<Transfer> TransferItems { get; set; } = null!;

    }
}
