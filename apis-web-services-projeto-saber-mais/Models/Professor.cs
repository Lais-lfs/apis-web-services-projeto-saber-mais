using System.ComponentModel.DataAnnotations.Schema;

namespace apis_web_services_projeto_saber_mais.Models
{
    [Table("Professores")] // Tabela separada apenas para os dados específicos de Professor
    public class Professor : Usuario
    {
        // Coleções que serão armazenadas como JSON (use conversores no AppDbContext, se necessário)
        public List<string> Certificacoes { get; set; } = new();
        public List<string> Competencias { get; set; } = new();

        // Relacionamentos
        public ICollection<Area> Areas { get; set; } = new List<Area>();
        public ICollection<Agendamento> AgendamentosComoProfessor { get; set; } = new List<Agendamento>();
        public ICollection<Disponibilidade> Disponibilidades { get; set; } = new List<Disponibilidade>();
    }
}
