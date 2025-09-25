using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apis_web_services_projeto_saber_mais.Models
{
    [Table("Categorias")]
    public class Area
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Nome { get; set; } = null!;

        // Relacionamento: Uma categoria pode ter vários professores
        public ICollection<Professor> Professores { get; set; } = new List<Professor>();
    }
}
