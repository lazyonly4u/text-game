# text-game



using Methods;
using System;
namespace calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Congracts truck-kun ran you over and now you have regressed to the game world of Slimes, Stabs, & Stuff. Your mission win and try not to die");
            Console.ReadLine();
            Console.WriteLine("which you will");
            //disapears after 1 second
            System.Threading.Thread.Sleep(1000);
            Console.Clear();

            Console.WriteLine("You look up and see a door with a sign saying : Hello sacrafice #584");
            //disapears after 4 seconds
            System.Threading.Thread.Sleep(4000);
            Console.Clear();

            Console.WriteLine("You blink and when you open your eyes the sign says: Hello adventurerer there are 7 levels.");
            Console.WriteLine("After each level you will unlock a new one. You will always have a choice of going back a level to grind or find more loot.");
            Console.WriteLine("Though you can choos to fight a monster of run but picking run during a battle will have consiquences, so pick at your own expense ");
            Console.WriteLine("You can also choose to go to the shop to buy items and you can also choose to open your inventory to see what you have.");
            Console.WriteLine("May the Great Winged Lion have mercy on you");
            Console.ReadLine();
            Console.Clear();
           
            Console.WriteLine("You see a door apear out of nowhere with a wooden sword in front of the door(congrats on your first weapon!)");
            Console.WriteLine("Do you choose to pick up the weapon?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                Console.WriteLine("You pick up the wooden sword and feel a surge of power");
                Console.WriteLine("You now have a weapon to fight with");
                Rooms.room1();

            }
            else if (choice == "2")
            {
                Console.WriteLine("You choose not to pick up the wooden sword and feel a bit underpowered");
                Console.WriteLine("You will have to fight without a weapon for now");
            }
            else
            {
                Console.WriteLine("Invalid choice, you lose your chance to pick up the weapon");
            }




        }
    }
}
