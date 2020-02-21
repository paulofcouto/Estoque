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

        public Usuario Get(ObjectId id) =>
            _usuario.Find<Usuario>(usuario => usuario._id == id).FirstOrDefault();

        public Usuario Create(Usuario usuario)
        {
            _usuario.InsertOne(usuario);
            return usuario;
        }

        public void Update(ObjectId id, Usuario usuarioIn) =>
            _usuario.ReplaceOne(usuario => usuario._id == id, usuarioIn);

        public void Remove(Usuario usuarioIn) =>
            _usuario.DeleteOne(usuario => usuario._id == usuarioIn._id);

        public void Remove(ObjectId id) =>
            _usuario.DeleteOne(usuario => usuario._id == id);
    }
}