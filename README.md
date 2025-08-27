
using Methods;
using System;
namespace calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();

            Console.WriteLine(" .oooooo..o oooo   o8o                                                 .oooooo..o     .              .o8                           .oo.           .oooooo..o     .                .o88o.  .o88o. \r\nd8P'    `Y8 `888   `\"'                                                d8P'    `Y8   .o8             \"888                         .88' `8.        d8P'    `Y8   .o8                888 `\"  888 `\" \r\nY88bo.       888  oooo  ooo. .oo.  .oo.    .ooooo.   .oooo.o          Y88bo.      .o888oo  .oooo.    888oooo.   .oooo.o          88.  .8'        Y88bo.      .o888oo oooo  oooo  o888oo  o888oo  \r\n `\"Y8888o.   888  `888  `888P\"Y88bP\"Y88b  d88' `88b d88(  \"8           `\"Y8888o.    888   `P  )88b   d88' `88b d88(  \"8          `88.8P           `\"Y8888o.    888   `888  `888   888     888    \r\n     `\"Y88b  888   888   888   888   888  888ooo888 `\"Y88b.                `\"Y88b   888    .oP\"888   888   888 `\"Y88b.            d888[.8'            `\"Y88b   888    888   888   888     888    \r\noo     .d8P  888   888   888   888   888  888    .o o.  )88b .o.      oo     .d8P   888 . d8(  888   888   888 o.  )88b .o.      88' `88.        oo     .d8P   888 .  888   888   888     888    \r\n8\"\"88888P'  o888o o888o o888o o888o o888o `Y8bod8P' 8\"\"888P' Y8P      8\"\"88888P'    \"888\" `Y888\"\"8o  `Y8bod8P' 8\"\"888P' Y8P      `bodP'`88.      8\"\"88888P'    \"888\"  `V88V\"V8P' o888o   o888o   \r\n                                                              '                                                          '                                                                       \r\n                                                                                                                                                                                                 \r\n                                                                                                                                                                                                 ");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Congracts truck-kun ran you over and now you have regressed to the game world of Slimes, Stabs, & Stuff. Your mission win and try not to die");
            Console.ReadLine();
            Console.WriteLine("which you will");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();


            Console.WriteLine("You look up and see a door with a sign saying : Hello sacrafice #584");
            System.Threading.Thread.Sleep(3000);
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


            List<Room> rooms = new List<Room>
            {
            new Room("Fungus Among Us", "Beside the door is a sign that says: Level 1 - Fungus Among Us. You open the door and see a dungeon room almost masks itself as a forest. And suprisingly its filled with waking mushrooms. Do you wish to fight? or hide away like a coward"),
            new Room("Slime Schlime Time", "A door Suddenly appears with markings: Level 2 - Slime Schlime Time. Through the door was an artificial looking cave dungeon with unknown plants mixed with moss which grew through the cracks. And boom filled with Slime blobs, not the good type either. Do you wish to run or fight?"),
            new Room("Nestflix & Chill", "Will you be able to survive through this? A door not so suprisingly appears with markings: Level 3 - Nestflix & Chill. You open the door and see a fancy dungeon room with pillars and suprisingly a few twigs fall down. You look up and you find nests, some with a few eggs and some with GRIFFINS?!? They look at you glaringly and with bloodlust. Do you wish to run or fight?"),
            new Room("Oops, You’re Drowning", "Try and survive this! This time a fancy roman door appears(Very shinny): Level 4 - Pool of “Oops, You’re Drowning. You open the door and see a huge pillared roman pool with entrance being the only thing as a boarder. As you walk through the door, it slams LOUDLY. You see a deep blue shadowy figure in the water, you squint in hopes of seeing more and the huge figure splashes out the water violently. Congrats you have encounter a huge sea serpent with a glare of death(think you woke it up with the door). Do you wish to run or fight?"),
            new Room("The Dino-Den of Doom", "Let me introduce you to Level 5! From a fancy door to a basic wooden door(don't judge a book by it cover...we had to rush this) on the now basic door is a sign that says: Level 5 - The Dino-Den of Doom. You open the door and see a huge dungeon room almost masking itself as a forest with huge rocks bigger than you(yes i'm calling you short hehehe >D ). In the center is a huge nest with dundunduunnn a Basilisk(bet you didn't guess that). Do you wish to run or fight?"),
            new Room("Rock ‘n’ Roar Hideout", "HOW ABOUT THIS!! A door made out a unfinished paper mache(That...was um... supposed to be done...). Beside the door is a paper sign that says: Level 6 - Rock ‘n’ Roar Hideout. You open the door as residue of undried glue and paper sticks on your palm. You see huge dungeon room almost masking itself as a cave with huge rocks bigger than you(yes I just copied and pasted whatcha gon do about it?). As you walk deeper you feel the atmosphere getting hotter and next thing you know right in front of you is a legandary Wyvern(hireing him was the second most expensive thing). Do you wish to run or fight?"),
            new Room("The unknown", "I honestly have no words... But you definitely are NOT getting past this (And yes, I’m totally petty about it). Suddenly, a golden door materializes (the third most expensive thing in the dungeon) With letters encapsulated in diamond saying: Level 7 - The unknown. You open it to find a room overflowing with the most luxurious treasures you’ve ever heard of... or seen. At the center, a grand staircase of pure gold, draped in rich red carpet, leads up to a throne. And sitting on that throne is... what is THAT?! A... DITTO?!?! (Took almost all our budget) DUN DUN DUUUUNNNN! *dramatic sound effect* Do you dare to fight or run away screaming?"),

            };

            
            Monster WalkingMushroom = new Monster("Mushroom", 5, 2, 1, 10);
            Monster SlimeBlob = new Monster("Slime Blob", 10, 8, 2, 8);
            Monster Griffin = new Monster("Griffin", 25, 20, 10, 5);
            Monster SeaSerpent = new Monster("Sea Serpent", 40, 35, 15, 2);
            Monster Basilisk = new Monster("Basilisk", 65, 50, 24, 1);
            Monster Wyvern = new Monster("Wyvern", 80, 90, 35, 1);
            Monster Ditto = new Monster("Ditto", 1000, 500, 0, 1);

            weapons WoodenSword = new weapons("Wooden Sword", 0, 5);

            weapons LongSlenderBlade = new weapons("Long Slender Blade", 16, 15);
            weapons FrenchThinPencilSword = new weapons("French Thin Pencil Sword", 22, 20);
            weapons ArabCurvedThinSword = new weapons("Arab Curved Thin Sword", 30, 35);

            weapons CurvedKnife = new weapons("Curved Knife", 10, 10);

            weapons LongHorsebackBow = new weapons("Long Horseback Bow", 13, 15);
            weapons StrongBlowBow = new weapons("Strong Blow Bow", 35, 35);

             


            // Example: Start at a chosen room
            int currentRoom = 0;
            Console.WriteLine("Which Level do you want to go to? (1-7) or type '8' to quit");
            string input = Console.ReadLine();
            if (input == "8")
            {
                Console.WriteLine("Thanks for playing!");
                return;
            }
            if (int.TryParse(input, out int roomNumber) && roomNumber >= 1 && roomNumber <= rooms.Count)
            {
                currentRoom = roomNumber - 1;
            }
            else
            {
                Console.WriteLine("Invalid choice, starting at Level 1");
                currentRoom = 0;
            }

            // Main game loop
            bool playing = true;
            while (playing)
            {
                Room room = rooms[currentRoom];
                room.Enter();
                Console.WriteLine("What do you want to do? (fight/run/shop/inventory/exit)");
                string choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "fight":
                        Monster monster = null;
                        switch (currentRoom)
                        {
                            case 0:
                                monster = WalkingMushroom;
                                break;
                            case 1:
                                monster = SlimeBlob;
                                break;
                            case 2:
                                monster = Griffin;
                                break;
                            case 3:
                                monster = SeaSerpent;
                                break;
                            case 4:
                                monster = Basilisk;
                                break;
                            case 5:
                                monster = Wyvern;
                                break;
                            case 6:
                                monster = Ditto;
                                break;
                        }
                        if (monster != null)
                        {
                            Combat.Fight(monster);
                            if (Player.Health <= 0)
                            {
                                Console.WriteLine("You have been defeated! Game Over.");
                                playing = false;
                            }
                            else
                            {
                                Console.WriteLine($"You defeated the {monster.Name}!");
                                if (currentRoom < rooms.Count - 1)
                                {
                                    currentRoom++;
                                }
                                else
                                {
                                    Console.WriteLine("Congratulations! You have completed all levels!");
                                    playing = false;
                                }
                            }
                        }
                        break;
                    case "run":
                        Console.WriteLine("You ran away safely.");
                        // Possible penalty for running can be added here
                        break;
                    case "shop":
                        List<weapons> shopWeapons = new List<weapons>
                        {
                            
                            WoodenSword, LongSlenderBlade, FrenchThinPencilSword, ArabCurvedThinSword,
                            CurvedKnife, LongHorsebackBow, StrongBlowBow
                        };
                        Shop.DisplayShop(shopWeapons);
                        break;
                    case "inventory":

                        Inventory.DisplayInventory();
                        break;
                    case "exit":
                        Exit.ExitGame();

                        playing = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }

        }
    }
}
