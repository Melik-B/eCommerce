using AppCore.Business.Models.Results;
using AppCore.DataAccess.EntityFramework;
using AppCore.DataAccess.EntityFramework.Bases;
using Business.Models;
using Business.Services.Bases;
using DataAccess.Contexts;
using DataAccess.Entities;

namespace Business.Services
{
    public class CategoryService : ICategoryService
    {
        public RepoBase<Category, eCommerceContext> Repo { get; set; } = new Repo<Category, eCommerceContext>();

        public Result Add(CategoryModel model)
        {
            if (Repo.Query().Any(category => category.Name.ToUpper() == model.Name.ToUpper().Trim()))
                return new ErrorResult("A record exists for the category name you entered!");

            Category entity = new Category()
            {
                Name = model.Name.Trim(),
                Description = model.Description?.Trim()
            };
            Repo.Add(entity);
            return new SuccessResult();
        }

        public Result Delete(int id)
        {
            Category entity = Repo.Query(c => c.Id == id, "Products").SingleOrDefault();
            if (entity.Products != null && entity.Products.Count > 0)
            {
                return new ErrorResult("Category cannot be deleted because there are related products!");
            }
            Repo.Delete(entity);
            return new SuccessResult("Category has been successfully deleted.");
        }

        public void Dispose()
        {
            Repo.Dispose();
        }

        public IQueryable<CategoryModel> Query()
        {
            IQueryable<CategoryModel> query = Repo.Query("Products").OrderBy(c => c.Name).Select(c => new CategoryModel()
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                NumberOfProducts = c.Products.Count
            });
            return query;
        }

        public Result Update(CategoryModel model)
        {
            if (Repo.Query().Any(category => category.Name.ToUpper() == model.Name.ToUpper().Trim() && category.Id != model.Id))
                return new ErrorResult("A record exists for the category name you entered!");
            Category entity = Repo.Query().SingleOrDefault(category => category.Id == model.Id);
            entity.Name = model.Name.Trim();
            entity.Description = model.Description?.Trim();
            Repo.Update(entity);
            return new SuccessResult("Category has been successfully updated.");
        }
    }
}
