using Microsoft.EntityFrameworkCore;
using sistema.api.Models;

namespace sistema.api.Data
{
    public class CartaoDbContext : DbContext
    {
        public CartaoDbContext(DbContextOptions options) : base(options)
        {
        }
        //Dbset
        public DbSet<Cartao> Cartoes { get; set; }
    }
}
