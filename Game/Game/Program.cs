using System;
using System.Threading;

public class Program
{
    public static void Main()
    {
        Weapon katana = new Weapon(1, 20, "Platinum Katana");
        Monster Goblin = new Monster(100, 100, 1, 20, "Goblin");
        Player player = new Player(100, "Starter area", katana, "Jef");

        player.attack_weapon(Goblin);
    }
}
