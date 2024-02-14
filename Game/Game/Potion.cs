public class Potion
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int PotionEffect { get; set; }

    public Potion(string name, string description, int potioneffect)
    {
        Name = name;
        Description = description;
        PotionEffect = potioneffect;
    }

}