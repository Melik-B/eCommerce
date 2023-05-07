using AppCore.Business.Models.Results;
using AppCore.Business.Services.Bases;
using AppCore.DataAccess.EntityFramework;
using AppCore.DataAccess.EntityFramework.Bases;
using Business.Models;
using DataAccess.Contexts;
using DataAccess.Entities;

namespace Business.Services
{
    public interface ICountryService : IService<CountryModel, Country, eCommerceContext>
    {

    }

    public class CountryService : ICountryService
    {
        public RepoBase<Country, eCommerceContext> Repo { get; set; } = new Repo<Country, eCommerceContext>();

        public Result Add(CountryModel model)
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

        public IQueryable<CountryModel> Query()
        {
            return Repo.Query().OrderBy(c => c.Name).Select(c => new CountryModel()
            {
                Name = c.Name,
                Id = c.Id
            });
        }

        public Result Update(CountryModel model)
        {
            throw new NotImplementedException();
        }
    }
}
