using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;

namespace DataAccessLayer.Concrete
{
    public class CustomersRepo : Repositories<Customers>, ICustomersRepo
    {
        private readonly DbContext context;
        public CustomersRepo(DbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<string> ForgotPassword(string email)
        {
            var data = context.Set<Customers>().Where(s => s.Email == email).FirstOrDefault();
            if (data != null)
            {
                data.Password = new Random().Next(111111, 999999).ToString();
                return await Task.Run(() => context.Update(data)).ContinueWith(s => data.Password);
            }
            else
                return await Task.Run(() => "Kullanıcı Bulunamadı");
        }

        public async Task<Customers> Login(string email, string passwords)
        {
            var data = context.Set<Customers>().Where(s => s.Email == email && s.Password == passwords).FirstOrDefault();
            return await Task.Run(() => data);

        }
    }
}
