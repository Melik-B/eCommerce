using AppCore.Business.Models.Results;
using Business.Enums;
using Business.Models;
using DataAccess.Entities;

namespace Business.Services
{
    public interface IAccountService
    {
        Result<UserModel> Login(UserLoginModel model);
        Result Registration(UserRegistrationModel model);
    }

    public class AccountService : IAccountService
    {
        private readonly IUserService _userService;

        public AccountService(IUserService userService)
        {
            _userService = userService;
        }

        public Result<UserModel> Login(UserLoginModel model)
        {
            UserModel user = _userService.Query().SingleOrDefault(u => u.UserName == model.UserName && u.Password == model.Password && u.IsActive);
            if (user == null)
                return new ErrorResult<UserModel>("Invalid username and password!");
            return new SuccessResult<UserModel>(user);
        }

        public Result Registration(UserRegistrationModel model)
        {
            UserModel user = new UserModel()
            {
                IsActive = true,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                RoleId = (int)Roles.User,
                Password = model.Password,
                Address = model.Address.Trim(),
                Email = model.Email.Trim(),
                CountryId = model.CountryId,
                CityId = model.CityId,
                Gender = model.Gender,
            };
            return _userService.Add(user);
        }
    }
}
