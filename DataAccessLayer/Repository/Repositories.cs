using CoreLayer.Abstract;
using System.Linq.Expressions;

namespace DataAccessLayer.Repository
{
    public class Repositories<TEntity> : IRepositories<TEntity> where TEntity : class, IEntity
    {
        private readonly DbContext context;
        public Repositories(DbContext context)
        {
            this.context = context;
        }

        public async Task AsyncAdd(TEntity entity)
        {
            await context.AddAsync(entity);
        }

        public async Task AsyncDelete(Expression<Func<TEntity, bool>> where)
        {
            await Task.Run(() => context.Remove(AsyncFirst(where).Result));
        }

        public async Task<TEntity> AsyncFirst(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] include)
        {
            /*
             IQueryable => Sql tarafında filtreleme yapıp filtrelenmiş dataları rama yansıtırız
            IList=> sqldeki bütün dataları rama e aktarıp filtreleme yapıp ekrana yansıtmamızı sağlar.
            */

            IQueryable<TEntity> query = context.Set<TEntity>().Where(where);
            if (include.Any())
            {
                foreach (var item in include)
                {
                    query = query.Include(item);
                }
            }
            return await query.FirstAsync();
        }

        public async Task<IList<TEntity>> AsyncGetAll(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] include)
        {
            IQueryable<TEntity> query = null;
            if (where != null)
            {
                query = context.Set<TEntity>().Where(where);
            }
            else
            {
                query = context.Set<TEntity>();
            }

            if (include.Any())
            {
                foreach (var item in include)
                {
                    query = query.Include(item);
                }
            }
            return await query.ToListAsync();
        }

        public async Task AsyncUpdate(TEntity entity)
        {
            await Task.Run(() => context.Update(entity));
        }
    }
}
