using Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    public class Combat
    {
        public static void Fight(Monster monster)
        {
            Console.WriteLine($"A wild {monster.Name} appears!");
            int monsterHealth = monster.Health;
            Weapons weapon = WeaponLibrary.AllWeapons.FirstOrDefault(w => w.Name == Player.Weapon);


            while (monsterHealth > 0 && Player.Health > 0)
            {
                // Refresh weapon info every turn
                weapon = WeaponLibrary.AllWeapons.FirstOrDefault(w => w.Name == Player.Weapon);
                string weaponUses;

                if (weapon != null)
                {
                    weaponUses = weapon.UsesLeft.ToString();
                }
                else
                {
                    var secretWeapon = Inventory.GetSecretWeaponByName(Player.Weapon);
                    if (secretWeapon != null)
                    {
                        weaponUses = "1"; // single-use secret weapon
                    }
                    else
                    {
                        weaponUses = "Infinite "; // fists or no weapon
                    }
                }

                Console.WriteLine($"\nYour Health: {Player.Health} | Weapon: {Player.Weapon ?? "fists"} | Weapon Damage: {GetPlayerAttack()} | Weapon Uses: {weaponUses} || {monster.Name} Health: {monsterHealth} | Monster Damage: {monster.Damage}| Drop: {monster.Coins} | Distance: {monster.SpawnPoint}");
                Console.WriteLine("Choose your action: (attack/K.O/change weapon/run)");
                string action = Console.ReadLine().ToLower();


                if (action == "attack")
                {
                    if (weapon != null && weapon.IsRanged)
                    {
                        Console.WriteLine("You attack from a distance without the monster hitting you back this turn(SMARTTTT).");
                        if (weapon.IsUsable())
                        {
                            monsterHealth -= weapon.Damage;
                            weapon.Use();
                            Console.WriteLine($"You hit the {monster.Name} for {weapon.Damage} damage.");
                        }
                        else
                        {
                            Console.WriteLine($"Your {weapon.Name} has no uses left and breaks(OH...)!");
                            Player.Items.Remove(weapon.Name);
                            Player.Weapon = null;
                        }
                        if (monster.SpawnPoint == 0)
                        {
                            Console.WriteLine("The monster teleports close(lol)!");
                            int damageToDeal = 2; // default unarmed damage

                            if (weapon != null && weapon.IsUsable())
                            {
                                damageToDeal = weapon.Damage;
                                weapon.Use();
                                Console.WriteLine($"You hit the {monster.Name} for {damageToDeal} damage.");
                                if (!weapon.IsUsable())
                                {
                                    Console.WriteLine($"Your {weapon.Name} broke(OH...)!");
                                    Player.Items.Remove(weapon.Name);
                                    Player.Weapon = null;
                                }
                            }
                            else if (weapon == null)
                            {
                                Console.WriteLine($"You attack with your fists and deal {damageToDeal} damage(ew)!");
                            }

                            monsterHealth -= damageToDeal;

                            // Monster teleports right next to you (distance = 0)
                            monster.SpawnPoint = 0;

                            if (monsterHealth <= 0)
                            {
                                Console.WriteLine($"You defeated the {monster.Name}(FINALLYYYY)!");
                                Player.Coins += monster.Coins;
                                break;
                            }
                            Player.Health -= monster.Damage; // Monster attacks back
                            Console.WriteLine($"The {monster.Name} attacks you and deals {monster.Damage} damage(SHIIIII)!");
                        }
                        else if (weapon.IsRanged)
                        {
                            monster.SpawnPoint = Math.Max(0, monster.SpawnPoint - 1);// Decrease distance to monster slowly for ranged weapons
                        }

                        if (monsterHealth <= 0)
                        {
                            Console.WriteLine($"You defeated the {monster.Name}!");
                            Player.Coins += monster.Coins;
                            break;
                        }
                    }
                    else // non-ranged or unarmed
                    {
                        Console.WriteLine("The monster teleports close(lol)!");
                        int damageToDeal = 2; // default unarmed damage

                        if (weapon != null && weapon.IsUsable())
                        {
                            damageToDeal = weapon.Damage;
                            weapon.Use();
                            Console.WriteLine($"You hit the {monster.Name} for {damageToDeal} damage.");
                            if (!weapon.IsUsable())
                            {
                                Console.WriteLine($"Your {weapon.Name} broke(OH...)!");
                                Player.Items.Remove(weapon.Name);
                                Player.Weapon = null;
                            }
                        }
                        else if (weapon == null)
                        {
                            Console.WriteLine($"You attack with your fists and deal {damageToDeal} damage(ew)!");
                        }

                        monsterHealth -= damageToDeal;

                        // Monster teleports right next to you (distance = 0)
                        monster.SpawnPoint = 0;

                        if (monsterHealth <= 0)
                        {
                            Console.WriteLine($"You defeated the {monster.Name}(FINALLYYYY)!");
                            Player.Coins += monster.Coins;
                            break;
                        }
                        Player.Health -= monster.Damage; // Monster attacks back
                        Console.WriteLine($"The {monster.Name} attacks you and deals {monster.Damage} damage(SHIIIII)!");
                    }
                }
                else if (action == "k.o")
                {
                    SecretWeapons secretWeapon = Inventory.GetSecretWeaponByName(Player.Weapon);
                    if (secretWeapon != null)
                    {
                        monsterHealth -= secretWeapon.Damage;
                        Console.WriteLine($"You use your {secretWeapon.Name} to deal a massive {secretWeapon.Damage} damage(DAWMMMM CLOCK ITTT)!");
                        Console.WriteLine("Since this is a single use weapon it is now broken(*sad mini violin music in background*)");
                        Player.Items.Remove(secretWeapon.Name);
                        Player.Weapon = null; // Secret weapon is single-use
                        if (monsterHealth <= 0)
                        {
                            Console.WriteLine($"You defeated the {monster.Name}(GIRLIE ATEEEEE. LEFT NO CRUMBS)!");
                            Player.Coins += monster.Coins;
                            break;
                        }
                        Player.Health -= monster.Damage; // Monster attacks back
                        Console.WriteLine($"The {monster.Name} attacks you and deals {monster.Damage} damage(GIRLIE ATE...but left crumbs)!");
                    }
                    else
                    {
                        Console.WriteLine("You don't have a secret weapon equipped(oh...um ew)!");
                    }
                }
                else if (action == "change weapon")
                {
                    Inventory.DisplayInventory();
                    var newWeapon = WeaponLibrary.AllWeapons.FirstOrDefault(w => w.Name == Player.Weapon);
                    if (newWeapon != null)
                        if (newWeapon.IsRanged == true)
                        {
                            monster.SpawnPoint = +15; // Reset distance to initial spawn distance
                            Console.WriteLine("The monster moves away as you switch to a ranged weapon(*nods head proudly*).");
                        }
                }
                else if (action == "run")
                {
                    Console.WriteLine("You attempt to run away...(lol couldn't be me)");
                    run.RunAway();
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid action! The monster attacks you(HAH).");
                    Player.Health -= monster.Damage;
                }
            }

            if (Player.Health <= 0)
            {
                Console.WriteLine("You died. Game over(wowwww...weak).");
                Environment.Exit(0);
            }
        }

        private static bool IsRangedWeapon(string weaponName)
        {
            var weapon = WeaponLibrary.AllWeapons.FirstOrDefault(w => w.Name == weaponName);
            return weapon != null && weapon.IsRanged;
        }

        private static int GetPlayerAttack()
        {
            // First check standard weapons
            var standardWeapon = WeaponLibrary.AllWeapons.FirstOrDefault(w => w.Name == Player.Weapon);
            if (standardWeapon != null)
            {
                return standardWeapon.Damage;
            }
            // Then check secret weapons
            var secretWeapon = Inventory.GetSecretWeaponByName(Player.Weapon);
            if (secretWeapon != null)
            {
                return secretWeapon.Damage;
            }
            // Default (unarmed)
            return 2;
        }
    }
}
