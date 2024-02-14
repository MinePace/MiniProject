public class Monster
{    
    // Properties
    public int HP { get; set; }
    public int MaxHP { get; set; }
    public int ID { get; set; }
    public Weapon Weapon { get; set; }
    public string Name { get; set; }

    // Constructor
    public Monster(int hp, int maxHP, int id, Weapon weapon, string name)
    {
        HP = hp;
        MaxHP = maxHP;
        ID = id;
        Weapon = weapon;
        Name = name;
    }

    public void AttackWeapon(Player player)
    {
        Random random = new Random();
        double randomValue = random.NextDouble();
        
        if (randomValue < Weapon.CritChance)
        {
            int critDamage = (int)(Weapon.MaxDamage * Weapon.CritDamage);
            player.HP -= critDamage;
            if (player.HP <= 0){player.HP = 0;}
            Console.WriteLine($"Critical Hit! The {player.Name} took {critDamage} Damage from your {Weapon.Name}\nRemaining HP of {player.Name}: {player.HP}");
        }
        else
        {
            player.HP -= Weapon.MaxDamage;
            if (player.HP <= 0){player.HP = 0;}
            Console.WriteLine($"The {player.Name} took {Weapon.MaxDamage} Damage from your {Weapon.Name}\nRemaining HP of {player.Name}: {player.HP}");
        }
    }

}