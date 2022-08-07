using CoreLayer.Results;
using EntityLayer;

namespace BusinessLayer.Abstract
{
    public interface ITemporaryBasketService
    {
        public Task<IResult> AddAsync(TemporaryBaskets data);
        public Task<IResult> DeleteAsync(int id);
        public Task<IResult> PieceUpdateAsync(int id, bool process);
        public Task<TemporaryBaskets> GetBasketsAsync(int basketId);
    }
}
