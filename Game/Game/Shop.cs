using Microsoft.VisualBasic;

class Shop
{
    public string Name;
    public List<Weapon> WeaponStock;
    private Random random;

    public Shop(string name)
    {
        Name = name;
        WeaponStock = new List<Weapon>
        {
            new Weapon(101, 30, "Dark Spear", 2, 0.2),
            new Weapon(102, 20, "Old Rusty Sword", 2, 0.15),
            new Weapon(103, 40, "Iron BroadSword", 1, 0),
            new Weapon(104, 35, "Silver Dagger", 3, 0.18),
            new Weapon(105, 25, "Steel Longsword", 2, 0.12),
            new Weapon(106, 45, "Mystic Staff", 4, 0.25),
            new Weapon(107, 18, "Wooden Club", 2, 0.1),
            new Weapon(108, 28, "Poisoned Blade", 3, 0.2),
            new Weapon(109, 38, "Crystal Wand", 3, 0.22),
            new Weapon(110, 22, "Copper Axe", 2, 0.15),
            new Weapon(111, 32, "Flaming Sword", 4, 0.25),
            new Weapon(112, 40, "Thunder Hammer", 3, 0.3),
            new Weapon(113, 19, "Bone Shiv", 2, 0.12),
            new Weapon(114, 50, "Dragon's Breath Bow", 5, 0.35),
            new Weapon(115, 26, "Swift Dagger", 3, 0.18),
            new Weapon(116, 42, "Crystal Blade", 4, 0.28),
            new Weapon(117, 31, "Stone Maul", 3, 0.25),
            new Weapon(118, 23, "Arcane Scepter", 2, 0.2),
            new Weapon(119, 37, "Golden Rapier", 3, 0.3),
            new Weapon(120, 21, "Shadow Dagger", 2, 0.15),
            new Weapon(121, 29, "Frosty Axe", 3, 0.22),
            new Weapon(122, 44, "Soul Reaper Scythe", 5, 0.35),
            new Weapon(123, 33, "Warp Blade", 4, 0.27),
            new Weapon(124, 46, "Celestial Staff", 4, 0.32),
            new Weapon(125, 27, "Vampiric Sword", 3, 0.2),
            new Weapon(126, 39, "Thunderstrike Mace", 3, 0.28),
            new Weapon(127, 24, "Venomous Dagger", 2, 0.16),
            new Weapon(128, 34, "Emerald Glaive", 4, 0.25),
            new Weapon(129, 47, "Phoenix Wing Wand", 5, 0.33),
            new Weapon(130, 20, "Stone Knife", 2, 0.1),
            new Weapon(131, 36, "Obsidian Cleaver", 3, 0.26),
            new Weapon(132, 48, "Lunar Blade", 5, 0.34),
            new Weapon(133, 25, "Whirlwind Flail", 2, 0.15),
            new Weapon(134, 43, "Divine Hammer", 4, 0.3),
            new Weapon(135, 30, "Fiery Halberd", 3, 0.25),
            new Weapon(136, 22, "Spectral Dagger", 2, 0.12),
            new Weapon(137, 49, "Neon Katana", 5, 0.36),
            new Weapon(138, 29, "Ruby-studded Scepter", 3, 0.22),
            new Weapon(139, 18, "Frostbite Dagger", 2, 0.1),
            new Weapon(140, 41, "Stormcaller Staff", 4, 0.28),
            new Weapon(141, 23, "Runic Blade", 2, 0.16),
            new Weapon(142, 32, "Solar Flare Sword", 3, 0.24),
            new Weapon(143, 50, "Ethereal Bow", 5, 0.35),
            new Weapon(144, 27, "Demonic Scimitar", 3, 0.18),
            new Weapon(145, 37, "Plasma Whip", 4, 0.3),
            new Weapon(146, 21, "Ancient War Axe", 2, 0.15),
            new Weapon(147, 46, "Inferno Staff", 5, 0.32),
            new Weapon(148, 35, "Crimson Blade", 4, 0.27),
            new Weapon(149, 24, "Phantom Dagger", 2, 0.14),
            new Weapon(150, 42, "Void Cleaver", 4, 0.29),
        };
        random = new Random();
    }

    public Weapon GetRandomWeapon()
    {
        if(WeaponStock.Count == 0)
        {
            return null;
        }

        int randomIndex = random.Next(WeaponStock.Count);
        return WeaponStock[randomIndex];
    }

    public void BuyWeapon(Player player)
    {
        var w = new World();
        if (player.Balance < 200){w.Text_Display("Not enough gold saved up");}
        if (WeaponStock.Count == 0){w.Text_Display("Shop is empty");}
        else
        {
            player.Balance -= 200;


            int randomIndex = random.Next(0, WeaponStock.Count - 1);
            Weapon new_weapon = WeaponStock[randomIndex];
            w.Text_Display($"You just bought a {new_weapon.Name}, Damage: {new_weapon.MaxDamage}, Crit DMG Multiplier: {new_weapon.CritDamage}, Crit Chance: {new_weapon.CritChance}");
            WeaponStock.Remove(new_weapon);
            player.WeaponsInventory.Add(new_weapon);
        }
    }

    public void BuyPotions(Player player)
    {
        var w = new World();
        w.Text_Display("(1) buy small potion (25 gold)\n(2) buy large potion (100 gold)");
        char pot_choice = Convert.ToChar(Console.ReadLine());

        if(pot_choice == '1')
        {
            w.Text_Display("How many small potions to buy: ");
            int pot1_choice = int.Parse(Console.ReadLine());
            int price_1 = pot1_choice * 25;
            if((player.Balance - pot1_choice) < 0){w.Text_Display("Not enough balance");}
            else
            {
                player.Balance -= price_1;
                player.SmallPotionInventory.PotionQuantity += pot1_choice;
                w.Text_Display("Potions succesfully purchased");
            }
        }
        if(pot_choice == '2')
        {
            w.Text_Display("How many big potions to buy: ");
            int pot1_choice = int.Parse(Console.ReadLine());
            int price_1 = pot1_choice * 100;
            if((player.Balance - pot1_choice) < 0){w.Text_Display("Not enough balance");}
            else
            {
                player.Balance -= price_1;
                player.BigPotionInventory.PotionQuantity += pot1_choice;
                w.Text_Display("Potions succesfully purchased");
            }
        }
        else{Console.WriteLine("Wong input");}
    }

    public bool OpenShop(Player player)
    {
        while (true)
        {
            var w = new World();
            w.Text_Display("Welcome to the shop where you can buy potions and weapons\n(1) Buy Weapon\n(2) Buy Potions\n(3) Exit Shop");
            char choice = Convert.ToChar(Console.ReadLine());

            if (choice == '1')
            {
                BuyWeapon(player);
            }
            else if (choice == '2')
            {
                BuyPotions(player);
            }
            else if (choice == '3')
            {
                w.Text_Display("You left the shop");
                return false;
            }
            else
            {
                w.Text_Display("Invalid input. Please choose a valid option.");
            }
        }
    }

}