using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;

namespace DataAccessLayer.Concrete
{
    public class OrdersRepo : Repositories<Orders>, IOrdersRepo
    {
        public OrdersRepo(DbContext context) : base(context)
        {
        }
    }
}
