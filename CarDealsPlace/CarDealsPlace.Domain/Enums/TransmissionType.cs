using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealsPlace.Domain.Enums
{
    public enum TransmissionType
    {
        [Display(Name = "Автоматическая")] AUTOMATIC,
        [Display(Name = "Ручная")] MECHANICS,
    }
}
