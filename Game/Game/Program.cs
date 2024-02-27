
using System;
using System.Threading;

public class Program
{
    public static void Main()
    {
        var w = new World();
        // Window title
        
        Console.Title = "Game"; 

        // instancing weapons for monster
        Weapon Goblindagger = new Weapon(1, 30, "Goblin Dagger", 2, 0.2);
        Weapon Zombiesword = new Weapon(2, 20, "Zombie sword", 2, 0.2);
        Weapon Spiderfangs = new Weapon(3, 40, "Spider fangs", 2, 0.2);
        Weapon Snakefangs = new Weapon(4, 15, "Snake fangs", 1.5, 0.1);
        Weapon Ratteeth = new Weapon(5, 15, "Rat teeth", 1.5, 0.15);

        // instancing weapons
        Weapon Spear = new Weapon(101, 30, "Dark Spear", 2, 0.2);
        Weapon OldRustySword = new Weapon(102, 20, "Old Rusty Sword", 2, 0.15);
        Weapon BroadSword = new Weapon(103, 40, "Iron BroadSword", 1, 0);
        Weapon FarmersScythe = new Weapon(104, 35, "Harvestbane", 2, 0.3);
        Weapon BladeofDesolation = new Weapon(666, 100, "Blade of Desolation",3, 0.5); 

        
        Weapon TESTING_PURPOSES = new Weapon(999, 100, "TEST SWORD", 4, 1);

        // instancing Potions
        Potion SmallHealthPotion = new Potion("Small Health Potion", "Potion that heals for 50HP", 50, 0);
        Potion BigHealthPotion = new Potion("Big Health Potion", "Potion that heals for 100HP ", 100, 0);

        // instancing MobDrops
        MonsterDrop RottenFlesh = new MonsterDrop("Rotten flesh", "Flesh of a dead zombie", 0);
        MonsterDrop GoblinTeeth = new MonsterDrop("Goblin teeth", "Teeth of a goblin", 2);
        MonsterDrop Spidereye = new MonsterDrop("Spider Eye", "Eye of a spider", 1);
        MonsterDrop BladeofDesolation_item = new MonsterDrop("Blade of Desolation", @"The Blade of Desolation is a massive two-handed sword, 
its blade as black as the void itself and pulsating with malevolent energy.
It is adorned with intricate runes that writhe and twist with dark power, emanating an aura of dread to all who dare to gaze upon it.",1);
        MonsterDrop SnakeScales = new MonsterDrop("Snake scales", "Scales of a snake", 1);
        MonsterDrop RatTail = new MonsterDrop("Rat tail", "Tail from a rat", 1);

        // instancing Monsters
        Monster Goblin = new Monster(100, 100, 1, Goblindagger, "Goblin", GoblinTeeth, 0.80);
        Monster Zombie = new Monster(100, 100, 2, Zombiesword, "Zombie", RottenFlesh, 0.70);
        Monster Spider = new Monster(100, 100, 3, Spiderfangs, "Spider", Spidereye, 0.30);
        Monster Azazel1 = new Monster(2000, 2000, 666, BladeofDesolation, "Azazel", BladeofDesolation_item, 1);
        Monster Snake = new Monster(100, 100, 4, Snakefangs, "Snake", SnakeScales, 0.30);
        Monster Rat = new Monster(100, 100, 5, Ratteeth, "Rat", RatTail, 0.50);


        // instancing player
        Console.WriteLine("What is your name?:");
        string playername = Console.ReadLine();
        Player Player1 = new Player(100, "Your House", OldRustySword, playername , SmallHealthPotion, BigHealthPotion);

        //random bog
        SuperAdventure MainBattle = new SuperAdventure(Goblin, Player1);
        SuperAdventure Snakeinfields = new SuperAdventure(Snake, Player1);
        SuperAdventure Ratingarden = new SuperAdventure(Rat, Player1);


        //instance shop
        Shop WeaponMaster = new Shop("Weapon master's shop");

        // adding stuff to inventory
        Player1.WeaponsInventory.Add(OldRustySword);
        Player1.WeaponsInventory.Add(BroadSword);
        Player1.WeaponsInventory.Add(TESTING_PURPOSES);
        Player1.BigPotionInventory.PotionQuantity += 10;

        Player1.MonsterDropsInventory.Add(GoblinTeeth);
        Player1.MonsterDropsInventory.Add(RottenFlesh);

        // instancing Quests
        Quest fieldFrenzyQuest = new Quest(
            @"Farmer Jones, a local farmer, is facing a dire situation with an unexpected snake infestation on his farm.
            The snakes have disrupted daily operations, causing distress among the livestock and posing a threat to the crops.
            Your task is to exterminate the snakes",
            "Field frenzy",
            1); 
        Quest gardenMenaceQuest = new Quest(
            @"Alchemist Isaac's garden has been overrun by an unusually aggressive breed of rats. 
            The rodents, drawn by the potent scents of alchemical ingredients, pose a threat to the garden's flora. 
            Isaac seeks brave adventurers to eliminate the rat infestation and restore peace to his sanctuary of alchemy.",
            "Rat Troubles",
            2);
        Quest radiantResonanceQuest = new Quest(
            @"Under the silvery veil of the moonlit forest, a glimmer catches your eye—a hidden shrine, pulsating with an enigmatic energy. 
Intrigued, you approach cautiously, only to be ambushed by spectral creatures, their presence unsettling
With blade in hand, you defend yourself against the onslaught, each swing a dance of survival against the unknown. 
As the skirmish reaches its peak, a blinding light erupts from the shrine, driving the creatures back.
From within emerges a celestial guardian, its form cloaked in luminescent robes.
It hails you as defender of the shrine, gifting you with its otherworldly power as gratitude for your bravery.
With the guardian's blessing, you embark on your journey anew,
the weight of its magic guiding your steps through the darkness that lay ahead.",
            "Radiant Resonance",
            3);
        Quest echoesOfObligationQuest = new Quest(
            @"Lost in the dense woods, a mysterious figure appears, 
compelling you to aid them with an urgency that brooks no refusal. 
You succumb to a sudden dizziness, awakening in an unfamiliar place.
A note on a nearby table reveals you're bound by a pact to aid an 
unnamed author in a quest crucial to the realm's survival. 
With no choice but to comply, you prepare for the journey ahead, 
knowing your fate is entwined with theirs.",
            "Echoes of Obligation",
            4);
        Quest Thefallenoverlord = new Quest("Defeat the fallen overloard", "The fallen Overlord", 5);

        // instancing Npc
        Npc Farmer_joe = new Npc("Farmer Joe", "Im a farmer", 1, fieldFrenzyQuest);
        Npc Alchemist_Isaac = new Npc("Alchemist Isaac", "Im a alchemist", 2, gardenMenaceQuest);
        Npc Voices = new Npc("The Voices", "", 3, radiantResonanceQuest);
        Npc Unknown = new Npc("???", "???",4, echoesOfObligationQuest);
        Npc Azazel = new Npc("Azazel the Fallen Overlord", "", 5, Thefallenoverlord);

        // variable for quest tasks
        int snake_kills = 0;
        int rat_kills = 0;

        //MainBattle.FightMonster();
        // Player1.HP = Player1.Max_hp;
        // Player1.OpenInventory();
        // MainBattle.FightMonster();
        // Player1.OpenInventory();
        // Player1.HP = Player1.Max_hp;
        // MainBattle.FightMonster();
        // Player1.OpenInventory();
        while(true)
        {
            Player1.Location = w.MovePlayer(Player1.Location);
            
            if(Player1.Location == "Farmer")
            {
                    Farmer_joe.InteractWithNPC();

                    // Code to when completing the quest
            }
            if (Player1.Location == "Farmer's Field" && Farmer_joe.Quest.isAccepted == true)
            {   
                w.Text_Display("The task of the quest is to kill 3 Snakes");

                while (snake_kills != 3)
                {
                    Console.WriteLine("You have 2 options:");
                    Console.WriteLine("1. Fight Snakes");
                    Console.WriteLine("2. Leave");
                    string Farmerfields = Console.ReadLine();

                    if (Farmerfields == "1")
                    {
                        //battle snake
                        Snakeinfields.FightMonster();
                        snake_kills += 1;
                        Console.WriteLine($"killed {snake_kills}/3");
                    }
                    if (Farmerfields == "2")
                    {
                        break;
                    }
                    
                }
            if (snake_kills == 3)
                    {
                        Farmer_joe.Quest.isTaskCompelete = true;
                    }

            }
            //alchemist hut & alchemist garden
            if(Player1.Location == "Alchemist's Hut")
            {
                    Alchemist_Isaac.InteractWithNPC();

                    // Code to when completing the quest
            }
            if (Player1.Location == "Alchemist's Garden" && Alchemist_Isaac.Quest.isAccepted == true)
            {   
                w.Text_Display("The task of the quest is to kill 3 rats");

                while (rat_kills != 3)
                {
                    Console.WriteLine("You have 2 options:");
                    Console.WriteLine("1. Fight Rats");
                    Console.WriteLine("2. Leave");
                    string Alchemistgarden = Console.ReadLine();

                    if (Alchemistgarden == "1")
                    {
                        //battle rat
                        Ratingarden.FightMonster();
                        rat_kills += 1;
                        Console.WriteLine($"killed {rat_kills}/3");
                    }
                    if (Alchemistgarden == "2")
                    {
                        break;
                    }
                    
                }
            if (rat_kills == 3)
                    {
                        Alchemist_Isaac.Quest.isTaskCompelete = true;
                    }

            }

            if (Player1.Location == "Weapon Master's Shop")
            {
                WeaponMaster.OpenShop(Player1);
            }
        }
        
        
        //Player1.Balance += 1000;
        //WeaponMaster.OpenShop(Player1);
        //Player1.ChangeWeapon();
        //MainBattle.FightMonster();
        


        
        //MainBattle.FightMonster();     
    }
}