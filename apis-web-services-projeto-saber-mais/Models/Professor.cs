using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apis_web_services_projeto_saber_mais.Models
{
    [Table("Professores")]
    public class Professor : Usuario
    {
        [Required]
        public List<string> Certificacoes { get; set; }
        [Required]
        public List<string> Competencias { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }

        // Relacionamento: Um professor pode pertencer a várias áreas
        [Required]
        public ICollection<Area> Areas { get; set; } = new List<Area>();

        // Relacionamento: Um professor tem várias disponibilidades
        [Required]
        public ICollection<Disponibilidade> Disponibilidades { get; set; } = new List<Disponibilidade>();

        // Relacionamento: Um professor pode ter vários agendamentos
        public ICollection<Agendamento> AgendamentosComoProfessor { get; set; } = new List<Agendamento>();

        // Relacionamento: Um professor pode fazer várias avaliações
        public ICollection<Avaliacao> AvaliacoesRecebidas { get; set; } = new List<Avaliacao>();
    }
}
