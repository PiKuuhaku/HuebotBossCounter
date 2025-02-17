using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HuebotBossCounter.Domain.Entities
{
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; } = ObjectId.GenerateNewId().ToString();
        public string User { get; set; }
        public string Password { get; set; }
        public List<string> Permissions { get; set; }
    }
}
