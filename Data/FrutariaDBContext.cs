using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using WebAPIFrutaria.Data.Map;
using WebAPIFrutaria.Models;

namespace WebAPIFrutaria.Data
{
    public class FrutariaDBContext : DbContext 
    {
        public FrutariaDBContext(DbContextOptions<FrutariaDBContext> options)
            :base(options)
        {
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
