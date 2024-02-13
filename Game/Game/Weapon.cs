class Weapon
{   
    // Properties
    public int ID { get; set; }
    public int MaxDamage { get; set; }
    public string Name { get; set; }

    // Constructor
    public Weapon(int id, int maxDamage, string name)
    {
        ID = id;
        MaxDamage = maxDamage;
        Name = name;
    }
}