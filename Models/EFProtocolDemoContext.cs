using Microsoft.EntityFrameworkCore;
namespace EFProtocolDemo
{
    public class EFProtocolDemoContext : DbContext
    {
        public DbSet<Mail> Mails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database = pippo;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        
    }
}