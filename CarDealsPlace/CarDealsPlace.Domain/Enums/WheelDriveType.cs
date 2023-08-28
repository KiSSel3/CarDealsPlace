using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealsPlace.Domain.Enums
{
    public enum WheelDriveType
    {
        [Display(Name = "Передний")] FRONT,
        [Display(Name = "Задний")] REAR,
        [Display(Name = "Полный")] ALL,
    }
}
