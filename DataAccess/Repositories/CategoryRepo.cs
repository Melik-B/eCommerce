using DataAccess.Contexts;
using DataAccess.Repositories.Bases;

namespace DataAccess.Repositories
{
    public class CategoryRepo: CategoryRepoBase
    {
        public CategoryRepo() : base()
        {

        }

        public CategoryRepo(eCommerceContext ecommerceContext) : base(ecommerceContext)
        {

        }
    }
}
