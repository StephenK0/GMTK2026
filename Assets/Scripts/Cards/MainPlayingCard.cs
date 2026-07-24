using UnityEngine;

public class MainPlayingCard : Card
{
    [SerializeField] int value;

    // Remove the card when the player clicks correctly and trigger a mistake otherwise.
    public void OnMouseDown()
    {
        this.onField = true;  // TODO: remove?

        if (value == CardManager.nextCardToClick)
        {
            CardManager.nextCardToClick -= 1;
            this.Remove();

            if (CardManager.nextCardToClick == 0)
            {
                Debug.Log("Set complete!");
                Game.main.PlayerCompleteSet();
            }
        }
        else
        {
            Game.main.PlayerMistake();
        }
    }
}
