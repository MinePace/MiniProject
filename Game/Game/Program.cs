using System;
using System.Threading;

public class Program
{
    public static void Main()
    {
        Weapon spear = new Weapon(1, 30, "Dark Spear");
        Weapon katana = new Weapon(2, 20, "Platinum Katana");
        Monster Goblin = new Monster(100, 100, 1, spear, "Goblin");
        Player player1 = new Player(100, "Starter area", katana, "Jef");

        player1.attack_weapon(Goblin);
        Goblin.attack_weapon(player1);
    }
}
