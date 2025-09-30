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

        // Chave estrangeira para o Agendamento
        public int AgendamentoId { get; set; }
        public virtual Agendamento Agendamento { get; set; }


        // Chave estrangeira para quem fez a avaliação (o Avaliador)
        // Apenas um destes será preenchido.
        public int AvaliadorAlunoId { get; set; }
        public virtual Usuario AvaliadorAluno { get; set; }

        public int AvaliadorProfessorId { get; set; }
        public virtual Professor AvaliadorProfessor { get; set; }
    }
}
