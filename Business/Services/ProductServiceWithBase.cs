using AppCore.Business.Models.Results;
using AppCore.Business.Services.Bases;
using AppCore.DataAccess.EntityFramework;
using AppCore.DataAccess.EntityFramework.Bases;
using Business.Models;
using DataAccess.Contexts;
using DataAccess.Entities;
using System.Globalization;

namespace Business.Services
{
    public interface IProductService : IService<ProductModel, Product, eCommerceContext>
    {

    }

    public class ProductService : IProductService
    {
        public RepoBase<Product, eCommerceContext> Repo { get; set; } = new Repo<Product, eCommerceContext>();

        public Result Add(ProductModel model)
        {
            if (Repo.Query().Any(p => p.Name.ToLower() == model.Name.ToLower().Trim()))
                return new ErrorResult("There is a record with the specified product name!");
            if (model.ExpirationDate.HasValue && model.ExpirationDate.Value < DateTime.Today)
                return new ErrorResult("The expiration date must be today or later!");
            Product entity = new Product()
            {
                Description = model.Description?.Trim(),
                Name = model.Name.Trim(),
                UnitPrice = model.UnitPrice.Value,
                CategoryId = model.CategoryId.Value,
                ExpirationDate = model.ExpirationDate,
                StockQuantity = model.StockQuantity.Value
            };
            Repo.Add(entity);
            return new SuccessResult("The product has been successfully added.");
        }

        public Result Delete(int id)
        {
            Repo.Delete(p => p.Id == id);
            return new SuccessResult("The product has been successfully deleted!");
        }

        public void Dispose()
        {
            Repo.Dispose();
        }

        public IQueryable<ProductModel> Query()
        {
            return Repo.Query("Category").OrderBy(p => p.Name).Select(p => new ProductModel()
            {
                Id = p.Id,
                Description = p.Description,
                Name = p.Name,
                UnitPrice = p.UnitPrice,
                CategoryId = p.CategoryId,
                ExpirationDate = p.ExpirationDate,
                StockQuantity = p.StockQuantity,

                UnitPriceDisplay = p.UnitPrice.ToString("C2", new CultureInfo("tr-TR")), // "tr-TR"

                ExpirationDateDisplay = p.ExpirationDate.HasValue ? p.ExpirationDate.Value.ToString("yyyy-MM-dd") : "",

                CategoryNameDisplay = p.Category.Name
            });
        }

        public Result Update(ProductModel model)
        {
            if (Repo.Query().Any(p => p.Name.ToLower() == model.Name.ToLower().Trim() && p.Id != model.Id))
                return new ErrorResult("There is a record with the specified product name!");
            if (model.ExpirationDate.HasValue && model.ExpirationDate.Value < DateTime.Today)
                return new ErrorResult("The expiration date must be today or later!");
            Product entity = Repo.Query(p => p.Id == model.Id).SingleOrDefault();
            entity.Name = model.Name.Trim();
            entity.Description = model.Description?.Trim();
            entity.UnitPrice = model.UnitPrice.Value;
            entity.CategoryId = model.CategoryId.Value;
            entity.ExpirationDate = model.ExpirationDate;
            entity.StockQuantity = model.StockQuantity.Value;
            Repo.Update(entity);
            return new SuccessResult();
        }
    }
}
