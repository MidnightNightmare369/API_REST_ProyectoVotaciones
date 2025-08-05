using libr_aplicaciones.Interfaces;
using libr_dominio.Entidades;
using libr_repositorios.Interfaces;

namespace libr_aplicaciones.Implementaciones
{
    public class VotersApp : IVotersApp
    {
        private IConexion? IConexion = null;

        public VotersApp(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Voters? Borrar(Voters? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0) throw new Exception("lbNoSeGuardo");

            this.IConexion!.Voters!.Remove(entidad); this.IConexion.SaveChanges();
            return entidad;
        }

        public Voters? Guardar(Voters? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0) throw new Exception("lbYaSeGuardo");


            //Validamos que no este registrado como Candidato
            if (this.IConexion!.Candidates!.Any(x => x.Id == entidad.Id))
                throw new Exception("El votante no se puede registrar. El Id esta registrado como candidato");

            this.IConexion!.Voters!.Add(entidad); this.IConexion.SaveChanges();
            return entidad;
        }
               
        public List<Voters> Listar()
        {
            return this.IConexion!.Voters!
                .Take(33)
                .ToList();
        }

        public Voters? DetallesPorId(int id)
        {            
            return this.IConexion?.Voters?
             .FirstOrDefault(x => x.Id == id);
        }

    }
}
