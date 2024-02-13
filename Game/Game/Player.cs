public class Player
{   
    // Properties
    public int HP { get; set; }
    public string Location { get; set; }
    public Weapon Weapon { get; set; }
    public string Name { get; set; }
    public int Max_hp = 100;

    
    // Constructor
    public Player(int hp, string location, Weapon weapon, string name)
    {
        HP = hp;
        Location = location;
        Weapon = weapon;
        Max_hp = 100;
        Name = name;
    }

    public void attack_weapon(Monster monster)
    {
        monster.HP -= Weapon.MaxDamage;
        Console.WriteLine($"The {monster.Name} took {Weapon.MaxDamage} Damage from your {Weapon.Name}\nRemaining HP of {monster.Name}: {monster.HP}");
    }



}