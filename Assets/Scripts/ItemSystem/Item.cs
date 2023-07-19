[System.Serializable]
public class Item
{
    public string Name;
    public ItemType Type;

    // Add more properties as needed for your items

    public Item(string name, ItemType type)
    {
        Name = name;
        Type = type;
    }
}
