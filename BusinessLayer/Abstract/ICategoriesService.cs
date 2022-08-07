using CoreLayer.Results;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoriesService
    {
        public Task<IResult> AddAsync(Categories data);
        public Task<IResult> UpdateAsync(Categories data);
        public Task<IResult> DeleteAsync(int Id);
        public Task<IList<Categories>> GetAllCategoriesAsync();
        public Task<Categories> GetAllProductsFirstCategoriesAsync(int categoriesId);
        public Task<Categories> GetFirstCategoriesAsync(int categoriesID);
    }
}
