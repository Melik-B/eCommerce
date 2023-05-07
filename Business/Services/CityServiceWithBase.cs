using AppCore.Business.Models.Results;
using AppCore.Business.Services.Bases;
using AppCore.DataAccess.EntityFramework;
using AppCore.DataAccess.EntityFramework.Bases;
using Business.Models;
using DataAccess.Contexts;
using DataAccess.Entities;

namespace Business.Services
{
    public interface ICityService : IService<CityModel, City, eCommerceContext>
    {
        Result<List<CityModel>> List(int countryId);
    }

    public class CityService : ICityService
    {
        public RepoBase<City, eCommerceContext> Repo { get; set; } = new Repo<City, eCommerceContext>();

        public Result Add(CityModel model)
        {
            throw new NotImplementedException();
        }

        public Result Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Repo.Dispose();
        }

        public IQueryable<CityModel> Query()
        {
            return Repo.Query("Country").OrderBy(c => c.Name).Select(c => new CityModel()
            {
                Name = c.Name,
                Id = c.Id,
                CountryId = c.CountryId,

                CountryNameDisplay = c.Country.Name
            });
        }

        public Result Update(CityModel model)
        {
            throw new NotImplementedException();
        }

        public Result<List<CityModel>> List(int countryId)
        {
            var list = Query().Where(c => c.CountryId == countryId).ToList();
            return new SuccessResult<List<CityModel>>(list);
        }
    }
}
