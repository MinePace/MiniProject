public class Npc
{
    public string Npc_name { get; set; }
    public string Npc_Intro { get; set; }
    public int Npc_id { get; set; }
    public Quest Quest { get; set; }

    public Npc(string npc_name, string npc_intro, int npc_id, Quest quest)
    {
        Npc_name = npc_name;
        Npc_Intro = npc_intro;
        Npc_id = npc_id;
        Quest = quest;
    }
    public void InteractWithNPC()
    {
    // Check if the NPC has a quest
    if (Quest != null)
    {
        if (Quest.IsComplete)
        {
            Console.WriteLine("This quest has already been completed.");
        }
        else if (Quest.isTaskCompelete)
        {
            Console.WriteLine("Completed the quest");
            Quest.IsComplete = true;
            Quest.isAccepted = false;
        }

        else if (Quest.isAccepted)
        {
            Console.WriteLine("Finish the task first");
        }
        else
        {
            Console.WriteLine($"Would you like to accept the quest '{Quest.QuestName}'? (Y/N)");
            string input = Console.ReadLine();
            if (input.ToLower() == "y")
            {
                Console.WriteLine($"You've accepted the quest '{Quest.QuestName}'.");
                // Add the quest to the player's quest log or whatever your game logic dictates
                // For example:
                // player.QuestLog.Add(Quest);
                Quest.isAccepted = true;
            }
            else
            {
                Console.WriteLine("You decide not to accept the quest.");
            }
        }
    }
    else
    {
        Console.WriteLine("This NPC doesn't have any quests for you.");
    }

    }
}