using System.ComponentModel.DataAnnotations.Schema;

namespace libr_dominio.Entidades
{
    public class Candidates
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Party { get; set; }
        public int Votes { get; set; }
    }
}
