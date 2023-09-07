using CarDealsPlace.Domain.Enums;
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
        [Required(ErrorMessage = "Необходимо заполнить поле Barnd")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить поле Model")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить поле Mileage")]
        public int Mileage { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить поле EngineDisplacement")]
        public float EngineDisplacement { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить поле Horsepower")]
        public int Horsepower { get; set; }

        [Required(ErrorMessage = "Необходимо выбрать VehicleType")]
        public VehicleType VehicleType { get; set; }

        [Required(ErrorMessage = "Необходимо выбрать WheelDriveType")]
        public WheelDriveType WheelDriveType { get; set; }

        [Required(ErrorMessage = "Необходимо выбрать TransmissionType")]
        public TransmissionType TransmissionType { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить поле ProductionYear")]
        public DateOnly ProductionYear { get; set; }


        [Required(ErrorMessage = "Необходимо добавить описание машины")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Необходимо указать цену")]
        public float Price { get; set; }

        [Required(ErrorMessage = "Необходимо указать местоположение машины")]
        public string Location { get; set; }
    }
}
