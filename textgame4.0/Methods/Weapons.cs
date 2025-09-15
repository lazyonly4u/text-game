using Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    public class Weapons
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Damage { get; set; }
        public bool IsRanged { get; set; }
        public int UsesLeft { get; set; }
        public Weapons(string Name, int Cost, int Damage, bool IsRanged, int UsesLeft)
        {
            this.Name = Name;
            this.Cost = Cost;
            this.Damage = Damage;
            this.IsRanged = IsRanged;
            this.UsesLeft = UsesLeft;
        }
        public bool IsUsable()
        {
            return UsesLeft > 0;
        }
        public void Use()
        {
            if (UsesLeft > 0)
            {
                UsesLeft--;
            }
            else
            {
                Console.WriteLine($"The weapon {Name} has no uses left and cannot be used :/");
                Console.ReadLine();
            }
        }
    }
    public static class WeaponLibrary
    {
        public static List<Weapons> AllWeapons = new List<Weapons>
        {
        new Weapons("Wooden Sword", 0, 5, false, 10),
        new Weapons("Espada Bastarda", 16, 15, false, 15),
        new Weapons("Rapier", 22, 20, false, 20),
        new Weapons("Arabian scimitar sword", 30, 35, false, 35),
        new Weapons("Kukri", 10, 10, false, 15),
        new Weapons("The Yumi Bow", 13, 15, true, 15),
        new Weapons("Manchu Bow", 35, 35, true, 20)
        };
    }
}
