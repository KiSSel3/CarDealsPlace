using CarDealsPlace.Domain.Enums;

namespace CarDealsPlace.Domain.Models
{
    public class VehicleModel : BaseModel
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Mileage { get; set; }
        public float EngineDisplacement { get; set; }
        
        public VehicleType VehicleType { get; set; }
        public WheelDriveType WheelDriveType { get; set; }
        public TransmissionType TransmissionType { get; set; }

        public DateTime ProductionYear { get; set; }

        public List<string> ImageUrls { get; set; }
    }
}
