using System.ComponentModel.DataAnnotations;

namespace apis_web_services_projeto_saber_mais.Models
{
    public class Certificacao
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        //public string Instituicao { get; set; }
        //public DateTime DataEmissao { get; set; }
        //public DateTime? DataValidade { get; set; } // Pode ser nulo se não expirar
        //public string Descricao { get; set; }
        
        // Relação com Professor
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; } = null!;
    }
}
