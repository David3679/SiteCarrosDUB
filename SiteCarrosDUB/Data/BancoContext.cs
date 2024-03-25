using Microsoft.EntityFrameworkCore;
using SiteCarrosDUB.Models;

namespace SiteCarrosDUB.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }
        public DbSet<AcessoriosModel> Acessorios { get; set; }
        public DbSet<UsuariosModel> Usuarios { get; set; }
    }
}
