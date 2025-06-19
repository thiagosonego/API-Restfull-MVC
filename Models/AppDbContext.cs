using Desafio_Final_Arquitetura_de_Software.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Final_Arquitetura_de_Software.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Products> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
    }
}
