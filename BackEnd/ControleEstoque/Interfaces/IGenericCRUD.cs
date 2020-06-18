using MongoDB.Bson;
using System.Collections.Generic;

namespace ControleEstoque.Interfaces
{
    public interface IGenericCRUD<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(ObjectId id);
        void Delete(ObjectId id);
        void Insert(T obj);
        void ReplaceOne(ObjectId id, T obj);
    }
}