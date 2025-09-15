using Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    public class Player
    {
        public static int Health { get; set; } = 100;
        public static int Coins { get; set; } = 10;
        public static string Weapon { get; set; }
        public static List<string> Items { get; set; } = new List<string>();
        public static Room CurrentRoom { get; set; }
        public static void DisplayStats()
        {
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"Coins: {Coins}");
            Console.WriteLine($"Weapon: {Weapon}");
            Console.WriteLine("Items: " + (Items.Count > 0 ? string.Join(", ", Items) : "None"));
        }
    }
}
