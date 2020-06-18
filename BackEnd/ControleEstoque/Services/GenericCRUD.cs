using ControleEstoque.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleEstoque.Services
{
    public class GenericCRUD<TEntity> : IGenericCRUD<T>
    {
        protected readonly IMongoCollection<T> _collection;

        public IEnumerable<T> GetAll()
        {
            return _collection.Find<T>(new BsonDocument()).ToEnumerable();
        }

        public T GetById(ObjectId id)
        {
            var filter = Builders<T>.Filter.Eq("id", id);
            return _collection.Find<T>(filter).FirstOrDefault();
        }

        public void Delete(ObjectId id)
        {
            var filter = Builders<T>.Filter.Eq("id", id);
            _collection.DeleteOne(filter);
        }

        public void Insert(T obj)
        {
            _collection.InsertOne(obj);
        }

        /// <summary>
        /// Este metódo deleta todos os valores de objeto 'T' e substitui por todos os valores contidos no 'obj'
        /// </summary>
        /// <param name="id">id do objeto a ser 'deletado'</param>
        /// <param name="obj">objeto que irá substitur o objeto existente</param>
        public void ReplaceOne(ObjectId id, T obj)
        {
            var filter = new FilterDefinitionBuilder<T>().Eq("id", id);
            _collection.ReplaceOne(filter, obj);
        }
    }

    public class T {}
}
