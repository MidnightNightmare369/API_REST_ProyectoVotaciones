using libr_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using libr_dominio.Entidades;


namespace libr_repositorios.Implementaciones
{    public partial class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Voters>? Voters { get; set; }
        public DbSet<Candidates>? Candidates { get; set; }
        public DbSet<Votes>? Votes { get; set; }

    }
}
