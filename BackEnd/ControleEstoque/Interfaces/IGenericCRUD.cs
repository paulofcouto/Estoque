using System;
using System.Linq;
using System.Linq.Expressions;

namespace ControleEstoque.Interfaces
{
    public interface IGenericCRUD <TEntity> where TEntity : class
    {
        IQueryable<TEntity> Get();
        TEntity GetToIds(params object[] objectId);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(params object[] objectId);
    }
}
