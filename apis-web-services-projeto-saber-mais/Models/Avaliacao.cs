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
        public int UsuarioAvaliadorId { get; set; }
        
        [Required]
        public Usuario Avaliador { get; set; }

        [Required]
        public int UsuarioAvaliadoId { get; set; }

        [Required]
        public Usuario Avaliado { get; set; }

        [Required]
        public int AgendamentoId { get; set; }

        [Required]
        public Agendamento Agendamento { get; set; }
    }
}
