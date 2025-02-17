using HuebotBossCounter.Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuebotBossCounter.Domain.Interfaces
{
    public interface IKillsContext
    {
        IMongoCollection<Kills> Kills { get; }
    }
}
