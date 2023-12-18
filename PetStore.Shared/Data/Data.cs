using Microsoft.EntityFrameworkCore;
using PetStore.Shared.Entities;

namespace PetStore.Shared.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            
        }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<UserAccount> UserAccounts{ get; set; }
    }
}
