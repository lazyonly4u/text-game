

using Methods;
using System;
using System.Numerics;
using System.Threading;
namespace textgame
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
                new Room("The Beginning", "You find yourself in a dimly lit dungeon with stone walls and a single wooden door. Beside the door is a sign that says: Level 0 - The beginning. As you scan the walls, you faintly notice some graffiti: 'MAGI was here' scrawled in glittery ink. Strange... almost magical. You brush it off and proceed."),

                new Room("Fungus Among Us", "Beside the door is a sign that says: Level 1 - Fungus Among Us. You open the door and see a dungeon room almost masking itself as a forest. Surprisingly, it's filled with a huge waking mushroom. Do you wish to fight, or hide away like a coward? Something glints beneath a mushroom cap... the letters L0ST etched faintly on a blade half-buried in the moss. It hums with cursed energy."),

                new Room("Slime Schlime Time", "A door suddenly appears with markings: Level 2 - Slime Schlime Time. Through the door is an artificial-looking cave dungeon. Boom—a Slime blob appears (and not the good type either). Do you wish to run or fight? Oddly enough, a faint trail of glowing slime spells out something on the wall: 'Use MAGI. Is someone trying to help you?"),

                new Room("Nestflix & Chill", "Will you be able to survive through this? A door (not-so-surprisingly) appears with markings: Level 3 - Nestflix & Chill. You open it to find a fancy dungeon room with pillars, and surprisingly, a few twigs fall down. You look up—nests. Some with eggs, some with GRIFFINS?!? They glare at you, bloodthirsty. Only the weakest griffin wishes to fight (you are not worthy enough). A twig rolls to your feet with something scratched into it: Av4. What does that mean?"),

                new Room("Oops, You’re Drowning", "Try and survive this! A fancy Roman door appears (Very shiny): Level 4 - Pool of “Oops, You’re Drowning.” You open it and see a huge pillared Roman pool, the entrance being the only border. As you walk through the door, it slams LOUDLY. You spot a deep blue, shadowy figure in the water... a SEA SERPENT. Before it attacks, you notice a mural above the pool. Three symbols: Av, a 4, and what looks like elemental runes... Could it mean 'Avatar powers'?"),

                new Room("The Dino-Den of Doom", "Let me introduce you to Level 5! From a fancy door to a basic wooden one (don't judge a book by its cover... we had to rush this). On the now-basic door is a sign: Level 5 - The Dino-Den of Doom. You open it and see a huge dungeon room almost masking itself as a forest, with rocks bigger than you (yes, I’m calling you short, hehehe >D ). In the center: a nest with... a Basilisk?! On the floor nearby, etched in claw marks: 'Only L0ST souls survive.' Creepy."),

                new Room("Rock ‘n’ Roar Hideout", "HOW ABOUT THIS!! A door made out of unfinished papier-mâché (That...was um... supposed to be done...). Beside the door is a paper sign that says: Level 6 - Rock ‘n’ Roar Hideout. You open the door as undried glue and paper sticks to your palm. You enter a cave-like dungeon with huge rocks (yes, I copied and pasted that—what you gon’ do?). You feel the heat rising. Suddenly: a legendary Wyvern! On the back wall, burned into the stone: 'MAGI’s flame shall scorch the skies.'"),

                new Room("The Unknown", "I honestly have no words... But you're NOT getting past this (And yes, I’m totally petty about it). A golden door materializes (third most expensive thing in the dungeon). Letters in diamond: Level 7 - The Unknown. Inside: luxurious treasures, and at the center, a golden staircase with red carpet, leading to a throne. And sitting on it: WHAT IS THAT?! A... DITTO?! DUN DUN DUUUNNN! *dramatic sound effect* On the throne’s base, nearly rubbed off: 'Av4 used here... once'. Do you dare to fight, or run away screaming?"),
            };
            bool[] levelsCompleted = new bool[rooms.Count]; // Default: all false

            Monster WalkingMushroom = new Monster("Mushroom", 5, 2, 1, 15);
            Monster SlimeBlob = new Monster("Slime Blob", 10, 8, 2, 15);
            Monster Griffin = new Monster("Griffin", 25, 20, 10, 15);
            Monster SeaSerpent = new Monster("Sea Serpent", 40, 35, 15, 15);
            Monster Basilisk = new Monster("Basilisk", 65, 50, 24, 15);
            Monster Wyvern = new Monster("Wyvern", 80, 90, 35, 15);
            Monster Ditto = new Monster("Ditto", 2000, 1000, 0, 15);

            Weapons WoodenSword = new Weapons("Wooden Sword", 0, 5, false, 10);

            Weapons LongSlenderBlade = new Weapons("Espada Bastarda", 16, 15, false, 15);
            Weapons FrenchThinPencilSword = new Weapons("Rapier", 22, 20, false, 20);
            Weapons ArabCurvedThinSword = new Weapons("Arabian scimitar sword", 30, 35, false, 35);

            Weapons CurvedKnife = new Weapons("Kukri", 10, 10, false, 15);

            Weapons LongHorsebackBow = new Weapons("The Yumi Bow", 13, 15, true, 15);
            Weapons StrongBlowBow = new Weapons("Manchu Bow", 35, 35, true, 20);

            SecretWeapons Excalibur = new SecretWeapons("Magical girl wand", 1000, false, 1);
            SecretWeapons Lostvayne = new SecretWeapons("Lostvayne", 500, false, 1);
            SecretWeapons Avatarpowers = new SecretWeapons("Avatar powers", 880, false, 1);

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
            if (int.TryParse(input, out int roomNumber) && roomNumber >= 0 && roomNumber <= rooms.Count)
            {
                currentRoom = roomNumber;
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
                                        Console.WriteLine("You dropped the Wooden Sword and are now using your fists (does 2 damage points)(ewwww).");
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
                                Console.WriteLine("You have been defeated! Game Over(lmao).");
                                Console.ReadLine();
                                playing = false;
                                if (monster != null)
                                {
                                    Combat.Fight(monster);
                                    if (Player.Health <= 0)
                                    {
                                        Console.WriteLine("You have been defeated! Game Over(lmao).");
                                        Console.ReadLine();
                                        playing = false;
                                    }
                                    else
                                    {
                                        // Mark current room as completed
                                        levelsCompleted[currentRoom] = true;

                                        Console.ReadLine();
                                        if (currentRoom < rooms.Count - 1)
                                        {
                                            currentRoom++;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Congratulations! You have completed all levels(wow did not expect that...)!");
                                            Console.WriteLine("TIME FOR CREDITS!!");
                                            CREDITS.DisplayCredits();
                                            playing = false;
                                        }
                                    }
                                }
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
                                    Console.WriteLine("Congratulations! You have completed all levels(wow did not expect that...)!");
                                    Console.WriteLine("TIME FOR CREDITS!!");
                                    Console.ReadLine();
                                    Console.Clear();

                                    CREDITS.DisplayCredits();

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

                            if (newRoomNumber > 6 && !levelsCompleted[newRoomNumber - 1])
                            {
                                Console.WriteLine("You must complete the previous level first!");
                                Console.ReadLine();
                                currentRoom = newRoomNumber - 1;
                            }
                        }
                        else if (lvlInput == "8")
                        {
                            Exit.ExitGame();
                            playing = false;
                        }
                        else
                        {
                            Console.WriteLine("Invalid level number. Staying in the current level(bro is laggin).");
                            Console.ReadLine();
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
                        Console.WriteLine("Invalid choice, please try again(bro choose/spell it right).");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
