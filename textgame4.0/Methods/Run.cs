using Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    public class run
    {
        public static void RunAway()
        {
            Console.WriteLine("You ran away successfully, but you feel a bit embarrassed. You lose 2 coins for your cowardice(lmao).");
            Player.Coins -= 2;
            if (Player.Coins < 0) Player.Coins = 0; // Prevent negative coins
            Console.WriteLine($"You now have {Player.Coins} coins (Go broke).");
            Console.ReadLine();
        }
    }
}
