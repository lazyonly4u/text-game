using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Methods;

namespace Methods
{
    public class Health
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Heal { get; set; }
        public Health(string Name, int Cost, int Heal)
        {
            this.Name = Name;
            this.Cost = Cost;
            this.Heal = Heal;
        }
    }
}
