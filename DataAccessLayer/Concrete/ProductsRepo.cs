using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;

namespace DataAccessLayer.Concrete
{
    public class ProductsRepo : Repositories<Products>, IProductsRepo
    {
        public ProductsRepo(DbContext context) : base(context)
        {
        }
    }
}
