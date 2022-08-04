using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;

namespace DataAccessLayer.Concrete
{
    public class TemporaryBasketsRepo : Repositories<TemporaryBaskets>, ITemporaryBasketsRepo
    {
        public TemporaryBasketsRepo(DbContext context) : base(context)
        {
        }
    }
}
