using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AplicacionCRUD
{
    internal class Usuario
    {
        [BsonId] // Esto indica que es la llave primaria de MongoDB
        [BsonRepresentation(BsonType.ObjectId)] // Permite manejarlo como string en C#
        public string Id { get; set; }

        public string Nombre { get; set; }
        public int Puntos { get; set; }

    }
}
