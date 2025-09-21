using Microsoft.EntityFrameworkCore;

namespace apis_web_services_projeto_saber_mais.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) 
        {
                
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        //    // Relacionamento Usuario <-> Professor (1:1)
        //    modelBuilder.Entity<Usuario>()
        //        .HasOne(u => u.Professor)
        //        .WithOne(p => p.Usuario)
        //        .HasForeignKey<Professor>(p => p.UsuarioId);

        //    // Relacionamento Agendamento -> Usuario (Aluno)
        //    modelBuilder.Entity<Agendamento>()
        //        .HasOne(a => a.Usuario)
        //        .WithMany(u => u.AgendamentosComoAluno)
        //        .HasForeignKey(a => a.UsuarioId)
        //        .OnDelete(DeleteBehavior.Restrict);

        //    // Relacionamento Agendamento -> Professor
        //    modelBuilder.Entity<Agendamento>()
        //        .HasOne(a => a.Professor)
        //        .WithMany(p => p.Agendamentos)
        //        .HasForeignKey(a => a.ProfessorId)
        //        .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
