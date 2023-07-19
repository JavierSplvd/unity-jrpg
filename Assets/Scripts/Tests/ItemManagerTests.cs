using UnityEngine;
using NUnit.Framework;
using System.Collections.Generic;

public class ItemManagerTests
{
    private ItemManager itemManager;

    [SetUp]
    public void SetUp()
    {
        // Create a new ItemManager instance for each test
        GameObject itemManagerGO = new GameObject();
        itemManager = itemManagerGO.AddComponent<ItemManager>();
    }

    [TearDown]
    public void TearDown()
    {
        // Clean up after each test
        Object.DestroyImmediate(itemManager.gameObject);
    }

    [Test]
    public void TestAddItem()
    {
        Item item = new Item("Health Potion", ItemType.Potion);
        itemManager.AddItem(item);

        Assert.IsTrue(itemManager.GetItem("Health Potion") != null);
    }

    [Test]
    public void TestRemoveItem()
    {
        Item item = new Item("Health Potion", ItemType.Potion);
        itemManager.AddItem(item);

        itemManager.RemoveItem(item);

        Assert.IsTrue(itemManager.GetItem("Health Potion") == null);
    }

    [Test]
    public void TestSerialization()
    {
        Item item1 = new Item("Health Potion", ItemType.Potion);
        Item item2 = new Item("Fire Sword", ItemType.Sword);
        itemManager.AddItem(item1);
        itemManager.AddItem(item2);

        string json = itemManager.SerializeItemsToJson();

        // Clear the current items to ensure deserialization works properly
        itemManager.RemoveItem(item1);
        itemManager.RemoveItem(item2);

        itemManager.DeserializeItemsFromJson(json);

        Assert.IsTrue(itemManager.GetItem("Health Potion") != null);
        Assert.IsTrue(itemManager.GetItem("Fire Sword") != null);
    }
}
