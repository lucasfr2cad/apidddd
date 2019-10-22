using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos
{
    public class LoginDto
    {
        [Required (ErrorMessage = "Email é um campo obrigatório")]
       // [EmailAddress(ErrorMessage = "Email em formato inválido")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo {1}, caracteres")]
        public string Email { get; set; }

        [Required (ErrorMessage = "Senha é um campo obrigatório")]
        public string Senha { get; set; }

        public int sessionId { get; set; }

    }
}
