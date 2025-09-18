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
    }

    public enum StatusAgendamento
    {
        Pendente,
        Confirmado,
        Realizado,
        Cancelado
    }
}
