using System.ComponentModel.DataAnnotations;

namespace AppLanches.Models
{
    public class Token
    {
        [Required]
        public string? AccessToken { get; set; }
        public string? TokenType { get; set; }
        [Required]
        public int UsuarioId { get; set; }
        public string? UsuarioNome { get; set; }
    }
}
