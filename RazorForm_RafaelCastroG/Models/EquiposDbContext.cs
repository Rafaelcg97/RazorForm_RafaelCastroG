using Microsoft.EntityFrameworkCore;

namespace RazorForm_RafaelCastroG.Models
{
    public class EquiposDbContext : DbContext
    {
        public EquiposDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<marcas> marcas { get; set; }
        public DbSet<estados_equipo> estados_equipo { get; set; }
        public DbSet<tipo_equipo> tipo_equipo { get; set; }
        public DbSet<equipos> equipos { get; set; }

    }
}

