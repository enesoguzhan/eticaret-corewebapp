using CoreLayer.Results;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IOrdersRelationService
    {
        public Task<IResult> AllAddAsync(Orders data);
        public Task<IResult> UpdateAsync(Orders data);
        //public Task<IResult> UpdateDetailsAsync(OrderDetails data);
        //public Task<IResult> UpdateAddressAsync(OrderAddress data);
        public Task<IList<Orders>> GetAllOrders();
        public Task<Orders> GetOrdersRelationById(int id);
    }
}
