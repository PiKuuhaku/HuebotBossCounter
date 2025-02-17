using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuebotBossCounter.Domain.Models
{
    public class DropHistory
    {
        public int KillNumber { get; set; }
        public int PlayersInLobby { get; set; }
        public List<PlayerDrop> Drops { get; set; }
    }
}
