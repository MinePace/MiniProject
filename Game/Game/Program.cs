using System;
using System.Threading;

public class Program
{
    public static void Main()
    {
        Weapon Spear = new Weapon(1, 30, "Dark Spear", 2, 0.2);
        Weapon Katana = new Weapon(2, 20, "Platinum Katana", 3, 0.15);
        Weapon BroadSword = new Weapon(3, 40, "Iron BroadSword", 1, 0);

        Potion SmallHealthPotion = new Potion("Small Health Potion", "Potion that heals for 50HP", 50, 0);
        Potion BigHealthPotion = new Potion("Big Health Potion", "Potion that heals for 100HP ", 100, 0);
        Monster Goblin = new Monster(100, 100, 1, Spear, "Goblin");
        Monster Zombie = new Monster(100, 100, 1, BroadSword, "Zombie");
        Player Player1 = new Player(100, "Starter area", Katana, "Jef", SmallHealthPotion, BigHealthPotion);
        SuperAdventure MainBattle = new SuperAdventure(Goblin, Player1);
        Player1.WeaponsInventory.Add(Katana);
        Player1.WeaponsInventory.Add(BroadSword);

        Player1.OpenOptions();
        
        Console.WriteLine("Start Battle?");
        Console.WriteLine();
        
        MainBattle.CurrentMonster = Zombie;
        MainBattle.FightMonster();
        
        Player1.BigPotionInventory.PotionQuantity += 3;

        MainBattle.CurrentMonster = Goblin;
        MainBattle.FightMonster();
    }
}
