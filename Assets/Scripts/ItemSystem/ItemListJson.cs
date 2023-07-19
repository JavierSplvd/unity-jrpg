using System.Collections.Generic;

[System.Serializable]
public class ItemListJson
{
    public List<Item> Items;

    public ItemListJson(List<Item> items)
    {
        Items = items;
    }
}
