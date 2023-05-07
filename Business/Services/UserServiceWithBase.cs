using AppCore.Business.Models.Results;
using AppCore.Business.Services.Bases;
using AppCore.DataAccess.EntityFramework;
using AppCore.DataAccess.EntityFramework.Bases;
using Business.Models;
using DataAccess.Contexts;
using DataAccess.Entities;

namespace Business.Services
{
    public interface IUserService : IService<UserModel, User, eCommerceContext>
    {

    }

    public class UserService : IUserService
    {
        public RepoBase<User, eCommerceContext> Repo { get; set; } = new Repo<User, eCommerceContext>();

        public Result Add(UserModel model)
        {
            if (Repo.EntityExists(u => u.UserName == model.UserName))
                return new ErrorResult("This username has already been taken");
            if (Repo.EntityExists(u => u.UserDetail.Email.ToLower() == model.Email.ToLower().Trim()))
                return new ErrorResult("This email is already in use!");
            User entity = new User()
            {
                IsActive = model.IsActive,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                RoleId = model.RoleId,
                Password = model.Password,
                UserDetail = new UserDetail()
                {
                    Address = model.Address,
                    Gender = model.Gender,
                    Email = model.Email,
                    CityId = model.CityId.Value,
                    CountryId = model.CountryId.Value
                }
            };
            Repo.Add(entity);
            return new SuccessResult();
        }

        public Result Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Repo.Dispose();
        }

        public IQueryable<UserModel> Query()
        {
            return Repo.Query("Role").Select(e => new UserModel()
            {
                IsActive = e.IsActive,
                Id = e.Id,
                FirstName= e.FirstName,
                LastName= e.LastName,
                UserName = e.UserName,
                RoleId = e.RoleId,
                Password = e.Password,

                RoleNameDisplay = e.Role.Name
            });
        }

        public Result Update(UserModel model)
        {
            throw new NotImplementedException();
        }
    }
}
