using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuebotBossCounter.Domain.Models;

namespace HuebotBossCounter.Domain.Entities
{
    public class Boss
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; } = ObjectId.GenerateNewId().ToString();
        public string Name { get; set; }
        public List<DropChance> Drops { get; set; }
    }
}
