using CoreLayer.Results;

namespace BusinessLayer.Concrete
{
    public class TemporaryBasketService : ITemporaryBasketService
    {
        private readonly UnitOfWork _unitOfWork;
        public TemporaryBasketService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> AddAsync(TemporaryBaskets data)
        {
            return await _unitOfWork.RepoTemporaryBaskets.AsyncAdd(data).ContinueWith(x => _unitOfWork.SaveChange()).Result;
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            return await _unitOfWork.RepoTemporaryBaskets.AsyncDelete(x => x.Id == id).ContinueWith(x => _unitOfWork.SaveChange()).Result;
        }

        public Task<TemporaryBaskets> GetBasketsAsync(int basketId)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> PieceUpdateAsync(int id, bool process)
        {
            throw new NotImplementedException();
        }
    }
}
