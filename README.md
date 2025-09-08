

using Methods;
using System;
namespace calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            intro.DisplayIntro();

            Console.WriteLine("You see a door appear out of nowhere with a wooden sword in front of the door (congrats on your first weapon!) ");
            Console.WriteLine("Starter free wooden sword || Cost: free || damage: 5");
            Console.WriteLine("Do you want to equip it? (yes/no)");
            Console.WriteLine("If no, it will be added to your inventory");
            Console.Write("Your choice: ");
            string equipChoice = Console.ReadLine();
            if (equipChoice.ToLower() == "yes")
            {
                Player.Weapon = "Wooden Sword";
                Console.WriteLine("You equipped the Wooden Sword!");
            }
            else if (equipChoice.ToLower() == "no")
            {
                Player.Items.Add("Wooden Sword");
                Console.WriteLine("The Wooden Sword has been added to your inventory.");
            }
            else
            {
                Console.WriteLine("Invalid choice, you lose your chance to pick up the weapon.");
            }

            List<Room> rooms = new List<Room>
            {
            new Room("The Beginning", "You find yourself in a dimly lit dungeon with stone walls and a single wooden door. Beside the door is a sign that says: Level 0 - The beginning"),
            new Room("Fungus Among Us", "Beside the door is a sign that says: Level 1 - Fungus Among Us. You open the door and see a dungeon room almost masks itself as a forest. And suprisingly its filled a huge waking mushroom. Do you wish to fight? or hide away like a coward"),
            new Room("Slime Schlime Time", "A door Suddenly appears with markings: Level 2 - Slime Schlime Time. Through the door was an artificial looking cave dungeon. And boom a Slime blob appears and not the good type either. Do you wish to run or fight?"),
            new Room("Nestflix & Chill", "Will you be able to survive through this? A door not so suprisingly appears with markings: Level 3 - Nestflix & Chill. You open the door and see a fancy dungeon room with pillars and suprisingly a few twigs fall down. You look up and you find nests, some with a few eggs and some with GRIFFINS?!? They look at you glaringly and with bloodlust. But only the weakest giffin wishes to fight you (you are not worthy enough). Do you wish to run or fight?"),
            new Room("Oops, You’re Drowning", "Try and survive this! This time a fancy roman door appears(Very shinny): Level 4 - Pool of “Oops, You’re Drowning. You open the door and see a huge pillared roman pool with entrance being the only thing as a boarder. As you walk through the door, it slams LOUDLY. You see a deep blue shadowy figure in the water, you squint in hopes of seeing more and the huge figure splashes out the water violently. Congrats you have encounter a huge sea serpent with a glare of death(think you woke it up with the door). Do you wish to run or fight?"),
            new Room("The Dino-Den of Doom", "Let me introduce you to Level 5! From a fancy door to a basic wooden door(don't judge a book by it cover...we had to rush this) on the now basic door is a sign that says: Level 5 - The Dino-Den of Doom. You open the door and see a huge dungeon room almost masking itself as a forest with huge rocks bigger than you(yes i'm calling you short hehehe >D ). In the center is a huge nest with dundunduunnn a Basilisk(bet you didn't guess that). Do you wish to run or fight?"),
            new Room("Rock ‘n’ Roar Hideout", "HOW ABOUT THIS!! A door made out a unfinished paper mache(That...was um... supposed to be done...). Beside the door is a paper sign that says: Level 6 - Rock ‘n’ Roar Hideout. You open the door as residue of undried glue and paper sticks on your palm. You see huge dungeon room almost masking itself as a cave with huge rocks bigger than you(yes I just copied and pasted whatcha gon do about it?). As you walk deeper you feel the atmosphere getting hotter and next thing you know right in front of you is a legandary Wyvern(hireing him was the second most expensive thing). Do you wish to run or fight?"),
            new Room("The unknown", "I honestly have no words... But you definitely are NOT getting past this (And yes, I’m totally petty about it). Suddenly, a golden door materializes (the third most expensive thing in the dungeon) With letters encapsulated in diamond saying: Level 7 - The unknown. You open it to find a room overflowing with the most luxurious treasures you’ve ever heard of... or seen. At the center, a grand staircase of pure gold, draped in rich red carpet, leads up to a throne. And sitting on that throne is... what is THAT?! A... DITTO?!?! (Took almost all our budget) DUN DUN DUUUUNNNN! *dramatic sound effect* Do you dare to fight or run away screaming?"),
            };

            Monster WalkingMushroom = new Monster("Mushroom", 5, 2, 1, 15);
            Monster SlimeBlob = new Monster("Slime Blob", 10, 8, 2, 15);
            Monster Griffin = new Monster("Griffin", 25, 20, 10, 15);
            Monster SeaSerpent = new Monster("Sea Serpent", 40, 35, 15, 15);
            Monster Basilisk = new Monster("Basilisk", 65, 50, 24, 15);
            Monster Wyvern = new Monster("Wyvern", 80, 90, 35, 15);
            Monster Ditto = new Monster("Ditto", 1000, 500, 0, 15);

            Weapons WoodenSword = new Weapons("Wooden Sword", 0, 5, false, 10);

            Weapons LongSlenderBlade = new Weapons("Long Slender Blade", 16, 15, false, 15);
            Weapons FrenchThinPencilSword = new Weapons("French Thin Pencil Sword", 22, 20, false, 20);
            Weapons ArabCurvedThinSword = new Weapons("Arab Curved Thin Sword", 30, 35, false, 35);

            Weapons CurvedKnife = new Weapons("Curved Knife", 10, 10, false, 15);

            Weapons LongHorsebackBow = new Weapons("Long Horseback Bow", 13, 15, true, 15);
            Weapons StrongBlowBow = new Weapons("Strong Blow Bow", 35, 35, true, 20);

            SecretWeapons Excalibur = new SecretWeapons("Magical girl wand", 1000, 1);
            SecretWeapons Lostvayne = new SecretWeapons("Lostvayne", 500, 1);
            SecretWeapons Avatarpowers = new SecretWeapons("Avatar powers", 880, 1);

            Healing HealthPotions = new Healing("Health Potion", 15, 10);
            Healing Weed = new Healing("Weed", 5, 5);

            // Example: Start at a chosen room
            int currentRoom = 0;
            Console.WriteLine("Which Level do you want to go to? (0-7) or type '8' to quit");
            string input = Console.ReadLine();
            if (input == "8")
            {
                Console.WriteLine("Thanks for playing!");
                return;
            }
            if (int.TryParse(input, out int roomNumber) && roomNumber >= 1 && roomNumber <= rooms.Count)
            {
                currentRoom = roomNumber - 0;
            }
            else
            {
                currentRoom = 0;
            }

            // Main game loop
            bool playing = true;
            while (playing)
            {
                Room room = rooms[currentRoom];
                room.Enter();
                Console.WriteLine("What do you want to do? (Explore(Left)/Change lvl(North or South)/Shop/Inventory/Secret/Exit(Right))");
                string choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "explore":
                    case "left":
                        Monster monster = null;
                        switch (currentRoom)
                        {
                            case 0:
                                Console.WriteLine("This is a safe area. No monsters here. But would you like to drop your wooden sword? and let it be deleted from you inventory? Y/N:");
                                string dropChoice = Console.ReadLine();
                                if (dropChoice.ToLower() == "y")
                                {
                                    if (Player.Weapon == "Wooden Sword")
                                    {
                                        Player.Weapon = "Fists";
                                        Console.WriteLine("You dropped the Wooden Sword and are now using your fists (does 2 damage points).");
                                        Console.ReadLine();
                                    }
                                    else if (Player.Items.Contains("Wooden Sword"))
                                    {
                                        Player.Items.Remove("Wooden Sword");
                                        Console.WriteLine("The Wooden Sword has been removed from your inventory.");
                                        Console.ReadLine(); 
                                    }
                                    else
                                    {
                                        Console.WriteLine("You don't have a Wooden Sword to drop.");
                                        Console.ReadLine();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("You chose not to drop the Wooden Sword.");
                                    Console.ReadLine();
                                }
                                break;
                            case 1:
                                monster = WalkingMushroom;
                                break;
                            case 2:
                                monster = SlimeBlob;
                                break;
                            case 3:
                                monster = Griffin;
                                break;
                            case 4:
                                monster = SeaSerpent;
                                break;
                            case 5:
                                monster = Basilisk;
                                break;
                            case 6:
                                monster = Wyvern;
                                break;
                            case 7:
                                monster = Ditto;
                                break;
                        }
                        if (monster != null)
                        {
                            Combat.Fight(monster);
                            if (Player.Health <= 0)
                            {
                                Console.WriteLine("You have been defeated! Game Over.");
                                Console.ReadLine();
                                playing = false;
                            }
                            else
                            {
                                Console.ReadLine();
                                if (currentRoom < rooms.Count - 1)
                                {
                                    currentRoom++;
                                }
                                else
                                {
                                    Console.WriteLine("Congratulations! You have completed all levels!");
                                    Console.ReadLine();
                                    playing = false;
                                }
                            }
                        }
                        break;
                    case "change lvl":
                    case "north":
                    case "south":
                        Console.WriteLine("Which Level do you want to go to? (0-7) or type '8' to quit");
                        string lvlInput = Console.ReadLine();
                        if (int.TryParse(lvlInput, out int newRoomNumber) && newRoomNumber >= 0 && newRoomNumber < rooms.Count)
                        {
                            currentRoom = newRoomNumber;
                        }
                        else if (lvlInput == "8")
                        {
                            Exit.ExitGame();
                            playing = false;
                        }
                        else
                        {
                            Console.WriteLine("Invalid level number. Staying in the current level.");
                        }
                        break;
                    case "shop":
                        List<Weapons> shopWeapons = new List<Weapons>
                        {
                            WoodenSword, LongSlenderBlade, FrenchThinPencilSword, ArabCurvedThinSword,
                            CurvedKnife, LongHorsebackBow, StrongBlowBow
                        };
                        List<Healing> shopHealing = new List<Healing>
                        {
                            HealthPotions, Weed
                        };
                        Shop.DisplayShop(shopWeapons, shopHealing);
                        break;
                    case "inventory":
                        Inventory.DisplayInventory();
                        break;
                    case "secret":
                        secretitems.DisplaySecretItems();
                        break;
                    case "exit":
                    case "right":
                        Exit.ExitGame();
                        playing = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    } 
}
