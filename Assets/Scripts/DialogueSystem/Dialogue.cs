[System.Serializable]
public class Dialogue
{
    public string Text;
    public string Id;
    public string NextId;
    public bool IsChoice;
    public string Choice1;
    public string Choice2;
    public string Choice3;
    public string Choice4;
    public string NextForChoice1;
    public string NextForChoice2;
    public string NextForChoice3;
    public string NextForChoice4;
    public string PortraitName;
    public string EventId;

    public Dialogue(string id, string text, string eventId)
    {
        Id = id;
        Text = text;
        EventId = eventId;
    }

    public Dialogue(string id, string text, string nextId, bool isChoice, string choice1, string choice2, string choice3, string choice4, string nextForChoice1, string nextForChoice2, string nextForChoice3, string nextForChoice4, string portraitName, string eventId)
    {
        Id = id;
        Text = text;
        NextId = nextId;
        IsChoice = isChoice;
        Choice1 = choice1;
        Choice2 = choice2;
        Choice3 = choice3;
        Choice4 = choice4;
        NextForChoice1 = nextForChoice1;
        NextForChoice2 = nextForChoice2;
        NextForChoice3 = nextForChoice3;
        NextForChoice4 = nextForChoice4;
        PortraitName = portraitName;
        this.EventId = eventId;
    }
}
