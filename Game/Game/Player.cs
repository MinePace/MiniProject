using System.Globalization;

public class Player
{   
    // Properties
    public int HP { get; set; }
    public string Location { get; set; }
    public Weapon Weapon { get; set; }
    public string Name { get; set; }
    public int Max_hp = 100;
    public int Balance { get; set; }
    public List<MonsterDrop> MonsterDropsInventory { get; set; }
    public List<Weapon> WeaponsInventory { get; set; }
    public Potion SmallPotionInventory { get; set; }
    public Potion BigPotionInventory { get; set; }

    
    // Constructor
    public Player(int hp, string location, Weapon weapon, string name, Potion smallpotioninventory, Potion bigpotioninventory)
    {
        HP = hp;
        Location = location;
        Weapon = weapon;
        Max_hp = 100;
        Name = name;
        Balance = 0;
        WeaponsInventory = new List<Weapon>{};
        SmallPotionInventory = smallpotioninventory;
        BigPotionInventory = bigpotioninventory;
        MonsterDropsInventory = new List<MonsterDrop>{};
        
    }

    public void AttackWeapon(Monster monster)
    {
        Random random = new Random();
        double randomValue = random.NextDouble();
        
        if (randomValue < Weapon.CritChance)
        {
            int critDamage = (int)(Weapon.MaxDamage * Weapon.CritDamage);
            monster.HP -= critDamage;
            if (monster.HP <= 0){monster.HP = 0;}
            Console.WriteLine($"Critical Hit! The {monster.Name} took {critDamage} Damage from your {Weapon.Name}\nRemaining HP of {monster.Name}: {monster.HP}");
        }
        else
        {
            monster.HP -= Weapon.MaxDamage;
            if (monster.HP <= 0){monster.HP = 0;}
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
        Console.WriteLine("\n");
    }

    public void ConsumePotion(Potion potion)
    {
        Console.WriteLine($"You consumed a {potion.Name} for {potion.PotionEffect} HP");
        HP += potion.PotionEffect;
        if (HP > Max_hp){HP = Max_hp;}
        Console.WriteLine($"HP after consuming potion: {HP}");
    }

    public void GivePotion(Potion potion)
    {
        potion.PotionQuantity += 1;
    }

    public void OpenInventory()
    {
        Console.WriteLine("Weapon Inventory: ");
        foreach(Weapon weapon in WeaponsInventory)
        {
            Console.WriteLine($"{weapon.Name}, Damage: {weapon.MaxDamage}, Crit DMG Multiplier: {weapon.CritDamage}, Crit Chance: {weapon.CritChance}");
        }

        Console.WriteLine("\nDrops inventory: ");
        {
            foreach (MonsterDrop drop in MonsterDropsInventory)
            {
                Console.WriteLine($"{drop.Name}, Description: {drop.Description}, Quantity: {drop.DropQuantity}");
            }
        }

        Console.WriteLine("\nPotion inventory:");
        if(SmallPotionInventory.PotionQuantity > 0)
        {
        Console.WriteLine($"Small Health Potion, Amount left: {SmallPotionInventory.PotionQuantity}");
        }
        if(BigPotionInventory.PotionQuantity > 0)
        {
        Console.WriteLine($"Big Health Potion, Amount left: {BigPotionInventory.PotionQuantity}\n");
        }
    }

    public void Compass()
    {
        string North = @"N
|
/
        ";

        string South = @"/
|
S
";

        string East = @"/--E";

        string West = @"W--/";

        string NorthSouth = @"N
|       
/
|
S
";

        string EastWest = @"W--/--E";

        string Centre = @"   N
   |
W--+--E
   |
   S        
";


        if(Location == "Your House")
        {
            Console.WriteLine(North);
        }
        if(Location == "Town Square")
        {
            Console.WriteLine(Centre);
        }
        if(Location == "Farmer")
        {
            Console.WriteLine(EastWest);
        }
        if(Location == "Farmer's Fields")
        {
            Console.WriteLine(East);
        }
        if(Location == "Alchemist’s Hut")
        {
            Console.WriteLine(NorthSouth);
        }
        if(Location == "Alchemist’s Garden")
        {
            Console.WriteLine(South);
        }
        if(Location == "Guard Post")
        {
            Console.WriteLine(EastWest);
        }
        if(Location == "Bridge")
        {
            Console.WriteLine(EastWest);
        }
        if(Location == "Spider Forest")
        {
            Console.WriteLine(West);
        }
        Console.WriteLine(Location);
    }

    public void ExitGame()
    {
        Environment.Exit(0);
    }

    public bool OpenOptions()
    {
        while(true)
        {
            Console.WriteLine("(1) Switch weapon\n(2) Open inventory\n(3) Exit game (all progress lost)\n(4) Exit options");
            string choice = Console.ReadLine();
            if (choice == "1"){ChangeWeapon();}
            if (choice == "2"){OpenInventory();}
            if (choice == "3"){ExitGame();}
            if (choice == "4"){return false;}
        }
    }

    public void DropMonsterItem(Monster monster)
    {
        Random random = new Random();
        int randomNumber = random.Next(1, 4);
        double randomdouble = random.NextDouble();

        if (randomdouble < monster.ItemDropChance)
        {
            monster.ItemDrop.DropQuantity += randomNumber;
        }
    }
        
}