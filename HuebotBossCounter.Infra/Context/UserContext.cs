using HuebotBossCounter.Domain.Entities;
using HuebotBossCounter.Domain.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuebotBossCounter.Infra.Context
{
    public class UserContext: IUserContext
    {
        public UserContext()
        {
            var connectionString = "mongodb+srv://bosscounter:bosscounter@huebotcluster.cagsy.mongodb.net/?retryWrites=true&w=majority&appName=HuebotCluster";
            var baseDeDados = "boss";
            var colecaoCoberturas = "users";

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(baseDeDados);
            Usuario = database.GetCollection<Usuario>(colecaoCoberturas);
        }

        public IMongoCollection<Usuario> Usuario { get; }
    }
}
