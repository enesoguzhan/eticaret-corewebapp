using CoreLayer.Abstract;
using System.Linq.Expressions;

namespace DataAccessLayer.Repository
{
    /*
  *Bu Sınıf Generic Typdir Her türlü yapı ile çalışabilir anlamındadır.
  *where TENtity:class => Bu Repositories sadece Class yapılarını kabul edecektir
  *IEntity => Classlardan sadece IEntity Interfacesinde miras alanları kabul edecektir.

    NOT:Asekron programlama, sistemde bağımsız olarak sırasız bir şekilde arkaplanda işlemleri yaptırıp hazır olunca sisteme yansıtmamızı sağlayan bir kod yapısıdır, çok fazla asekron işlem
 sistemi zor duruma düşürür.
 Task=> İşlemin sonucun asekron dönüştüreceğini belirtir.
 Async => işlemin Asekron olarak yapacağını belirtir.
  */
    public interface IRepositories<TEntity> where TEntity : class, IEntity
    {
        public Task AsyncAdd(TEntity entity);
        public Task AsyncUpdate(TEntity entity);
        public Task<TEntity> AsyncFirst(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] include);
        public Task<IList<TEntity>> AsyncGetAll(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] include);
        public Task AsyncDelete(Expression<Func<TEntity, bool>> where);

    }
}
