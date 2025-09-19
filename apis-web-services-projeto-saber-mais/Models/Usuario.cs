﻿using System.ComponentModel.DataAnnotations;
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

        public ICollection<Agendamento> AgendamentosComoAluno { get; set; }

        public Professor Professor { get; set; } // Navegação para Professor, se aplicável
    }
}
