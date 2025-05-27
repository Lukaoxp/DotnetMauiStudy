using System.ComponentModel.DataAnnotations;

namespace AppLanches.Models
{
    public class Register
    {
        public string? Nome { get; set; }
        [Required]
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        [Required]
        public string? Senha { get; set; }
    }
}
