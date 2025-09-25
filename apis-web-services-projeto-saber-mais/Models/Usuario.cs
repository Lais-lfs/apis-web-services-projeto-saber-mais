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
        public ICollection<Agendamento> AgendamentosComoAluno { get; set; } = new List<Agendamento>();
        //public ICollection<Agendamento> AgendamentosComoProfessor { get; set; } = new List<Agendamento>();

        // Relacionamento: Um usuário pode fazer várias avaliações
        public ICollection<Avaliacao> AvaliacoesFeitas { get; set; } = new List<Avaliacao>();
        //public ICollection<Avaliacao> AvaliacoesComoProfessor { get; set; } = new List<Avaliacao>();

        //public Professor Professor { get; set; } // Navegação para Professor, se aplicável
    }
}
