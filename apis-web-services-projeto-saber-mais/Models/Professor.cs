using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apis_web_services_projeto_saber_mais.Models
{
    [Table("Professores")]
    public class Professor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UsuarioId { get; set; }
        [Required]
        public Usuario Usuario { get; set; }

        [Required]
        public string Certificacoes { get; set; }
        [Required]
        public string Competencias { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }

        [Required]
        public ICollection<Categoria> Categorias { get; set; }
        [Required]
        public ICollection<Disponibilidade> Disponibilidades { get; set; }

        public ICollection<Agendamento> Agendamentos { get; set; }
    }
}
