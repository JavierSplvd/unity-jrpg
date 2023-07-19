using System;

[System.Serializable]
public class Item
{
    public ItemType Type;

    // Add more properties as needed for your items

    public Item(ItemType type)
    {
        Type = type;
    }
}
