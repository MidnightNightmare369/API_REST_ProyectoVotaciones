using libr_dominio.Entidades;

namespace libr_aplicaciones.Interfaces
{
    public interface ICandidatesApp
    {
        void Configurar(string StringConexion);
        Candidates? DetallesPorId(int id);
        List<Candidates> Listar(); 
        Candidates? Guardar(Candidates? entidad); 
        Candidates? Borrar(Candidates? entidad); 
    }
}
