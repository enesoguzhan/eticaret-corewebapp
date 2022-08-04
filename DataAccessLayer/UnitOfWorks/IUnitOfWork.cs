﻿using DataAccessLayer.Abstract;

namespace DataAccessLayer.UnitOfWorks
{
    public interface IUnitOfWork
    { 
        public ICategoriesRepo RepoCategories { get; }
        public ICustomersRepo RepoCustomers { get; }
        public IOrderAddressRepo RepoOrderAddress { get; }
        public IOrderDetailsRepo RepoOrderDetails { get; }
        public IOrdersRepo RepoOrders { get; }
        public IProductsRepo RepoIProducts { get; }
        public ITemporaryBasketsRepo RepoTemporaryBaskets { get; }
        public Task<string> SaveChange();
    }
}
