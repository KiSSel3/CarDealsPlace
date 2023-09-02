using CarDealsPlace.Domain.Models;
using CarDealsPlace.Domain.Response;
using CarDealsPlace.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarDealsPlace.Service.Interfaces
{
    public interface IUserService
    {
        public Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model);
        public Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model);
        public Task<BaseResponse<UserModel>> GetById(Guid id);
        public Task<BaseResponse<UserModel>> GetByLogn(string login);

    }
}
