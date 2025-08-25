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


            Rooms Level1 = new Rooms("Fungus Among Us", "Beside the door is a sign that says: Level 1 - Fungus Among Us. You open the door and see a dungeon room almost masks itself as a forest. And suprisingly its filled with waking mushrooms. Do you wish to fight? or hide away like a coward");
            Rooms Level2 = new Rooms("Slime Schlime Time", "Congrats you've survived though Level 1! A door Suddenly appears with markings: Level 2 - Slime Schlime Time. Through the door was an artificial looking cave dungeon with unknown plants mixed with moss which grew through the cracks. And boom filled with Slime blobs, not the good type either. Do you wish to run or fight?");
            Rooms Level3 = new Rooms("Nestflix & Chill", "Congrats on surviving though Level 2! But will you be able to survive through this? A door not so suprisingly appears with markings: Level 3 - Nestflix & Chill. You open the door and see a fancy dungeon room with pillars and suprisingly a few twigs fall down. You look up and you find nests, some with a few eggs and some with GRIFFINS?!? They look at you glaringly and with bloodlust. Do you wish to run or fight?");
            Rooms Level4 = new Rooms("Oops, You’re Drowning", "Wow you actually survived though Level 3? ...Well, try this! This time a fancy roman door appears(Very shinny): Level 4 - Pool of “Oops, You’re Drowning. You open the door and see a huge pillared roman pool with entrance being the only thing as a boarder. As you walk through the door, it slams LOUDLY. You see a deep blue shadowy figure in the water, you squint in hopes of seeing more and the huge figure splashes out the water violently. Congrats you have encounter a huge sea serpent with a glare of death(think you woke it up with the door). Do you wish to run or fight?");
            Rooms Level5 = new Rooms("The Dino-Den of Doom", "Oh Wow... I did not see that coming, heh since you passed Level 4 let me introduce you to Level 5! From a fancy door to a basic wooden door(don't judge a book by it cover...we had to rush this) on the now basic door is a sign that says: Level 5 - The Dino-Den of Doom. You open the door and see a huge dungeon room almost masking itself as a forest with huge rocks bigger than you(yes i'm calling you short hehehe >D ). In the center is a huge nest with dundunduunnn a Basilisk(bet you didn't guess that). Do you wish to run or fight?");
            Rooms Level6 = new Rooms("Rock ‘n’ Roar Hideout", "Dawm Level 5... hmm ok ... HOW ABOUT THIS!?! A door made out a unfinished paper mache(That...was um... supposed to be done...). Beside the door is a paper sign that says: Level 6 - Rock ‘n’ Roar Hideout. You open the door as residue of undried glue and paper sticks on your palm. You see huge dungeon room almost masking itself as a cave with huge rocks bigger than you(yes I just copied and pasted whatcha gon do about it?). As you walk deeper you feel the atmosphere getting hotter and next thing you know right in front of you is a legandary Wyvern(hireing him was the second most expensive thing). Do you wish to run or fight?");
            Rooms Level7 = new Rooms("The unknown", "I honestly have no words... But you definitely are NOT getting past this (And yes, I’m totally petty about it). Suddenly, a golden door materializes (the third most expensive thing in the dungeon) With letters encapsulated in diamond saying: Level 7 - The unknown. You open it to find a room overflowing with the most luxurious treasures you’ve ever heard of... or seen. At the center, a grand staircase of pure gold, draped in rich red carpet, leads up to a throne. And sitting on that throne is... what is THAT?! A... DITTO?!?! (Took almost all our budget) DUN DUN DUUUUNNNN! *dramatic sound effect* Do you dare to fight or run away screaming?");

            Monster WalkingMushroom = new Monster("Mushroom", 5, 2, 1 );
            Monster SlimeBlob = new Monster("Slime Blob", 10, 8, 2);
            Monster Griffin = new Monster("Griffin", 25, 20, 10);
            Monster SeaSerpent = new Monster("Sea Serpent", 40, 35, 15);
            Monster Basilisk = new Monster("Basilisk", 65, 50, 24);
            Monster Wyvern = new Monster("Wyvern", 80, 90, 35);
            Monster Ditto = new Monster("Ditto", 1000, 500, 0);

            int currentRoom = 0;
            bool playing = true;

            
            
        }

    }
}
}
