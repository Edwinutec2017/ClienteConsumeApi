using System.ComponentModel.DataAnnotations;
namespace ClientePolicomerce.ViewModels.Login
{
    public class Usuario
    {
        [Required(ErrorMessage = "Debe ingresar el nombre de Usuario")]
        [Display(Name = "Usuario")]
        public string User { get; set; }

        [Required(ErrorMessage = "Debe ingresar la contraseña")]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

    }
}