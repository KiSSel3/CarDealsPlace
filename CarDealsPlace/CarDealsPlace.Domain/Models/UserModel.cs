namespace CarDealsPlace.Domain.Models
{
    public class UserModel : BaseModel
    {
        public UserModel() =>
            (Id, Login, Password, Name, PhoneNumber, Email, ImageUrl) = (Guid.Empty, "None", "None", "None", "None", "None", "None");
        public UserModel(string login, string password, string name, string phoneNumber, string email, string imageUrl) =>
            (Id, Login, Password, Name, PhoneNumber, Email, ImageUrl) = (Guid.NewGuid(), login, password, name, phoneNumber, email, imageUrl);
        public UserModel(Guid id, string login, string password, string name, string phoneNumber, string email, string imageUrl) =>
            (Id, Login, Password, Name, PhoneNumber, Email, ImageUrl) = (id, login, password, name, phoneNumber, email, imageUrl);

        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
    }
}
