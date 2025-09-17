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
        // Main combat loop between Player and a Monster
        public static void Fight(Monster monster)
        {
            Console.WriteLine($"A wild {monster.Name} appears!");
            int monsterHealth = monster.Health;

            // Get currently equipped weapon (if any)
            Weapons weapon = WeaponLibrary.AllWeapons.FirstOrDefault(w => w.Name == Player.Weapon);

            // Combat loop continues until either monster or player dies
            while (monsterHealth > 0 && Player.Health > 0)
            {
                // Refresh weapon info every turn in case player changes weapon
                weapon = WeaponLibrary.AllWeapons.FirstOrDefault(w => w.Name == Player.Weapon);
                string weaponUses;

                // Determine how many uses the weapon has left
                if (weapon != null)
                {
                    weaponUses = weapon.UsesLeft.ToString();
                }
                else
                {
                    var secretWeapon = Inventory.GetSecretWeaponByName(Player.Weapon);
                    if (secretWeapon != null)
                    {
                        weaponUses = "1"; // Secret weapons = single-use
                    }
                    else
                    {
                        weaponUses = "Infinite "; // Fists (unarmed) have no limit
                    }
                }

                // Display current status of player, monster, and weapon
                Console.WriteLine($"\nYour Health: {Player.Health} | Weapon: {Player.Weapon ?? "fists"} | Weapon Damage: {GetPlayerAttack()} | Weapon Uses: {weaponUses} || {monster.Name} Health: {monsterHealth} | Monster Damage: {monster.Damage}| Drop: {monster.Coins} | Distance: {monster.SpawnPoint}");
                Console.WriteLine("Choose your action: (attack/K.O/change weapon/run)");

                string action = Console.ReadLine().ToLower();

                // Player chooses to ATTACK
                if (action == "attack")
                {
                    // Case 1: Ranged weapon attack
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

                        // Monster slowly moves closer to the player
                        monster.SpawnPoint = Math.Max(0, monster.SpawnPoint - 1);

                        // Check if monster is dead
                        if (monsterHealth <= 0)
                        {
                            Console.WriteLine($"You defeated the {monster.Name}!");
                            Player.Coins += monster.Coins;
                            break;
                        }
                    }
                    // Case 2: fist or close weapon
                    else
                    {
                        Console.WriteLine("The monster teleports close(lol)!");
                        int damageToDeal = 2; // Base unarmed damage

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

                        // Monster is now right next to player
                        monster.SpawnPoint = 0;

                        // Check if monster is dead
                        if (monsterHealth <= 0)
                        {
                            Console.WriteLine($"You defeated the {monster.Name}(FINALLYYYY)!");
                            Player.Coins += monster.Coins;
                            break;
                        }

                        // Monster counters with damage
                        Player.Health -= monster.Damage;
                        Console.WriteLine($"The {monster.Name} attacks you and deals {monster.Damage} damage(SHIIIII)!");
                    }
                }

                // Player chooses K.O. (Secret Weapon)
                else if (action == "k.o")
                {
                    SecretWeapons secretWeapon = Inventory.GetSecretWeaponByName(Player.Weapon);

                    if (secretWeapon != null)
                    {
                        monsterHealth -= secretWeapon.Damage;
                        Console.WriteLine($"You use your {secretWeapon.Name} to deal a massive {secretWeapon.Damage} damage(DAWMMMM CLOCK ITTT)!");

                        // Secret weapons break after single use
                        Console.WriteLine("Since this is a single use weapon it is now broken(*sad mini violin music in background*)");
                        Player.Items.Remove(secretWeapon.Name);
                        Player.Weapon = null;

                        if (monsterHealth <= 0)
                        {
                            Console.WriteLine($"You defeated the {monster.Name}(GIRLIE ATEEEEE. LEFT NO CRUMBS)!");
                            Player.Coins += monster.Coins;
                            break;
                        }

                        // Monster retaliates
                        Player.Health -= monster.Damage;
                        Console.WriteLine($"The {monster.Name} attacks you and deals {monster.Damage} damage(GIRLIE ATE...but left crumbs)!");
                    }
                    else
                    {
                        Console.WriteLine("You don't have a secret weapon equipped(oh...um ew)!");
                    }
                }

                // Player chooses to CHANGE WEAPON
                else if (action == "change weapon")
                {
                    Inventory.DisplayInventory();

                    var newWeapon = WeaponLibrary.AllWeapons.FirstOrDefault(w => w.Name == Player.Weapon);

                    // If player equips ranged weapon, monster distance resets
                    if (newWeapon != null && newWeapon.IsRanged)
                    {
                        monster.SpawnPoint = +15; 
                        Console.WriteLine("The monster moves away as you switch to a ranged weapon(*nods head proudly*).");
                    }
                }

                // Player chooses to RUN
                else if (action == "run")
                {
                    Console.WriteLine("You attempt to run away...(lol couldn't be me)");
                    run.RunAway();
                    break;
                }

                // Invalid action
                else
                {
                    Console.WriteLine("Invalid action! The monster attacks you(HAH).");
                    Player.Health -= monster.Damage;
                }
            }

            // If player is dead → Game over
            if (Player.Health <= 0)
            {
                Console.WriteLine("You died. Game over(wowwww...weak).");
                Environment.Exit(0);
            }
        }

        // Check if a given weapon name corresponds to a ranged weapon
        private static bool IsRangedWeapon(string weaponName)
        {
            var weapon = WeaponLibrary.AllWeapons.FirstOrDefault(w => w.Name == weaponName);
            return weapon != null && weapon.IsRanged;
        }

        // Get player's attack value depending on equipped weapon
        private static int GetPlayerAttack()
        {
            // Standard weapons
            var standardWeapon = WeaponLibrary.AllWeapons.FirstOrDefault(w => w.Name == Player.Weapon);
            if (standardWeapon != null)
            {
                return standardWeapon.Damage;
            }

            // Secret weapons
            var secretWeapon = Inventory.GetSecretWeaponByName(Player.Weapon);
            if (secretWeapon != null)
            {
                return secretWeapon.Damage;
            }

            // Default damage if unarmed
            return 2;
        }
    }
}
