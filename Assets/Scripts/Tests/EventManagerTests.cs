using UnityEngine;
using NUnit.Framework;
using System;

public class EventManagerTests
{
    private bool eventHandled;

    [SetUp]
    public void Setup()
    {
        // Reset the event handled flag before each test
        eventHandled = false;
    }

    [Test]
    public void SubscribeEvent_InvokesEventHandler()
    {
        // Arrange
        EventManager eventManager = new EventManager();
        eventManager.SubscribeEvent("TestEvent", TestEventHandler);

        // Act
        eventManager.InvokeEvent("TestEvent");

        // Assert
        Assert.IsTrue(eventHandled, "Event handler should have been invoked.");
    }

    [Test]
    public void UnsubscribeEvent_RemovesEventHandler()
    {
        // Arrange
        EventManager eventManager = new EventManager();
        eventManager.SubscribeEvent("TestEvent", TestEventHandler);

        // Act
        eventManager.UnsubscribeEvent("TestEvent", TestEventHandler);
        eventManager.InvokeEvent("TestEvent");

        // Assert
        Assert.IsFalse(eventHandled, "Event handler should not have been invoked after unsubscribing.");
    }

    [Test]
    public void InvokeEvent_InvokesMultipleEventHandlers()
    {
        // Arrange
        EventManager eventManager = new EventManager();
        eventManager.SubscribeEvent("TestEvent", TestEventHandler);
        eventManager.SubscribeEvent("TestEvent", AnotherTestEventHandler);

        // Act
        eventManager.InvokeEvent("TestEvent");

        // Assert
        Assert.IsTrue(eventHandled, "Event handlers should have been invoked.");
    }

    private void TestEventHandler()
    {
        eventHandled = true;
    }

    private void AnotherTestEventHandler()
    {
        eventHandled = true;
    }
}
