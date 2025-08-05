using libr_dominio.Entidades;

namespace libr_aplicaciones.Interfaces
{
    public interface IVotersApp
    {
        void Configurar(string StringConexion);
        Voters? DetallesPorId(int id); 
        List<Voters> Listar(); 
        Voters? Guardar(Voters? entidad); 
        Voters? Borrar(Voters? entidad); 
    }
}
