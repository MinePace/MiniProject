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
    public int PlayerEXP { get; set; }
    public int PlayerLevel { get; set; }

    
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
        PlayerEXP = 0;
        PlayerLevel = 1;
        
    }

    public void AttackWeapon(Monster monster)
    {
        var w = new World();
        Random random = new Random();
        double randomValue = random.NextDouble();
        
        if (randomValue < Weapon.CritChance)
        {
            int critDamage = (int)(Weapon.MaxDamage * Weapon.CritDamage);
            monster.HP -= critDamage;
            if (monster.HP <= 0){monster.HP = 0;}
            w.Text_Display($"Critical Hit! The {monster.Name} took {critDamage} Damage from your {Weapon.Name}\nRemaining HP of {monster.Name}: {monster.HP}");
        }
        else
        {
            monster.HP -= Weapon.MaxDamage;
            if (monster.HP <= 0){monster.HP = 0;}
            w.Text_Display($"The {monster.Name} took {Weapon.MaxDamage} Damage from your {Weapon.Name}\nRemaining HP of {monster.Name}: {monster.HP}");
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
        var w = new World();
        w.Text_Display($"You consumed a {potion.Name} for {potion.PotionEffect} HP");
        HP += potion.PotionEffect;
        if (HP > Max_hp){HP = Max_hp;}
        w.Text_Display($"HP after consuming potion: {HP}");
    }

    public void GivePotion(Potion potion)
    {
        potion.PotionQuantity += 1;
    }

    public void OpenInventory()
    {
        var w = new World();
        w.Text_Display("Weapon Inventory: ");
        foreach(Weapon weapon in WeaponsInventory)
        {
            w.Text_Display($"{weapon.Name}, Damage: {weapon.MaxDamage}, Crit DMG Multiplier: {weapon.CritDamage}, Crit Chance: {weapon.CritChance}");
        }

        w.Text_Display("\nDrops inventory: ");
        {
            foreach (MonsterDrop drop in MonsterDropsInventory)
            {
                w.Text_Display($"{drop.Name}, Description: {drop.Description}, Quantity: {drop.DropQuantity}");
            }
        }

        w.Text_Display("\nPotion inventory:");
        if(SmallPotionInventory.PotionQuantity > 0)
        {
        w.Text_Display($"Small Health Potion, Amount left: {SmallPotionInventory.PotionQuantity}");
        }
        if(BigPotionInventory.PotionQuantity > 0)
        {
        w.Text_Display($"Big Health Potion, Amount left: {BigPotionInventory.PotionQuantity}\n");
        }
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
            switch(Convert.ToInt16(choice))
            {
                case 1:
                    ChangeWeapon();
                    break;

                case 2:
                    OpenInventory();
                    break;

                case 3:
                    ExitGame();
                    break;

                case 4:
                    return false;
            }
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

    public void WipeOut()
    {
        var w = new World();
        w.Text_Display("You blacked out you wake up at home.");
        Location = "Your House";
        if(Balance > 20)
        {
        Balance -= 20;
        }
        HP = Max_hp;
    }

    public void LevelUp()
    {
        var w = new World();
        PlayerEXP += 20;

        if (PlayerEXP >= 100 + 20 * (PlayerLevel - 1))
        {
            PlayerLevel += 1;
            Max_hp += 20;
            HP += 20;
            Weapon.CritChance += 0.5;
            w.Text_Display($"You have leveled up. New Level: {PlayerLevel}");
            if (Max_hp > 500){Max_hp = 500;}
            if (Weapon.CritChance > 1){Weapon.CritChance = 1;}
        }
    }
}