using UnityEngine;

public class MainPlayingCard : Card
{
    [SerializeField] int value;
    static int nextCardToClick = 10;

    // Remove the card when the player clicks correctly and trigger a mistake otherwise.
    public void OnMouseDown()
    {
        this.onField = true;  // TODO: remove?

        if (value == nextCardToClick)
        {
            //CardManager.nextCardToClick -= 1;

            //if (CardManager.nextCardToClick == 0)
            //{
            //    Debug.Log("Set complete!");
            //}
	    if(!AdvanceCount()) this.Remove();
        }
        else
        {
            Game.main.PlayerMistake();
        }
    }

    static bool AdvanceCount() {
        nextCardToClick--;
        if(nextCardToClick == 0) {
            Game.main.PlayerCompleteSet();
            nextCardToClick = 10;
            Debug.Log("Set complete!");
	    return true;
	}
	return false;
    }

}
