using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    public class Exit
    {
        public static void ExitGame()
        {
            Console.WriteLine("Are you SURE you want to exit??? (yes/no)");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "yes")
            {
                Console.WriteLine("Dawm ok... Farewell Adventurere, May the abyss be to your liking ");
                Console.ReadLine();
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Returning to the game...");
                Console.ReadLine();
                return;
            }
        }
    }
}
