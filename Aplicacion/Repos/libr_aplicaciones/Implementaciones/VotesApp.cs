using libr_aplicaciones.Interfaces;
using libr_dominio.Entidades;
using libr_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace libr_aplicaciones.Implementaciones
{
    public class VotesApp : IVotesApp
    {
        private IConexion? IConexion = null;
        private int TotalVotos=0;

        public VotesApp(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Votes? Guardar(Votes? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0) throw new Exception("lbYaSeGuardo");

            var votante = this.IConexion!.Voters!.FirstOrDefault(x => x.Id == entidad.VoterId);
            if (votante == null) throw new Exception("Votante no encontrado.");
            if (votante.HasVoted) throw new Exception("Este votante ya ha votado."); //Se comprueba si ya voto previamente
            votante.HasVoted = true;

            var candidato = this.IConexion!.Candidates!.FirstOrDefault(x => x.Id == entidad.CandidateId);
            if (candidato == null) throw new Exception("Candidato no encontrado.");
            candidato.Votes++;

            TotalVotos++;
            this.IConexion!.Votes!.Add(entidad);
            this.IConexion.Voters!.Update(votante);
            this.IConexion.Candidates!.Update(candidato);
            this.IConexion.SaveChanges();
            return entidad;
        }
               
        public List<Votes> Listar()
        {
            return this.IConexion!.Votes!
                .Take(33)
                .Include(x => x._VoterId)
                .Include(x => x._CandidateId)
                .ToList();
        }

        public string Estadisticas()
        {
            //Esta linea se usa al momento de hacer pruebas con los votos insertados desde el script ya que estos no pasan por el Crear() por ende no se suman al total
            if (TotalVotos == 0) TotalVotos = this.IConexion!.Candidates!.Sum(x => x.Votes); 
            

            string mensaje = "El total de votos es: " + TotalVotos + " \n" + "---Porcentaje de votos por candidato--- \n";

            List<Candidates>? listaCandidatos = this.IConexion?.Candidates?.ToList();
            List<Voters>? listaVotantes = this.IConexion?.Voters?.ToList();

            for (int i = 0; i < listaCandidatos?.Count; i++)
            {
                if (TotalVotos == 0) throw new Exception("No se pueden calcular porcentajes, el total de votos es 0");
                var objCa = listaCandidatos[i];
                mensaje = mensaje + (i+1) + "--" + objCa.Name + "-" + objCa.Party + ": %" + (((Decimal)(objCa.Votes) / TotalVotos) * 100) + "\n";
            }

            mensaje = mensaje + "--------- \n  Votantes totales registrados: "+listaVotantes?.Count
                + "\n Votantes que han votado: " + listaVotantes?.Count(x => x.HasVoted == true);

            return mensaje;
        }

    }
}
