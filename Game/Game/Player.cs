public class Player
{   
    // Properties
    public int HP { get; set; }
    public string Location { get; set; }
    public string Weapon { get; set; }
    public string Name { get; set; }
    public int Max_hp = 100;

    
    // Constructor
    public Player(int hp, string location, string weapon, string name)
    {
        HP = hp;
        Location = location;
        Weapon = weapon;
        Max_hp = 100;
        Name = name;
    }

    public void CalculateHP()
    {
        
    }



}