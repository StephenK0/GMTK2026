using UnityEngine;

public class ObstacleCard : Card
{

    public void OnMouseDown()
    {
        // Prevent the player from obtaining the reward.
        Debug.Log("Player mistake...");
        Game.main.PlayerMistake();
    }

    // Remove this card.
    public void RemoveCard()
    {
        this.onField = true;  // TODO: remove eventually?
        this.Remove();
    }
}
