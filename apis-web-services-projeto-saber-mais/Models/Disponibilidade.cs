using System.ComponentModel.DataAnnotations;

namespace apis_web_services_projeto_saber_mais.Models
{
    public class Disponibilidade
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Semana DiaDaSemana { get; set; }
        [Required]
        public DateTime HoraInicio { get; set; }
        [Required]
        public DateTime HoraFim { get; set; }

        //[Required]
        //public Professor Professor { get; set; }
        [Required]
        public int ProfessorId { get; set; }
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
