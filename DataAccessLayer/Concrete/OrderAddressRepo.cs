using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;

namespace DataAccessLayer.Concrete
{
    public class OrderAddressRepo : Repositories<OrderAddress>, IOrderAddressRepo
    {
        public OrderAddressRepo(DbContext context) : base(context)
        {
        }
    }
}
