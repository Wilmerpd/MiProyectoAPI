using Microsoft.EntityFrameworkCore;
using MiProyectoAPI.Models;

namespace MiProyectoAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Taxi> Taxis { get; set; }
        public DbSet<Viaje> Viajes { get; set; }
        public DbSet<GrupoUsuarios> GruposUsuarios { get; set; }
        public DbSet<DetalleViaje> DetallesViaje { get; set; }
    }
}



