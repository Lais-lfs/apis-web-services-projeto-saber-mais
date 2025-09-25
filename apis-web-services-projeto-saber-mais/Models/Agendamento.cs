using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apis_web_services_projeto_saber_mais.Models
{
    [Table("Agendamentos")]
    public class Agendamento
    {
        [Key]       
        public int Id { get; set; }
        [Required]
        public DateTime DataHora { get; set; }
        [Required]
        public StatusAgendamento Status { get; set; }

        // Chave estrangeira para Professor
        public int ProfessorId { get; set; }
        public virtual Professor Professor { get; set; }

        // Chave estrangeira para Aluno (que é um Usuário)
        public int AlunoId { get; set; }
        public virtual Usuario Aluno { get; set; }

        // Relacionamento: Um agendamento pode ter até 2 avaliações (uma do aluno, uma do professor)
        public virtual ICollection<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>();
    }

    public enum StatusAgendamento
    {
        Pendente,
        Confirmado,
        Realizado,
        Cancelado
    }
    public enum DiaDaSemana
    {
        Domingo,
        Segunda,
        Terca,
        Quarta,
        Quinta,
        Sexta,
        Sabado
    }
}
