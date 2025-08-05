using libr_aplicaciones.Interfaces;
using libr_dominio.Entidades;
using libr_repositorios.Interfaces;

namespace libr_aplicaciones.Implementaciones
{
    public class CandidatesApp : ICandidatesApp
    {
        private IConexion? IConexion = null;

        public CandidatesApp(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Candidates? Borrar(Candidates? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0) throw new Exception("lbNoSeGuardo");

            this.IConexion!.Candidates!.Remove(entidad); this.IConexion.SaveChanges();
            return entidad;
        }

        public Candidates? Guardar(Candidates? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0) throw new Exception("lbYaSeGuardo");

            //Validamos que no este registrado como votante
            if (this.IConexion!.Voters!.Any(x => x.Id == entidad.Id)) 
                throw new Exception("El candidato no se puede registrar. El Id esta registrado como votante");

            this.IConexion!.Candidates!.Add(entidad); this.IConexion.SaveChanges();
            return entidad;
        }
               
        public List<Candidates> Listar()
        {
            return this.IConexion!.Candidates!
                .Take(33)
                .ToList();
        }

        public Candidates? DetallesPorId(int id)
        {
            return this.IConexion?.Candidates?
             .FirstOrDefault(x => x.Id == id);
        }

    }
}
