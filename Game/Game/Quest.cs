public class Quest
{
    // Properties
    public string Description { get; set; }
    public string QuestName { get; set; }
    public int QuestId { get; set; }
    public bool IsComplete = false;
    public bool isAccepted = false;
    public bool isTaskCompelete = false;

    // Constructor
    public Quest(string description, string questName, int questId)
    {
        Description = description;
        QuestName = questName;
        QuestId = questId;
    }

    
}