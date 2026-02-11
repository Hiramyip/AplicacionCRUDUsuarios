using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace AplicacionCRUD
{
    internal class UsuarioRepositorio
    {
        private readonly IMongoCollection<Usuario> _collection;

        public UsuarioRepositorio()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("CRUD");
            _collection = database.GetCollection<Usuario>("personas");
        }

        public List<Usuario> ObtenerTodos() => _collection.Find(_ => true).ToList();

        public void Insertar(Usuario usuario) => _collection.InsertOne(usuario);

        public void Actualizar(string id, Usuario usuario)
        {
            var filter = Builders<Usuario>.Filter.Eq(u => u.Id, id);
            _collection.ReplaceOne(filter, usuario);
        }

        public void Eliminar(string id) => _collection.DeleteOne(u => u.Id == id);
    }
}
