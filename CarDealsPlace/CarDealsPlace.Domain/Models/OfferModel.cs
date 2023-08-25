using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealsPlace.Domain.Models
{
    public class OfferModel : BaseModel
    {
        public VehicleModel Vehicle { get; set; }
        public UserModel User { get; set; }

        public DateTime PublicationData { get; set; }

        public string Description { get; set; }
        public float Price { get; set; }
    }
}
