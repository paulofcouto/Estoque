using System.Linq;
using MongoDB.Driver;
using ControleEstoque.Interfaces;
using ControleEstoque.Models;
using MongoDB.Bson;

namespace ControleEstoque.Services
{
    public class UsuarioService : GenericCRUD
    {
        private readonly IMongoCollection<Usuario> _usuario;

        public UsuarioService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _usuario = database.GetCollection<Usuario>(settings.CollectionName);
        }

    }

    public class GenericCRUD{}
}