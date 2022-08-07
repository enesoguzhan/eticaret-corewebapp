using CoreLayer.Results;

namespace BusinessLayer.Concrete
{
    public class ProductsService : IProdutctsService
    {
        private readonly UnitOfWork _unitOfWork;
        public ProductsService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [ExceptionAspect, LogAspect, PerformanceAspect]
        public async Task<IResult> AddAsync(Products data)
        {
            return await _unitOfWork.RepoProducts.AsyncAdd(data).ContinueWith(s => _unitOfWork.SaveChange()).Result;
        }
        [ExceptionAspect, LogAspect, PerformanceAspect]

        public async Task<IResult> DeleteAsync(int id)
        {
            return await _unitOfWork.RepoProducts.AsyncDelete(s => s.Id == id).ContinueWith(s => _unitOfWork.SaveChange()).Result;
        }

        [PerformanceAspect]
        public async Task<IList<Products>> GetAllProducts()
        {
            return await _unitOfWork.RepoProducts.AsyncGetAll();
        }

        [PerformanceAspect]
        public async Task<Products> GetRelationProduct(int id)
        {
            return await _unitOfWork.RepoProducts.AsyncFirst(s => s.Id == id, s => s.Categories);
        }

        [ExceptionAspect, LogAspect, PerformanceAspect]
        public async Task<IResult> UpdateAsync(Products data)
        {
            return await _unitOfWork.RepoProducts.AsyncUpdate(data).ContinueWith(s => _unitOfWork.SaveChange()).Result;
        }
    }
}
