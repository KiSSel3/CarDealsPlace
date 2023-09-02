using CarDealsPlace.Domain.Models;
using CarDealsPlace.Domain.Response;
using CarDealsPlace.Domain.ViewModels;
using CarDealsPlace.Service.Interfaces;
using CarDealsPlace.Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarDealsPlace.Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserStorage userStorage;

        public UserService(IUserStorage userStorage) => (this.userStorage) = (userStorage);

        public async Task<BaseResponse<UserModel>> GetById(Guid id)
        {
            try
            {
                UserModel user = await userStorage.GetByIdAsync(id);

                if (user == null)
                    return new BaseResponse<UserModel>(HttpStatusCode.InternalServerError, "There is no user with this id");

                return new BaseResponse<UserModel>(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                return new BaseResponse<UserModel>(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<BaseResponse<UserModel>> GetByLogn(string login)
        {
            try
            {
                UserModel user = await userStorage.GetByLoginAsync(login);

                if (user == null)
                    return new BaseResponse<UserModel>(HttpStatusCode.InternalServerError, "There is no user with that login");

                return new BaseResponse<UserModel>(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                return new BaseResponse<UserModel>(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model)
        {
            try
            {
                UserModel user = await userStorage.GetByLoginAsync(model.Login);

                if (user == null)
                    return new BaseResponse<ClaimsIdentity>(HttpStatusCode.InternalServerError, "Login or password entered incorrectly");

                if(user.Password != model.Password)
                    return new BaseResponse<ClaimsIdentity>(HttpStatusCode.InternalServerError, "Login or password entered incorrectly");

                ClaimsIdentity claimsIdentity = Authenticate(user);

                return new BaseResponse<ClaimsIdentity>(HttpStatusCode.OK, claimsIdentity);
            }
            catch(Exception ex)
            {
                return new BaseResponse<ClaimsIdentity>(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model)
        {
            try
            {
                UserModel user = null;

                user = await userStorage.GetByLoginAsync(model.Login);
                if(user != null)
                    return new BaseResponse<ClaimsIdentity>(HttpStatusCode.InternalServerError, "This login is already in use");

                user = await userStorage.GetByEmailAsync(model.Email);
                if (user != null)
                    return new BaseResponse<ClaimsIdentity>(HttpStatusCode.InternalServerError, "This email is already in use");

                user = await userStorage.GetByPhoneNumberAsync(model.PhoneNumber);
                if (user != null)
                    return new BaseResponse<ClaimsIdentity>(HttpStatusCode.InternalServerError, "This phone number is already in use");

                user = new UserModel(model.Login, model.Password, model.Name, model.PhoneNumber, model.Email, ServiceConstants.StandardAvatarUrl);

                await userStorage.CreateAsync(user);

                ClaimsIdentity claimsIdentity = Authenticate(user);

                return new BaseResponse<ClaimsIdentity>(HttpStatusCode.OK, claimsIdentity);

            }
            catch (Exception ex)
            {
                return new BaseResponse<ClaimsIdentity>(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        private ClaimsIdentity Authenticate(UserModel user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString()),
            };

            return new ClaimsIdentity(claims, "Authentication", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
