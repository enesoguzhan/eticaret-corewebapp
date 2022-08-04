using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;

namespace DataAccessLayer.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;
        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }
        private CategoriesRepo categories;
        private CustomersRepo customers;
        private OrderAddressRepo orderAddress;
        private OrderDetailsRepo orderDetails;
        private OrdersRepo orders;
        private ProductsRepo products;
        private TemporaryBasketsRepo temporaryBaskets;

        public ICategoriesRepo RepoCategories => categories ?? new CategoriesRepo(context);

        public ICustomersRepo RepoCustomers => customers ?? new CustomersRepo(context);

        public IOrderAddressRepo RepoOrderAddress => orderAddress ?? new OrderAddressRepo(context);

        public IOrderDetailsRepo RepoOrderDetails => orderDetails ?? new OrderDetailsRepo(context);

        public IOrdersRepo RepoOrders => orders ?? new OrdersRepo(context);

        public IProductsRepo RepoIProducts => products ?? new ProductsRepo(context);

        public ITemporaryBasketsRepo RepoTemporaryBaskets => temporaryBaskets ?? new TemporaryBasketsRepo(context);

        public async Task<string> SaveChange()
        {
            await context.Database.BeginTransactionAsync();
            try
            {
                return await context.SaveChangesAsync().ContinueWith(s => context.Database.CommitTransactionAsync()).ContinueWith(s => "İşlem Başarılı");
            }
            catch (Exception)
            {

                return await context.Database.RollbackTransactionAsync().ContinueWith(s => "İşlem Başarısız");

            }
        }
    }
}
