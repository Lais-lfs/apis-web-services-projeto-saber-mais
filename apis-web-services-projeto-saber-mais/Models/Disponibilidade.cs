using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apis_web_services_projeto_saber_mais.Models
{
    public class Disponibilidade
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Semana DiaDaSemana { get; set; }

        [Required]
        [Column(TypeName = "time")]
        public TimeSpan HoraInicio { get; set; }

        [Required]
        [Column(TypeName = "time")]
        public TimeSpan HoraFim { get; set; }

        // Chave estrangeira para Professor
        public int ProfessorId { get; set; }
        public virtual Professor Professor { get; set; }
    }
    public enum Semana
    {
        Domingo,
        Segunda,
        Terça,
        Quarta,
        Quinta,
        Sexta,
        Sábado
    }
}
