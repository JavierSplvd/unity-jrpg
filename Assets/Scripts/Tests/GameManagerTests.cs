using NUnit.Framework;
using UnityEngine;

public class GameManagerTests
{
    [Test]
    public void SetAndGetGameState()
    {
        // Arrange
        GameManager gameManager = new GameObject().AddComponent<GameManager>();

        // Act
        gameManager.SetGameState(GameState.Menu);
        GameState currentState = gameManager.GetGameState();

        // Assert
        Assert.AreEqual(GameState.Menu, currentState);
    }
}
