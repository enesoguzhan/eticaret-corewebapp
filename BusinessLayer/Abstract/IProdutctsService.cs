using CoreLayer.Results;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IProdutctsService
    {
        public Task<IResult> AddAsync(Products data);
        public Task<IResult> UpdateAsync(Products data);
        public Task<IResult> DeleteAsync(int id);
        public Task<IList<Products>> GetAllProducts();
        public Task<Products> GetRelationProduct(int id); // 1 Productsa ait 1 Categories
    }
}
