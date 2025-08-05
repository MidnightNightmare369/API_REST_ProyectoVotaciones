using libr_dominio.Entidades;

namespace libr_aplicaciones.Interfaces
{
    public interface IVotesApp
    {
        void Configurar(string StringConexion);        
        Votes? Guardar(Votes? entidad);
        List<Votes> Listar();
        string Estadisticas();
    }
}
