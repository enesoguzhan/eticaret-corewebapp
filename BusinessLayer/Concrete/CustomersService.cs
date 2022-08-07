using CoreLayer.Results;

namespace BusinessLayer.Concrete
{
    internal class CustomersService : ICustomersService
    {
        private readonly IUnitOfWork unitOfWork;
        public CustomersService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [ExceptionAspect, LogAspect, PerformanceAspect]

        public async Task<IResult> AddAsync(Customers data)
        {
            return await unitOfWork.RepoCustomers.AsyncAdd(data).ContinueWith(s => unitOfWork.SaveChange()).Result;
        }
        [ExceptionAspect, LogAspect, PerformanceAspect]

        public async Task<IResult> DeleteAsync(int id)
        {
            return await unitOfWork.RepoCustomers.AsyncDelete(s => s.Id == id).ContinueWith(s => unitOfWork.SaveChange()).Result;
        }
        [PerformanceAspect]

        public async Task<IList<Customers>> GetAllCustomersAsync()
        {
            return await unitOfWork.RepoCustomers.AsyncGetAll();
        }
        [PerformanceAspect]

        public async Task<IList<Customers>> GetAllOrderFirstCustomerAsync(int id)
        {
            return await unitOfWork.RepoCustomers.AsyncGetAll(s => s.Id == id, s => s.Orders);
        }
        [PerformanceAspect]

        public async Task<Customers> GetFirstCustomersAsync(int id)
        {
            return await unitOfWork.RepoCustomers.AsyncFirst(s => s.Id == id);
        }
        [LogAspect, PerformanceAspect]

        public async Task<Customers> LoginAsync(string email, string password)
        {
            return await unitOfWork.RepoCustomers.Login(email, password);
        }
        [LogAspect, PerformanceAspect]

        public async Task<string> PasswordForgotAsync(string email)
        {
            return await unitOfWork.RepoCustomers.ForgotPassword(email);
        }
        [ExceptionAspect, LogAspect, PerformanceAspect]

        public async Task<IResult> UpdateAsync(Customers data)
        {
            return await unitOfWork.RepoCustomers.AsyncUpdate(data).ContinueWith(s => unitOfWork.SaveChange()).Result;
        }

    }
}
