using System.ComponentModel.DataAnnotations;

namespace CarDealsPlace.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Необходимо заполнить поле Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить поле Password")]
        public string Password { get; set; }

    }
}
