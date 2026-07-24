using UnityEngine;

public class ObstacleCard : Card
{
    [SerializeField] bool isMoving;
    [SerializeField] Vector2 goalPosition;
    private Vector2 startPosition;

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

    private void Start()
    {
        startPosition.y = transform.position.y;
    }

    // Move the card on menu screens.
    void Update()
    {
        if (isMoving)
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
}
