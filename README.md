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
            System.Threading.Thread.Sleep(1000);
            Console.Clear();


            Console.WriteLine("You look up and see a door with a sign saying : Hello sacrafice #584");
            System.Threading.Thread.Sleep(3500);
            Console.Clear();

            Console.WriteLine("You blink and when you open your eyes the sign says: Hello adventurerer there are 7 levels.");
            Console.WriteLine("After each level you will unlock a new one. You will always have a choice of going back a level to grind or find more loot.");
            Console.WriteLine("Though you can choos to fight a monster of run but picking run during a battle will have consiquences, so pick at your own expense ");
            Console.WriteLine("You can also choose to go to the shop to buy items and you can also choose to open your inventory to see what you have.");
            Console.WriteLine("May the Great Winged Lion have mercy on you");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("You see a door apear out of nowhere with a wooden sword in front of the door(congrats on your first weapon!)");
            Console.WriteLine("Do you want to equip it? (yes/no)");
            string equipChoice = Console.ReadLine();
            if (equipChoice.ToLower() == "yes")
            {
                Player.Weapon = "Wooden Sword";
                Console.WriteLine("You equipped the Wooden Sword!");
            }
            else if (equipChoice.ToLower() == "no")
            {
                Console.WriteLine("You keep your current weapon: " + Player.Weapon);
            }
            else
            {
                Console.WriteLine("Invalid choice, you lose your chance to pick up the weapon");
            }


            Rooms Level1 = new Rooms("Fungus Among Us", "Beside the door is a sign that says: Level 1 - Fungus Among Us");
            Rooms Level2 = new Rooms("Slime Schlime Time", "A door Suddenly appears with markings: Level 2 - Slime Schlime Time");
            Rooms Level3 = new Rooms("Nestflix & Chill", "A door not so suprisingly appears with markings: Level 3 - Nestflix & Chill");
            Rooms Level4 = new Rooms("Oops, You’re Drowning", "This time a fancy roman door appears(Very shinny): Level 4 - Pool of “Oops, You’re Drowning");
            Rooms Level5 = new Rooms("The Dino-Den of Doom", "From a fancy door to a basic wooden door(don't judge a book by it cover...we had to rush this) on the now basic door is a sign that says: Level 5 - The Dino-Den of Doom");
            Rooms Level6 = new Rooms("Rock ‘n’ Roar Hideout", "Beside the door is a paper sign that says: Level 6 - Rock ‘n’ Roar Hideout");
            Rooms Level7 = new Rooms("The unknown", "Suddenly, a golden door materializes (the third most expensive thing in the dungeon) With letters encapsulated in diamond saying: Level 7 - The unknown.");



            int currentRoom = 0;
            bool playing = true;


            while (playing)
            {
                rooms[currentRoom].Display();
                Console.WriteLine("\nWhat do you want to do?");
                Console.WriteLine("1. Go to next room");
                Console.WriteLine("2. Go to previous room");
                Console.WriteLine("3. Open inventory");
                Console.WriteLine("4. Go to shop");
                Console.WriteLine("5. Exit game");

                string action = Console.ReadLine();
                switch (action)
                {
                    case "1":
                        if (currentRoom < rooms.Length - 1)
                        {
                            currentRoom++;
                        }
                        else
                        {
                            Console.WriteLine("You are already in the last room.");
                        }
                        break;
                    case "2":
                        if (currentRoom > 0)
                        {
                            currentRoom--;
                        }
                        else
                        {
                            Console.WriteLine("You are already in the first room.");
                        }
                        break;
                    case "3":
                        Inventory.DisplayInventory();
                        break;
                    case "4":
                        Shop.DisplayShop();
                        break;
                    case "5":
                        playing = false;
                        Console.WriteLine("Thanks for playing!");
                        break;
                    default:
                        Console.WriteLine("Invalid action. Please choose again.");
                        break;
                }
            }
        }

    }
}
