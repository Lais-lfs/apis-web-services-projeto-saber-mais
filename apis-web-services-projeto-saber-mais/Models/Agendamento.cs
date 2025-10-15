using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apis_web_services_projeto_saber_mais.Models
{
    public enum StatusAgendamento
    {
        Pendente,
        Confirmado,
        Cancelado
    }

    [Table("Agendamentos")]
    public class Agendamento
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DataHora { get; set; }

        [Required]
        public StatusAgendamento Status { get; set; }

        // Relações
        public int AlunoId { get; set; }
        public virtual Aluno Aluno { get; set; }

        public int ProfessorId { get; set; }
        public virtual Professor Professor { get; set; }
    }
}
