using CoreLayer.Results;

namespace BusinessLayer.Concrete
{
    public class OrdersRelationService : IOrdersRelationService
    {
        private readonly UnitOfWork _unitOfWork;
        public OrdersRelationService(UnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
        }

        [ExceptionAspect, LogAspect, PerformanceAspect]
        public async Task<IResult> AllAddAsync(Orders data)
        {
            return await _unitOfWork.RepoOrders.AsyncAdd(data).ContinueWith(s =>
              {
                  foreach (var item in data.OrderDetails)
                  {
                      item.OrdersId = data.Id;
                      _unitOfWork.RepoOrderDetails.AsyncAdd(item);
                  }
              }).ContinueWith(s =>
              {
                  foreach (var item in data.OrderAddress)
                  {
                      item.OrdersId = data.Id;
                      _unitOfWork.RepoOrderAddress.AsyncAdd(item);
                  }
              }).ContinueWith(s => _unitOfWork.SaveChange()).Result;
        }

        [PerformanceAspect]
        public async Task<IList<Orders>> GetAllOrders()
        {
            return await _unitOfWork.RepoOrders.AsyncGetAll();
        }

        [PerformanceAspect]
        public async Task<Orders> GetOrdersRelationById(int id)
        {
            return await _unitOfWork.RepoOrders.AsyncFirst(s => s.Id == id, s => s.OrderAddress, s => s.OrderDetails, s => s.Customers);
        }

        [ExceptionAspect, LogAspect, PerformanceAspect]
        public async Task<IResult> UpdateAsync(Orders data)
        {
            return await _unitOfWork.RepoOrders.AsyncUpdate(data).ContinueWith(x => _unitOfWork.SaveChange()).Result;
        }
    }
}
