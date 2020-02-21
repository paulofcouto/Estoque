using ControleEstoque.Interfaces;
using System;
using System.Linq;

namespace ControleEstoque.Services
{
    public class GenericCRUD<TEntity> : IGenericCRUD<T>
    {
        private TEntity _entity;


        public IQueryable<T> Get()
        {
            return _entity.
        }

        public T GetToIds(params object[] objectId)
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(params object[] objectId)
        {
            _entity.Delete(objectId);
        }
    }
}
