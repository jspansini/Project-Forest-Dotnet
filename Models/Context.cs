using Microsoft.EntityFrameworkCore;

namespace AgenciaForest.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<CadastrarPassagem> CadastrarPassagem { get; set; }
        public DbSet<ComprarPassagem> ComprarPassagem { get; set; }
    }
}
