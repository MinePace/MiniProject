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

    public void attack_weapon(Player player)
    {
        player.HP -= Weapon.MaxDamage;
        Console.WriteLine($"The {player.Name} took {Weapon.MaxDamage} Damage from the {Name}'s {Weapon.Name}\nRemaining HP of {player.Name}: {player.HP}");
    }

}