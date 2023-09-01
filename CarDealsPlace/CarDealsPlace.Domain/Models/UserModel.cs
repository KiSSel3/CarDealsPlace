using CarDealsPlace.Domain.Enums;

namespace CarDealsPlace.Domain.Models
{
    public class UserModel : BaseModel
    {
        public UserModel() =>
            (Id, Login, Password, Name, PhoneNumber, Email, ImageUrl, Role) = (Guid.Empty, "None", "None", "None", "None", "None", "None", RoleType.USER);
        public UserModel(string login, string password, string name, string phoneNumber, string email, string imageUrl, RoleType role = RoleType.USER) =>
            (Id, Login, Password, Name, PhoneNumber, Email, ImageUrl, Role) = (Guid.NewGuid(), login, password, name, phoneNumber, email, imageUrl, role);
        public UserModel(Guid id, string login, string password, string name, string phoneNumber, string email, string imageUrl, RoleType role = RoleType.USER) =>
            (Id, Login, Password, Name, PhoneNumber, Email, ImageUrl, Role) = (id, login, password, name, phoneNumber, email, imageUrl, role);

        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public RoleType Role { get; set; }
    }
}
