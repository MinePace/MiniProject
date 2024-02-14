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
        
        
        Player1.ChangeWeapon();
        Player1.GivePotion(BigHealthPotion);
        Player1.GivePotion(SmallHealthPotion);

        
        MainBattle.CurrentMonster = Zombie;
        MainBattle.FightMonster();
        
        
        ///hey
    }
}
