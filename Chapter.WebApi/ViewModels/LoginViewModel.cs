using System.ComponentModel.DataAnnotations;

namespace Chapter.WebApi.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Infomar o Email é Obrigatorio!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informar a Senha é Obrigatorio!")]
        public string Senha { get; set; }
    }
}
