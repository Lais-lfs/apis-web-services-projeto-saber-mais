using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apis_web_services_projeto_saber_mais.Models
{
    [Table("Avaliacoes")]
    public class Avaliacao
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Nota { get; set; }
        [Required]
        public string Comentario { get; set; }

        [Required]
        public int AvaliadorAlunoId { get; set; }
        [Required]
        public Usuario AvaliadorAluno { get; set; }

        [Required]
        public int AvaliadorProfessorId { get; set; }
        [Required]
        public Professor AvaliadorProfessor { get; set; }

        [Required]
        public int AgendamentoId { get; set; }
        [Required]
        public Agendamento Agendamento { get; set; }
    }
}
