using System.ComponentModel.DataAnnotations;

namespace apis_web_services_projeto_saber_mais.Models
{
    public class AuthenticateDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
