class Monsters
{    
    // Properties
    public int HP { get; set; }
    public int MaxHP { get; set; }
    public int ID { get; set; }
    public int MaxDamage { get; set; }
    public string Name { get; set; }

    // Constructor
    public Monsters(int hp, int maxHP, int id, int maxDamage, string name)
    {
        HP = hp;
        MaxHP = maxHP;
        ID = id;
        MaxDamage = maxDamage;
        Name = name;
    }

    public void CalculateHP_Monster()
    {

    }

}