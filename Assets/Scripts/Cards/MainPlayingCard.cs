using UnityEngine;

public class MainPlayingCard : Card
{
    [SerializeField] int value;

    // Remove the card when the player clicks correctly and trigger a mistake otherwise.
    public void OnMouseDown()
    {
        this.onField = true;

        if (value == CardManager.nextCardToClick)
        {
            CardManager.nextCardToClick -= 1;
            this.Remove();
        }
        else
        {
            Game.main.PlayerMistake();
        }
    }
}
