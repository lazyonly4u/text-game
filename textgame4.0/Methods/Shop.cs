using Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Methods
{
    public class Shop
    {
        public static void DisplayShop(List<Weapons> shopWeapons, List<Healing> shopHealing)
        {
            Console.WriteLine("Welcome to the shop bruv!");
            Console.WriteLine("Would you like to buy Weapons or Healing?");
            string shopChoice = Console.ReadLine().ToLower();
            if (shopChoice == "healing")
            {
                DisplayHealingShop(shopHealing);
            }
            else
            {
                for (int i = 0; i < shopWeapons.Count; i++)
                {
                    var w = shopWeapons[i];
                    Console.WriteLine($"{i + 1}. {w.Name} - {w.Cost} coins - Damage {w.Damage} - {w.UsesLeft} UsesLeft");
                }
                Console.WriteLine($"{shopWeapons.Count + 1}. Exit Shop");
                Console.WriteLine("\nEnter the number of the weapon you want to buy, or exit:");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int choice))
                {
                    if (choice >= 1 && choice <= shopWeapons.Count)
                    {
                        var selected = shopWeapons[choice - 1];
                        if (Player.Coins >= selected.Cost)
                        {
                            Player.Coins -= selected.Cost;
                            if (!Player.Items.Contains(selected.Name))
                            {
                                Player.Items.Add(selected.Name);
                            }
                            Console.WriteLine($"You bought {selected.Name}! It has been added to your inventory. Use the inventory to equip it.");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Womp! Womp! You don't have enough coins!");
                            Console.ReadLine();
                        }
                    }
                    else if (choice == shopWeapons.Count + 1)
                    {
                        Console.WriteLine("Exiting shop.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice(bro just cant).");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input(bro just cant spell).");
                }
            }
        }
        public static void DisplayHealingShop(List<Healing> shopHealing)
        {
            Console.WriteLine("Healing Items for sale:");
            for (int i = 0; i < shopHealing.Count; i++)
            {
                var h = shopHealing[i];
                Console.WriteLine($"{i + 1}. {h.Name} - {h.Cost} coins - Heals {h.Heal} health");
            }
            Console.WriteLine($"{shopHealing.Count + 1}. Exit Shop");
            Console.WriteLine("\nEnter the number of the healing item you want to buy, or exit:");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int choice))
            {
                if (choice >= 1 && choice <= shopHealing.Count)
                {
                    var selected = shopHealing[choice - 1];
                    if (Player.Coins >= selected.Cost)
                    {
                        Player.Coins -= selected.Cost;
                        Player.Items.Add(selected.Name);
                        Console.WriteLine($"You bought {selected.Name}! It has been added to your inventory. Use the inventory to consume it.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Womp! Womp! You don't have enough coins!");
                        Console.ReadLine();
                    }
                }
                else if (choice == shopHealing.Count + 1)
                {
                    Console.WriteLine("Exiting shop.");
                }
                else
                {
                    Console.WriteLine("Invalid choice(bro just cant).");
                }
            }
            else
            {
                Console.WriteLine("Invalid input(bro just cant spell).");
            }
        }
    }
}
