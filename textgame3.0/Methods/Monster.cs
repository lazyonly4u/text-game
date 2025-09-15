using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Methods;

namespace Methods
{
    public class Monster
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Coins { get; set; }
        public int SpawnPoint { get; set; }
        public Monster(string Name, int Health, int Damage, int Coins, int spawnPoint)
        {
            this.Name = Name;
            this.Health = Health;
            this.Damage = Damage;
            this.Coins = Coins;
            this.SpawnPoint = spawnPoint;
        }
    }
}
