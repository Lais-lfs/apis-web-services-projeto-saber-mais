using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace apis_web_services_projeto_saber_mais.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Disponibilidade> Disponibilidades { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- Configuração da Entidade Professor ---
            modelBuilder.Entity<Professor>(entity =>
            {

                // Converter a lista de Certificacoes para uma string JSON no banco
                entity.Property(p => p.Certificacoes)
                    .HasConversion(
                        v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                        v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null) ?? new List<string>()
                    );

                // Converter a lista de Competencias para uma string JSON no banco
                entity.Property(p => p.Competencias)
                    .HasConversion(
                        v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                        v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null) ?? new List<string>()
                    );

                // Configurar o relacionamento Muitos-para-Muitos entre Professor e Área
                entity.HasMany(p => p.Areas)
                      .WithMany(c => c.Professores)
                      .UsingEntity(j => j.ToTable("ProfessorArea")); // Tabela de junção explícita
            });

            // --- Configuração da Entidade Agendamento ---
            modelBuilder.Entity<Agendamento>(entity =>
            {
                // Relacionamento com Aluno (Usuario)
                entity.HasOne(a => a.Aluno)
                      .WithMany(u => u.AgendamentosComoAluno)
                      .HasForeignKey(a => a.AlunoId)
                      .OnDelete(DeleteBehavior.Restrict); // Evitar exclusão em cascata se houver agendamento

                // Relacionamento com Professor
                entity.HasOne(a => a.Professor)
                      .WithMany(p => p.AgendamentosComoProfessor)
                      .HasForeignKey(a => a.ProfessorId)
                      .OnDelete(DeleteBehavior.Restrict); // Evitar exclusão em cascata

                // Converter o Enum StatusAgendamento para string no banco (mais legível)
                entity.Property(a => a.Status)
                      .HasConversion<string>();
            });

            // --- Configuração da Entidade Disponibilidade ---
            modelBuilder.Entity<Disponibilidade>(entity =>
            {
                // Converter o Enum DiaDaSemana para string no banco
                entity.Property(d => d.DiaDaSemana)
                      .HasConversion<string>();
            });

            // --- Configuração da Entidade Avaliacao ---
            modelBuilder.Entity<Avaliacao>(entity =>
            {
                // Relacionamento com Aluno (Avaliador)
                entity.HasOne(av => av.AvaliadorAluno)
                      .WithMany(u => u.AvaliacoesFeitas)
                      .HasForeignKey(av => av.AvaliadorAlunoId)
                      .OnDelete(DeleteBehavior.Restrict);

                // Relacionamento com Professor (Avaliador)
                entity.HasOne(av => av.AvaliadorProfessor)
                      .WithMany() // Um professor pode fazer várias avaliações, mas não temos uma coleção para isso no modelo
                      .HasForeignKey(av => av.AvaliadorProfessorId)
                      .OnDelete(DeleteBehavior.Restrict);
            });





        }
    }
}
