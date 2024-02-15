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
}