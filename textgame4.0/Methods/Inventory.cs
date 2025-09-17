using Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    public class Inventory
    {
        // Displays player's current inventory and allows interaction
        public static void DisplayInventory()
        {
            Console.WriteLine("Your Inventory: ");
            Console.WriteLine($"Health: {Player.Health}");
            Console.WriteLine($"Coins: {Player.Coins}");
            Console.WriteLine($"Weapon: {Player.Weapon}");

            // Check if player has items
            if (Player.Items.Count > 0)
            {
                Console.WriteLine("Items:");

                // Loop through all items in inventory
                for (int i = 0; i < Player.Items.Count; i++)
                {
                    string itemName = Player.Items[i];

                    // Check if the item is a weapon
                    var weapon = WeaponLibrary.AllWeapons.FirstOrDefault(w => w.Name == itemName);
                    if (weapon != null)
                    {
                        Console.WriteLine($"{i + 1}. {itemName} (Weapon) - Damage: {weapon.Damage} - UsesLeft: {weapon.UsesLeft}");
                        continue;
                    }

                    // Check if the item is a healing item
                    var healItem = GetHealingItemByName(itemName);
                    if (healItem != null)
                    {
                        Console.WriteLine($"{i + 1}. {itemName} (Healing) - Heals: {healItem.Heal}");
                        continue;
                    }

                    // Check if the item is a secret weapon
                    var secretWeapon = GetSecretWeaponByName(itemName);
                    if (secretWeapon != null)
                    {
                        Console.WriteLine($"{i + 1}. {itemName} (Secret Weapon) - Damage: {secretWeapon.Damage}");
                        continue;
                    }

                    // If not identified, just print name
                    Console.WriteLine($"{i + 1}. {itemName}");
                }

                // Prompt player for input
                Console.WriteLine("Type 'use <item number>' to use a healing item or 'equip <item number>' to equip a weapon (or 'activate <item number>' to activate secret weapons).");
                string input = Console.ReadLine();

                // Using a healing item
                if (input.StartsWith("use "))
                {
                    if (int.TryParse(input.Substring(4), out int itemNum) && itemNum >= 1 && itemNum <= Player.Items.Count)
                    {
                        string itemName = Player.Items[itemNum - 1];
                        Healing healItem = GetHealingItemByName(itemName);

                        if (healItem != null)
                        {
                            Player.Health += healItem.Heal;
                            Console.WriteLine($"You used {healItem.Name} and restored {healItem.Heal} health! Current health: {Player.Health}");
                            Player.Items.RemoveAt(itemNum - 1); // Remove after use
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("That item cannot be used for healing.");
                            Console.ReadLine();
                        }
                    }
                }

                // Equipping a weapon
                else if (input.StartsWith("equip "))
                {
                    if (int.TryParse(input.Substring(6), out int itemNum) && itemNum >= 1 && itemNum <= Player.Items.Count)
                    {
                        string itemName = Player.Items[itemNum - 1];
                        var weapon = WeaponLibrary.AllWeapons.FirstOrDefault(w => w.Name == itemName);

                        if (weapon != null)
                        {
                            Player.Weapon = itemName;
                            Console.WriteLine($"You equipped {itemName}!");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("That item cannot be equipped as a weapon.");
                            Console.ReadLine();
                        }
                    }
                }
                
                // Activating a secret weapon
                else if (input.StartsWith("activate"))
                {
                    if (int.TryParse(input.Substring(9), out int itemNum) && itemNum >= 0 && itemNum <= Player.Items.Count)
                    {
                        string itemName = Player.Items[itemNum - 1];
                        var secretWeapon = GetSecretWeaponByName(itemName);

                        if (secretWeapon != null)
                        {
                            Player.Weapon = itemName;
                            Console.WriteLine($"You activated {itemName}!");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("That item cannot be activated as a secret weapon.");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid item number.");
                        Console.ReadLine();
                    }
                }
            }
            else
            {
                Console.WriteLine("No other items in inventory.");
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        // Returns a secret weapon object by name
        public static SecretWeapons? GetSecretWeaponByName(string itemName)
        {
            if (string.IsNullOrEmpty(itemName)) return null;

            switch (itemName.ToLower())
            {
                case "magical girl wand": return new SecretWeapons("Magical girl wand", 1000, false, 1);
                case "avatar powers": return new SecretWeapons("Avatar Powers", 880, false, 1);
                case "lostvayne": return new SecretWeapons("Lostvayne", 500, false, 1);
                default: return null;
            }
        }

        // Checks if an item is a weapon (basic check, not used heavily since you already query WeaponLibrary)
        private static bool IsWeapon(string itemName)
        {
            return itemName == "Wooden Sword" ||
                   itemName == "Long Slender Blade" ||
                   itemName == "French Thin Pencil Sword" ||
                   itemName == "Arab Curved Thin Sword" ||
                   itemName == "Curved Knife" ||
                   itemName == "Long Horseback  Bow" ||
                   itemName == "Strong Blow Bow";
        }

        // Returns a healing item object by name
        private static Healing GetHealingItemByName(string itemName)
        {
            if (itemName == "Health Potion") return new Healing("Health Potion", 0, 10);
            if (itemName == "Weed") return new Healing("Weed", 0, 5);
            return null;
        }
    }
}
