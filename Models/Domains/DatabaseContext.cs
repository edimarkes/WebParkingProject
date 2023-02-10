using Microsoft.EntityFrameworkCore;

namespace WebParking.Models.Domains
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }
        public DbSet<ControleVeiculo>? ControleVeiculo { get; set; }
        


    }
}
