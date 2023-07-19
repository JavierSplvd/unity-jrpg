using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;

public class ItemManager : MonoBehaviour
{
    private static ItemManager instance;

    [SerializeField, HideInInspector]
    private List<Item> items = new List<Item>();

    public event Action<Item> ItemAdded;
    public event Action<Item> ItemRemoved;
    public event Action<Item> ItemModified;

    // Getter for the singleton instance
    public static ItemManager Instance
    {
        get
        {
            if (instance == null)
            {
                // Look for an existing ItemManager instance in the scene
                instance = FindObjectOfType<ItemManager>();

                if (instance == null)
                {
                    // Create a new ItemManager object if it doesn't exist
                    GameObject go = new GameObject("ItemManager");
                    instance = go.AddComponent<ItemManager>();
                }
            }

            return instance;
        }
    }

    public void AddItem(Item item)
    {
        items.Add(item);
        ItemAdded?.Invoke(item);
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
        ItemRemoved?.Invoke(item);
    }

    public Item GetItem(ItemType itemType)
    {
        return items.Find(item => item.Type.Equals(itemType));
    }

    public void ModifyItem(Item item)
    {
        ItemModified?.Invoke(item);
    }

    public string SerializeItemsToJson()
    {
        string json = JsonUtility.ToJson(new ItemListJson(items));
        return json;
    }

    public void DeserializeItemsFromJson(string json)
    {
        ItemListJson wrapper = JsonUtility.FromJson<ItemListJson>(json);
        items = wrapper.Items;
    }
}
