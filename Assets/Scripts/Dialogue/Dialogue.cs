[System.Serializable]
public class Dialogue
{
    public string Text;
    public string Id;
    public string NextId;

    public Dialogue(string id, string text, string nextId)
    {
        Id = id;
        Text = text;
        NextId = nextId;
    }
}
