using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealsPlace.Domain.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Необходимо заполнить поле Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить поле Password")]
        public string Password { get; set; }

    }
}
