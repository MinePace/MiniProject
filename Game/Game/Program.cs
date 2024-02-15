using System;
using System.Threading;

public class Program
{
    public static void Main()
    {
        // instancing weapons for monster
        Weapon Goblindagger = new Weapon(1, 30, "Goblin Dagger", 2, 0.2);
        Weapon Zombiesword = new Weapon(2, 20, "Zombie sword", 2, 0.2);
        Weapon Spiderfangs = new Weapon(3, 40, "Spider fangs", 2, 0.2);

        // instancing weapons
        Weapon Spear = new Weapon(101, 30, "Dark Spear", 2, 0.2);
        Weapon Katana = new Weapon(102, 20, "Platinum Katana", 3, 0.15);
        Weapon BroadSword = new Weapon(103, 40, "Iron BroadSword", 1, 0);
        Weapon FarmersScythe = new Weapon(104, 35, "Harvestbane", 2, 0.3);
        
        Weapon TESTING_PURPOSES = new Weapon(999, 100, "TEST SWORD", 4, 1);

        // instancing Potions
        Potion SmallHealthPotion = new Potion("Small Health Potion", "Potion that heals for 50HP", 50, 0);
        Potion BigHealthPotion = new Potion("Big Health Potion", "Potion that heals for 100HP ", 100, 0);

        // instancing MobDrops
        MonsterDrop RottenFlesh = new MonsterDrop("Rotten flesh", "Flesh of a dead zombie", 0);
        MonsterDrop GoblinTeeth = new MonsterDrop("Goblin teeth", "Teeth of a goblin", 2);
        MonsterDrop Spidereye = new MonsterDrop("Spider Eye", "Eye of a spider", 1);

        // instancing Monsters
        Monster Goblin = new Monster(100, 100, 1, Goblindagger, "Goblin", GoblinTeeth, 0.80);
        Monster Zombie = new Monster(100, 100, 2, Zombiesword, "Zombie", RottenFlesh, 0.70);
        Monster Spider = new Monster(100, 100, 3, Spiderfangs, "Spider", Spidereye, 0.30);
         
        // instancing player
        Console.WriteLine("What is your name?:");
        string playername = Console.ReadLine();
        Player Player1 = new Player(100, "Starter area", Katana, playername , SmallHealthPotion, BigHealthPotion);

        //random bog
        SuperAdventure MainBattle = new SuperAdventure(Goblin, Player1);

        // adding stuff to inventory
        Player1.WeaponsInventory.Add(Katana);
        Player1.WeaponsInventory.Add(BroadSword);
        Player1.WeaponsInventory.Add(TESTING_PURPOSES);
        Player1.BigPotionInventory.PotionQuantity += 10;

        Player1.MonsterDropsInventory.Add(GoblinTeeth);
        Player1.MonsterDropsInventory.Add(RottenFlesh);

        // instancing Quests
        Quest fieldFrenzyQuest = new Quest(
            @"Farmer Joe approaches you with a solemn expression, 
explaining his urgent need for help in collecting grain to make bread. 
He warns you of the lurking danger posed by monstrous creatures that 
have been spotted in the fields. Undeterred by the threat, you accept Farmer Joe's plea for aid,
understanding the importance of ensuring the village's food supply. 
Armed with determination and a sense of duty, you set out into the fields, 
ready to face whatever challenges may arise. ",
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

        Player1.ChangeWeapon();
        MainBattle.FightMonster();
        Player1.HP = Player1.Max_hp;
        MainBattle.FightMonster();
        MainBattle.FightMonster();
        MainBattle.FightMonster();
        MainBattle.FightMonster();
        Player1.HP = Player1.Max_hp;
        MainBattle.FightMonster();


        
    }
}
