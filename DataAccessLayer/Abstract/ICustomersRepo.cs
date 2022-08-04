using DataAccessLayer.Repository;

namespace DataAccessLayer.Abstract
{
    public interface ICustomersRepo : IRepositories<Customers>
    {
        public Task<Customers> Login(string email, string passwords);
        public Task<string> ForgotPassword(string email);
    }
}
