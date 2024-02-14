public class Player
{   
    // Properties
    public int HP { get; set; }
    public string Location { get; set; }
    public Weapon Weapon { get; set; }
    public string Name { get; set; }
    public int Max_hp = 100;
    public int Balance;
    public List<Weapon> WeaponsInventory;

    
    // Constructor
    public Player(int hp, string location, Weapon weapon, string name)
    {
        HP = hp;
        Location = location;
        Weapon = weapon;
        Max_hp = 100;
        Name = name;
        Balance = 0;
        WeaponsInventory = new List<Weapon>{};
        
    }

    public void AttackWeapon(Monster monster)
    {
        Random random = new Random();
        double randomValue = random.NextDouble();
        
        if (randomValue < Weapon.CritChance)
        {
            int critDamage = (int)(Weapon.MaxDamage * Weapon.CritDamage);
            monster.HP -= critDamage;
            Console.WriteLine($"Critical Hit! The {monster.Name} took {critDamage} Damage from your {Weapon.Name}\nRemaining HP of {monster.Name}: {monster.HP}");
        }
        else
        {
            monster.HP -= Weapon.MaxDamage;
            Console.WriteLine($"The {monster.Name} took {Weapon.MaxDamage} Damage from your {Weapon.Name}\nRemaining HP of {monster.Name}: {monster.HP}");
        }
    }

    public void ChangeWeapon()
    {
        Console.WriteLine("Select a weapon:");

        int index = 1;
        foreach (Weapon weapon in WeaponsInventory)
        {
            Console.WriteLine($"{index}. {weapon.Name} - Damage: {weapon.MaxDamage}, Crit Damage Multiplier: {weapon.CritDamage}x, Crit Chance: {weapon.CritChance}");
            index++;
        }

        Console.Write("Enter the number of the weapon you want to use: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int weaponIndex) && weaponIndex >= 1 && weaponIndex <= WeaponsInventory.Count)
        {
            Weapon weapon = WeaponsInventory[weaponIndex - 1];

            if (ReferenceEquals(weapon, Weapon))
            {
                Console.WriteLine($"Weapon {weapon.Name} is already selected.");
            }
            else
            {
                Weapon = weapon;
                Console.WriteLine($"You've equipped {weapon.Name}");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }





}