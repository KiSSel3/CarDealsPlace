using CarDealsPlace.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealsPlace.Domain.ViewModels
{
    public class OfferViewModel
    {
        [Required(ErrorMessage = "Необходимо заполнить информацию о машине")]
        public VehicleViewModel Vehicle { get; set; }

        [Required(ErrorMessage = "Необходимо добавить описание машины")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Необходимо указать цену")]
        public float Price { get; set; }

        [Required(ErrorMessage = "Необходимо указать местоположение машины")]
        public string Location { get; set; }
    }
}
