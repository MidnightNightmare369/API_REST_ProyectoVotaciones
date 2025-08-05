using System.ComponentModel.DataAnnotations.Schema;

namespace libr_dominio.Entidades
{
    public class Voters
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public Boolean HasVoted { get; set; }
    }
}
