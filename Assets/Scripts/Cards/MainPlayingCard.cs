using UnityEngine;

public class MainPlayingCard : Card
{
    [SerializeField] int value;
    [SerializeField] Vector2 goalPosition;
    private Vector2 startPosition;

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

    private void Start()
    {
        startPosition.y = transform.position.y;
    }

    // Move the card on menu screens.
    void Update()
    {
        float step;
        if (goalPosition.y > 0)
        {
            step = 90 * Time.deltaTime;
        }
        else
        {
            step = -90 * Time.deltaTime;
        }

        transform.position = new Vector2(transform.position.x, startPosition.y);
        startPosition.y += step;

        if (transform.position.y > goalPosition.y && goalPosition.y > 0)
        {
            transform.position = new Vector2(transform.position.x, -200);
            startPosition.y = -200;
        }
        else if (transform.position.y < goalPosition.y && goalPosition.y < 0)
        {
            transform.position = new Vector2(transform.position.x, 600);
            startPosition.y = 600;
        }
    }
}
