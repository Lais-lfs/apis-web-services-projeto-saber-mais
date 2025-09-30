using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apis_web_services_projeto_saber_mais.Models
{
    [Table("Usuarios")] 
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Cpf { get; set; }
        public string Descricao { get; set; }

        // Relacionamento: Um usuário (aluno) pode ter vários agendamentos
        public ICollection<Agendamento> Agendamentos { get; set; }

        // Relacionamento: Um usuário pode fazer várias avaliações
        public ICollection<Avaliacao> AvaliacoesFeitas { get; set; }
        //public ICollection<Avaliacao> AvaliacoesComoProfessor { get; set; } = new List<Avaliacao>();
    }
}
