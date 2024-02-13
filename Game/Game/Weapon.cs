public class Weapon
{   
    // Properties
    public int ID { get; set; }
    public int MaxDamage { get; set; }
    public string Name { get; set; }
    public double CritDamage { get; set; }
    public double CritChance { get; set;}

    // Constructor
    public Weapon(int id, int maxDamage, string name, double critdamage, double critchance)
    {
        ID = id;
        MaxDamage = maxDamage;
        Name = name;
        CritDamage = critdamage;
        CritChance = critchance;

    }
}