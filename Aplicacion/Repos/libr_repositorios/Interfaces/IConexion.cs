using libr_dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace libr_repositorios.Interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }

        DbSet<Voters>? Voters { get; set; }
        DbSet<Candidates>? Candidates { get; set; }
        DbSet<Votes>? Votes { get; set; }        

        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}
