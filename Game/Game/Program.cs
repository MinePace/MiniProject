using System;
using System.Threading;

public class Program
{
    public static void Main()
    {
        var w = new World();

        // instancing weapons for monster
        Weapon Goblindagger = new Weapon(1, 30, "Goblin Dagger", 2, 0.2);
        Weapon Zombiesword = new Weapon(2, 20, "Zombie sword", 2, 0.2);
        Weapon Spiderfangs = new Weapon(3, 40, "Spider fangs", 2, 0.2);
        Weapon Snakefangs = new Weapon(4, 30, "Snake fangs", 2, 0.4);

        // instancing weapons
        Weapon Spear = new Weapon(101, 30, "Dark Spear", 2, 0.2);
        Weapon Katana = new Weapon(102, 20, "Platinum Katana", 3, 0.15);
        Weapon BroadSword = new Weapon(103, 40, "Iron BroadSword", 1, 0);

        // instancing Potions
        Potion SmallHealthPotion = new Potion("Small Health Potion", "Potion that heals for 50HP", 50, 0);
        Potion BigHealthPotion = new Potion("Big Health Potion", "Potion that heals for 100HP ", 100, 0);

        // instancing MobDrops
        MonsterDrop RottenFlesh = new MonsterDrop("Rotten flesh", "Flesh of a dead zombie", 0);
        MonsterDrop GoblinTeeth = new MonsterDrop("Goblin teeth", "Teeth of a goblin", 2);
        MonsterDrop Spidereye = new MonsterDrop("Spider Eye", "Eye of a spider", 1);
        MonsterDrop SnakeScales = new MonsterDrop("Snake scales", "Scales of a snake", 1);

        // instancing Monsters
        Monster Goblin = new Monster(100, 100, 1, Goblindagger, "Goblin", GoblinTeeth, 0.80);
        Monster Zombie = new Monster(100, 100, 2, Zombiesword, "Zombie", RottenFlesh, 0.70);
        Monster Spider = new Monster(100, 100, 3, Spiderfangs, "Spider", Spidereye, 0.30);
        Monster Snake = new Monster(120, 100, 4, Snakefangs, "Snake", SnakeScales, 0.30);
         
        // instancing player
        Console.WriteLine("What is your name?:");
        string playername = Console.ReadLine();
        Player Player1 = new Player(100, "Your House", Katana, playername , SmallHealthPotion, BigHealthPotion);

        //random bog
        SuperAdventure MainBattle = new SuperAdventure(Goblin, Player1);

        // adding stuff to inventory
        Player1.WeaponsInventory.Add(Katana);
        Player1.WeaponsInventory.Add(BroadSword);
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
        Quest MinersMercyQuest = new Quest(
            @"The Miner of the town rushes towards you in distress, his face lined with worry. He explains that his friend, a fellow miner 
has been viciously attacked by monsters deep within the caverns and is in desperate need of rescue. Without hesitation, you heed the miner's plea for help, 
understanding the urgency of the situation. Equipping yourself with the necessary gear, you venture into the dark depths of the mines, 
the echoes of your footsteps mingling with the distant rumble of unseen dangers. Navigating through the labyrinthine tunnels, 
you press forward with determination, guided by the flickering light of your torch. The air grows heavy with each step,
and the oppressive silence is broken only by the occasional drip of water echoing in the darkness.",
            "Miner's Mercy",
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
        Npc Miner_dig = new Npc("Miner Dig", "Im a miner", 2, MinersMercyQuest);
        Npc Voices = new Npc("The Voices", "", 3, radiantResonanceQuest);
        Npc Unknown = new Npc("???", "???",4, echoesOfObligationQuest);
        Npc Azazel = new Npc("Azazel the Fallen Overlord", "", 5, Thefallenoverlord);

        // MainBattle.FightMonster();
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
                    w.Text_Display(fieldFrenzyQuest.Description);
                }
            
            //Start of farmer location code
            Player1.Location = "Farmer"; //placeholder to test the loop
            while (Player1.Location == "Farmer")
            {
                Console.WriteLine($"Current location: {Player1.Location}");
                Console.WriteLine("What would you like to do (Enter a number)?");
                Console.WriteLine("1: Change weapons");
                Console.WriteLine("2: Speak with Farmer Joe");
                Console.WriteLine("3: Move");
                Console.WriteLine("4: Quit");
                int UserInput = Convert.ToInt32(Console.ReadLine());
                if (UserInput == 1)
                {
                    Player1.ChangeWeapon();
                }
                else if (UserInput == 2)
                {
                    Console.WriteLine("Howdy! \nSnakes are wreaking havoc on my farm. Can you help? ");
                    Console.WriteLine("1: Accept quest ");
                    Console.WriteLine("2: Refuse quest");
                    if (fieldFrenzyQuest.IsComplete == true)      //if quest completed show extra dialogue
                        Console.WriteLine("3: Hand in the quest");

                    int AnswerToJoe = Convert.ToInt32(Console.ReadLine());
                    if (AnswerToJoe == 1)
                    {
                        Console.WriteLine("You accepted the quest");
                    }
                    else if (AnswerToJoe == 2)
                    {
                        Console.WriteLine("You have refused the quest");
                    }
                    else if (AnswerToJoe == 3 && fieldFrenzyQuest.IsComplete == true)
                    {
                        Console.WriteLine("You have completed the quest");
                        //add rewards and exp gained here
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                }
                else if (UserInput == 3)
                {
                    //place function to MOVE here
                    Player1.Location = "Farmer's Field"; //placeholder to test next location
                }
                else if (UserInput == 4)
                {
                    //place function to QUIT here
                    ;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                }
            }
            
            //Start of farmer's field location code
            while (Player1.Location == "Farmer's Field")
            {
                Console.WriteLine($"Current location: {Player1.Location}");
                Console.WriteLine("What would you like to do (Enter a number)?");
                Console.WriteLine("1: Change weapons");
                Console.WriteLine("2: Hunt snakes");
                Console.WriteLine("3: Move");
                Console.WriteLine("4: Quit");
                int UserInput = Convert.ToInt32(Console.ReadLine());
                if (UserInput == 1)
                {
                    Player1.ChangeWeapon();
                }
                if (UserInput == 2)
                {
                    //place function fight here
            
                    fieldFrenzyQuest.IsComplete = true; //after fighting snakes mark quest as completed
                    ;
                }
                if (UserInput == 3)
                {
                    //place function to MOVE here
                    ;
                }
                if (UserInput == 4)
                {
                    //place function to QUIT here
                    ;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                }
            }


        }
            
    }
}
