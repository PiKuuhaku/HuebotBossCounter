using HuebotBossCounter.Domain.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuebotBossCounter.Domain.Entities
{
    public class Kills
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; } = ObjectId.GenerateNewId().ToString();
        public string BossName { get; set; }
        public int TotalDeaths { get; set; }
        public List<DropHistory> DropHistory { get; set; }
    }
}
