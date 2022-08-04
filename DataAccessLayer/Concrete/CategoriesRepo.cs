using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;

namespace DataAccessLayer.Concrete
{
    public class CategoriesRepo : Repositories<Categories>, ICategoriesRepo
    {
        public CategoriesRepo(DbContext context) : base(context)
        {
        }
    }
}
