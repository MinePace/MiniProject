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
        var w = new World();
    // Check if the NPC has a quest
    if (Quest != null)
    {
        if (Quest.IsComplete)
        {
            w.Text_Display("This quest has already been completed.");
        }
        else if (Quest.isTaskCompelete)
        {
            w.Text_Display("Completed the quest");
            Quest.IsComplete = true;
            Quest.isAccepted = false;
        }

        else if (Quest.isAccepted)
        {
            w.Text_Display("Finish the task first");
        }
        else
        {
            w.Text_Display($"{Quest.Description}");
            w.Text_Display($"Would you like to accept the quest '{Quest.QuestName}'? (Y/N)");
            string input = Console.ReadLine();
            if (input.ToLower() == "y")
            {
                w.Text_Display($"You've accepted the quest '{Quest.QuestName}'.");
                // Add the quest to the player's quest log or whatever your game logic dictates
                // For example:
                // player.QuestLog.Add(Quest);
                Quest.isAccepted = true;
            }
            else
            {
                w.Text_Display("You decide not to accept the quest.");
            }
        }
    }
    else
    {
        w.Text_Display("This NPC doesn't have any quests for you.");
    }

    }
}