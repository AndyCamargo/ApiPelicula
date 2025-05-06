using ApiPeliculas.Modelos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace ApiPeliculas.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUsuario>
    // public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) 
        {
          

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        ///aqui pasar todos las entidades (Modelos)
        ///
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Pelicula> Pelicula { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<AppUsuario> AppUsuario { get; set; }

    }
}
