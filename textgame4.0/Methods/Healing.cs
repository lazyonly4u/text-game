using Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    // Represents a healing item (like a potion, food, etc.)
    public class Healing
    {
        // Name of the healing item (e.g., "Health Potion")
        public string Name { get; set; }

        // Cost of the healing item (in coins or some currency)
        public int Cost { get; set; }

        // Amount of health this item restores when used
        public int Heal { get; set; }

        // Constructor to initialize a healing item with its name, cost, and healing power
        public Healing(string Name, int Cost, int Heal)
        {
            this.Name = Name;
            this.Cost = Cost;
            this.Heal = Heal;
        }
    }
}
