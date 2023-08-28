using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealsPlace.Domain.Enums
{
    public enum VehicleType
    {
        [Display(Name = "Кабриолет")] CONVERTIBLE,
        [Display(Name = "Универсал")] UNIVERSAL,
        [Display(Name = "Хэтчбек")] HATCHBACK,
        [Display(Name = "Лимузин")] LIMOUSINE,
        [Display(Name = "Лифтбек")] LIFTBACK,
        [Display(Name = "Родстер")] ROADSTER,
        [Display(Name = "Внедорожник")] SUV,
        [Display(Name = "Пикап")] PICKUP,
        [Display(Name = "Седан")] SEDAN,
        [Display(Name = "Купе")] COUPE,        
        [Display(Name = "Фургон")] VAN,

        [Display(Name = "Мотоцикл")] MOTORCYCLE,

        [Display(Name = "Другой")] ANOTHER,
    }
}
