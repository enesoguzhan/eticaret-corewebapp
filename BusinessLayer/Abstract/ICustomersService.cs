using CoreLayer.Results;

namespace BusinessLayer.Abstract
{
    public interface ICustomersService
    {
        public Task<IResult> AddAsync(Customers data);
        public Task<IResult> UpdateAsync(Customers data);
        public Task<IResult> DeleteAsync(int id);
        public Task<Customers> GetFirstCustomersAsync(int id);
        public Task<IList<Customers>> GetAllCustomersAsync();
        public Task<IList<Customers>> GetAllOrderFirstCustomerAsync(int id);
        public Task<Customers> LoginAsync(string email, string password);
        public Task<string> PasswordForgotAsync(string email);
    }
}
