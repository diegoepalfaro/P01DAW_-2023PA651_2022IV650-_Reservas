using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace P01DAW__2023PA651_2022IV650__Reservas.Models
{
    public class ReservasContext : DbContext
    {
        public ReservasContext(DbContextOptions<ReservasContext> options) : base(options)
        { 
        }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Sucursales> Sucursales { get; set; }
        public DbSet<EspaciosParqueo> EspaciosParqueo { get; set; }
        public DbSet<Reservas> Reservas { get; set; }

    }
}
