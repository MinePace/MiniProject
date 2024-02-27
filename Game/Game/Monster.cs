public class Monster
{    
    // Properties
    public int HP { get; set; }
    public int MaxHP { get; set; }
    public int ID { get; set; }
    public Weapon Weapon { get; set; }
    public string Name { get; set; }
    public MonsterDrop ItemDrop { get; set; }
    public double ItemDropChance { get; set; }

    // Constructor
    public Monster(int hp, int maxHP, int id, Weapon weapon, string name, MonsterDrop itemdrop, double itemdropchance)
    {
        HP = hp;
        MaxHP = maxHP;
        ID = id;
        Weapon = weapon;
        Name = name;
        ItemDrop = itemdrop;
        ItemDropChance = itemdropchance;
    }

    public void AttackWeapon(Player player)
    {
        var w = new World();
        Random random = new Random();
        double randomValue = random.NextDouble();
        
        if (randomValue < Weapon.CritChance)
        {
            int critDamage = (int)(Weapon.MaxDamage * Weapon.CritDamage);
            player.HP -= critDamage;
            if (player.HP <= 0){player.HP = 0;}
            w.Text_Display($"Critical Hit! The {player.Name} took {critDamage} Damage from your {Weapon.Name}\nRemaining HP of {player.Name}: {player.HP}");
        }
        else
        {
            player.HP -= Weapon.MaxDamage;
            if (player.HP <= 0){player.HP = 0;}
            w.Text_Display($"The {player.Name} took {Weapon.MaxDamage} Damage from your {Weapon.Name}\nRemaining HP of {player.Name}: {player.HP}");
        }
    }

}