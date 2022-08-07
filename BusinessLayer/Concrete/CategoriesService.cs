using CoreLayer.Results;

namespace BusinessLayer.Concrete
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoriesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [ExceptionAspect, LogAspect, PerformanceAspect]
        public async Task<IResult> AddAsync(Categories data)
        {
            return await _unitOfWork.RepoCategories.AsyncAdd(data).ContinueWith(s => _unitOfWork.SaveChange()).Result;
        }

        [ExceptionAspect, LogAspect, PerformanceAspect]
        public async Task<IResult> DeleteAsync(int Id)
        {
            return await _unitOfWork.RepoCategories.AsyncDelete(s => s.Id == Id).ContinueWith(s => _unitOfWork.SaveChange()).Result;

        }

        [PerformanceAspect]
        public async Task<IList<Categories>> GetAllCategoriesAsync()
        {
            return await _unitOfWork.RepoCategories.AsyncGetAll();
        }
        [PerformanceAspect]
        public async Task<Categories> GetAllProductsFirstCategoriesAsync(int categoriesId)
        {
            return await _unitOfWork.RepoCategories.AsyncFirst(s => s.Id == categoriesId, s => s.Products);
        }
        [PerformanceAspect]
        public async Task<Categories> GetFirstCategoriesAsync(int categoriesID)
        {
            return await _unitOfWork.RepoCategories.AsyncFirst(s => s.Id == categoriesID);
        }

        [ExceptionAspect, LogAspect, PerformanceAspect]
        public async Task<IResult> UpdateAsync(Categories data)
        {
            return await _unitOfWork.RepoCategories.AsyncUpdate(data).ContinueWith(s => _unitOfWork.SaveChange()).Result;
        }
    }
}
