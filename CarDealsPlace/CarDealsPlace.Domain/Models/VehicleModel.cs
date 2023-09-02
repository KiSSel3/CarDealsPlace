using CarDealsPlace.Domain.Enums;

namespace CarDealsPlace.Domain.Models
{
    public class VehicleModel : BaseModel
    {
        public VehicleModel() =>
            (Id, Brand, Model, Mileage, EngineDisplacement, Horsepower, VehicleType, WheelDriveType, TransmissionType, ProductionYear, ImageUrls) =
            (Guid.Empty, "None", "None", 0, 0, 0, 0, 0, 0, new DateOnly(), new List<string>());

        public VehicleModel(string brand, string model, int mileage, float engineDisplacement, int horsepower, VehicleType vehicleType, WheelDriveType wheelDriveType,
            TransmissionType transmissionType, DateOnly productionYear, List<string> imageUrls) =>
            (Id, Brand, Model, Mileage, EngineDisplacement, Horsepower, VehicleType, WheelDriveType, TransmissionType, ProductionYear, ImageUrls) =
            (Guid.NewGuid(), brand, model, mileage, engineDisplacement, horsepower, vehicleType, wheelDriveType, transmissionType, productionYear, imageUrls);

        public VehicleModel(Guid id, string brand, string model, int mileage, float engineDisplacement, int horsepower, VehicleType vehicleType, WheelDriveType wheelDriveType,
            TransmissionType transmissionType, DateOnly productionYear, List<string> imageUrls) =>
            (Id, Brand, Model, Mileage, EngineDisplacement, Horsepower, VehicleType, WheelDriveType, TransmissionType, ProductionYear, ImageUrls) =
            (id, brand, model, mileage, engineDisplacement, horsepower, vehicleType, wheelDriveType, transmissionType, productionYear, imageUrls);

        public string Brand { get; set; }
        public string Model { get; set; }
        public int Mileage { get; set; }
        public float EngineDisplacement { get; set; }
        public int Horsepower { get; set; }

        public VehicleType VehicleType { get; set; }
        public WheelDriveType WheelDriveType { get; set; }
        public TransmissionType TransmissionType { get; set; }

        public DateOnly ProductionYear { get; set; }

        public List<string> ImageUrls { get; set; }
    }
}
