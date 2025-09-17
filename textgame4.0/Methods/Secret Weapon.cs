using Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    public class SecretWeapons
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public bool IsRanged { get; set; }
        public int UsesLeft { get; set; }

        public SecretWeapons(string Name, int Damage, bool IsRanged, int usesLeft)
        {
            this.Name = Name;
            this.Damage = Damage;
            this.IsRanged = IsRanged;
            UsesLeft = usesLeft;
        }
        // Checks if the weapon still has uses left
        public bool IsUsable()
        {
            return UsesLeft > 0;
        }
        // Uses the weapon once, reducing available uses
        public void Use()
        {
            if (UsesLeft > 0)
            {
                UsesLeft--;
            }
            else
            {
                Console.WriteLine($"The secret weapon {Name} has no uses left and cannot be used.");
            }
        }
    }
    public class secretitems
    {
        private static int wrongAttempts = 0; // Tracks failed code attempts
        public static void DisplaySecretItems()
        {
            Console.WriteLine("Welcome to the Secret Items Shop! Please enter the code: ");
            string code = Console.ReadLine().ToLower();
            if (code == "magi")
            {
                Console.WriteLine("You have entered Magical girl wand damage: 1000, do you wish to add into your inventory? (y or n):");
                if (Console.ReadLine().ToLower() == "y")
                {
                    if (!Player.Items.Contains("Magical girl wand"))
                    {
                        Player.Items.Add("Magical girl wand");
                        Console.WriteLine("Magical girl wand has been added to your inventory(CLOCK ITTTT)!");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("You already have Magicial girl wand in your inventory(ok girlie stop being greedy).");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Maybe next time(huh?)!");
                    Console.ReadLine();
                }
                wrongAttempts = 0; // reset on success
            }
            else if (code == "av4")
            {
                Console.WriteLine("You have entered Avatar powers damage: 880, do you wish to add into your inventory? (y or n):");
                if (Console.ReadLine().ToLower() == "y")
                {
                    if (!Player.Items.Contains("Avatar Powers"))
                    {
                        Player.Items.Add("Avatar Powers");
                        Console.WriteLine("Avatar Powers has been added to your inventory(CLOCK ITTTT)!");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("You already have Avatar Powers in your inventory(ok girlie stop being greedy).");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Maybe next time(huh?)!");
                    Console.ReadLine();
                }
                wrongAttempts = 0; // reset on success
            }
            else if (code == "l0st")
            {
                Console.WriteLine("You have entered Lostvayne (seven deadly sins) damage: 500, do you wish to add into your inventory? (y or n):");
                if (Console.ReadLine().ToLower() == "y")
                {
                    if (!Player.Items.Contains("Lostvayne"))
                    {
                        Player.Items.Add("Lostvayne");
                        Console.WriteLine("Lostvayne has been added to your inventory(CLOCK ITTTT)!");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("You already have Lostvayne in your inventory(ok girlie stop being greedy).");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Maybe next time(huh?)!");
                    Console.ReadLine();
                }
                wrongAttempts = 0; // reset on success
            }
            // Wrong code entered
            else
            {
                wrongAttempts++;
                // Punishment increases with each failed attempt
                int penalty = wrongAttempts == 1 ? 1 : (wrongAttempts - 1) * 5;
                Console.WriteLine($"Invalid code. Punishment: -{penalty} coins(LMAO YOU THOUGHTTT).");
                Player.Coins -= penalty;
                Console.WriteLine($"You now have {Player.Coins} coins(BROKEEEE).");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }
    }
}
