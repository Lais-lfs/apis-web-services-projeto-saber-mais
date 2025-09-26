using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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

            // --- Configuração de herança TPT (Table-per-Type) ---
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Professor>().ToTable("Professores");

            // Comparador para listas de strings (usado nos ValueComparers)
            var listComparer = new ValueComparer<List<string>>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToList()
            );

            // --- Configuração da Entidade Professor ---
            modelBuilder.Entity<Professor>(entity =>
            {
                // Certificacoes como JSON + ValueComparer
                entity.Property(p => p.Certificacoes)
                    .HasConversion(
                        v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                        v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null) ?? new List<string>()
                    )
                    .Metadata.SetValueComparer(listComparer);

                // Competencias como JSON + ValueComparer
                entity.Property(p => p.Competencias)
                    .HasConversion(
                        v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                        v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null) ?? new List<string>()
                    )
                    .Metadata.SetValueComparer(listComparer);

                // Relacionamento muitos-para-muitos entre Professor e Área
                entity.HasMany(p => p.Areas)
                      .WithMany(c => c.Professores)
                      .UsingEntity(j => j.ToTable("ProfessorArea"));
            });

            // --- Configuração da Entidade Agendamento ---
            modelBuilder.Entity<Agendamento>(entity =>
            {
                entity.HasOne(a => a.Aluno)
                      .WithMany(u => u.AgendamentosComoAluno)
                      .HasForeignKey(a => a.AlunoId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(a => a.Professor)
                      .WithMany(p => p.AgendamentosComoProfessor)
                      .HasForeignKey(a => a.ProfessorId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.Property(a => a.Status)
                      .HasConversion<string>();
            });

            // --- Configuração da Entidade Disponibilidade ---
            modelBuilder.Entity<Disponibilidade>(entity =>
            {
                entity.Property(d => d.DiaDaSemana)
                      .HasConversion<string>();

                entity.HasOne(d => d.Professor)
                      .WithMany(p => p.Disponibilidades)
                      .HasForeignKey(d => d.ProfessorId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // --- Configuração da Entidade Avaliacao ---
            modelBuilder.Entity<Avaliacao>(entity =>
            {
                entity.HasOne(av => av.Agendamento)
                      .WithMany()
                      .HasForeignKey(av => av.AgendamentoId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(av => av.AvaliadorAluno)
                      .WithMany(u => u.AvaliacoesFeitas)
                      .HasForeignKey(av => av.AvaliadorAlunoId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(av => av.AvaliadorProfessor)
                      .WithMany()
                      .HasForeignKey(av => av.AvaliadorProfessorId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
