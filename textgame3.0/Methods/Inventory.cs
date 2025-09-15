using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Methods;

namespace Methods
{
    public class Inventory
    {
        public static void DisplayInventory()
        {
            Console.WriteLine("Your Inventory: ");
            Console.WriteLine($"Health: {Player.Health}");
            Console.WriteLine($"Coins: {Player.Coins}");
            Console.WriteLine($"Weapon: {Player.Weapon}");
            if (Player.Items.Count > 0)
            {
                Console.WriteLine("Items:");
                for (int i = 0; i < Player.Items.Count; i++)
                {
                    string itemName = Player.Items[i];
                    // Try to find weapon info
                    var weapon = WeaponLibrary.AllWeapons.FirstOrDefault(w => w.Name == itemName);
                    if (weapon != null)
                    {
                        Console.WriteLine($"{i + 1}. {itemName} (Weapon) - Damage: {weapon.Damage} - UsesLeft: {weapon.UsesLeft}");
                        continue;
                    }

                    // Try to find healing info
                    var healItem = GetHealingItemByName(itemName);
                    if (healItem != null)
                    {
                        Console.WriteLine($"{i + 1}. {itemName} (Healing) - Heals: {healItem.Heal}");
                        continue;
                    }
                    var secretWeapon = GetSecretWeaponByName(itemName);
                    if (secretWeapon != null)
                    {
                        Console.WriteLine($"{i + 1}. {itemName} (Secret Weapon) - Damage: {secretWeapon.Damage}");
                        continue;
                    }
                    // Otherwise, just print the item name
                    Console.WriteLine($"{i + 1}. {itemName}");
                }
                Console.WriteLine("Type 'use <item number>' to use a healing item or 'equip <item number>' to equip a weapon(or 'activate <item number>' to activate secret weapons) (PERIODDDD.).");
                string input = Console.ReadLine();
                if (input.StartsWith("use "))
                {
                    if (int.TryParse(input.Substring(4), out int itemNum) && itemNum >= 1 && itemNum <= Player.Items.Count)
                    {
                        string itemName = Player.Items[itemNum - 1];
                        Healing healItem = GetHealingItemByName(itemName);
                        if (healItem != null)
                        {
                            Player.Health += healItem.Heal;
                            Console.WriteLine($"You used {healItem.Name} and restored {healItem.Heal} health (SELFCAREEE)! Current health: {Player.Health}");
                            Player.Items.RemoveAt(itemNum - 1);
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("That item cannot be used for healing(OOP bro. wyd?).");
                            Console.ReadLine();
                        }
                    }
                }
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
                            Console.WriteLine("That item cannot be equipped as a weapon(OOP bro. you is not ok...).");
                            Console.ReadLine();
                        }
                    }
                }
                else if (input.StartsWith("activate"))
                {
                    if (int.TryParse(input.Substring(9), out int itemNum) && itemNum >= 0 && itemNum <= Player.Items.Count)
                    {
                        string itemName = Player.Items[itemNum - 1];
                        var secretWeapon = GetSecretWeaponByName(itemName);
                        if (secretWeapon != null)
                        {
                            Player.Weapon = itemName;
                            Console.WriteLine($"You activated {itemName}(OP POWERSS)!");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("That item cannot be activated as a secret weapon(umm.. ew).");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid item number(...).");
                        Console.ReadLine();
                    }
                }
            }
            else
            {
                Console.WriteLine("No other items in inventory(cough broke cough). ");
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

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
        private static Healing GetHealingItemByName(string itemName)
        {
            if (itemName == "Health Potion") return new Healing("Health Potion", 0, 10);
            if (itemName == "Weed") return new Healing("Weed", 0, 5);
            return null;
        }
    }
}
