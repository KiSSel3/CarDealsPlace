using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealsPlace.Domain.Models
{
    public class OfferModel : BaseModel
    {
        public OfferModel() =>
            (Id, Vehicle, VehicleId, User, UserId, PublicationData, Description, Price, Location) = (Guid.Empty, null, Guid.Empty, null, Guid.Empty, new DateTime(), "None", 0f, "None");
        public OfferModel(VehicleModel vehicle, UserModel user, string description, float price, string location) =>
            (Id, Vehicle, VehicleId, User, UserId, PublicationData, Description, Price, Location) = (Guid.NewGuid(), vehicle, vehicle.Id, user, user.Id, DateTime.Now, description, price, location);
        public OfferModel(Guid id, VehicleModel vehicle, UserModel user, string description, float price, string location) =>
            (Id, Vehicle, VehicleId, User, UserId, PublicationData, Description, Price, Location) = (id, vehicle, vehicle.Id, user, user.Id, DateTime.Now, description, price, location);

        public VehicleModel Vehicle { get; set; }
        public Guid VehicleId { get; set; }

        public UserModel User { get; set; }
        public Guid UserId { get; set; }

        public DateTime PublicationData { get; set; }

        public string Description { get; set; }
        public float Price { get; set; }
        public string Location { get; set; }
    }
}
