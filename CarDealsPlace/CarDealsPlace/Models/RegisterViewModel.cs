using System.ComponentModel.DataAnnotations;

namespace CarDealsPlace.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Необходимо заполнить поле Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить поле Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить поле Phone Number")]
        [Phone(ErrorMessage = "Поле Phone Number заполнено некорректно")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить поле Email")]
        [EmailAddress(ErrorMessage = "Введите корректный email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить поле ErrorMessage")]
        [MinLength(5, ErrorMessage = "Слишком короткий пароль: минимальная длина 5 букв")]
        public string Password { get; set; }
    }
}
