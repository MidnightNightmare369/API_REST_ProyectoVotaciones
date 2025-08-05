using System.ComponentModel.DataAnnotations.Schema;

namespace libr_dominio.Entidades
{
    public class Votes
    {
        public int Id { get; set; }
        public int VoterId { get; set; }
        public int CandidateId { get; set; }

        [ForeignKey("VoterId")] public Voters? _VoterId { get; set; }
        [ForeignKey("CandidateId")] public Candidates? _CandidateId { get; set; }

    }
}
