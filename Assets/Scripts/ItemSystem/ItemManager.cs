using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;

public class ItemManager : MonoBehaviour
{
    private static ItemManager instance;
    public static ItemManager Instance => instance;

    private List<Item> items = new List<Item>();

    public event Action<Item> ItemAdded;
    public event Action<Item> ItemRemoved;
    public event Action<Item> ItemModified;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
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

    public Item GetItem(string itemName)
    {
        return items.Find(item => item.Name == itemName);
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
