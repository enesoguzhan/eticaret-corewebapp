using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;

namespace DataAccessLayer.Concrete
{
    public class OrderDetailsRepo : Repositories<OrderDetails>, IOrderDetailsRepo
    {
        public OrderDetailsRepo(DbContext context) : base(context)
        {
        }
    }
}
