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
	    if(!AdvanceCount()) this.Remove();
        }
        else
        {
            Game.main.PlayerMistake();
        }
    }

    //Advances the card counter down by one. Automatically resets if the counter reaches zero. 
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

    public static void ResetCount() {
	    nextCardToClick = 10;
    }
}
