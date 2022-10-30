using Microsoft.EntityFrameworkCore;
using TesteTecnicoUVA.API.Models;

namespace TesteTecnicoUVA.API.DataBaseContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        //define tabelas no contexto do banco
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
