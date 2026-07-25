using UnityEngine;
using System.Collections;

public class ObstacleCard : Card
{
    [SerializeField] bool isMovingVertically;
    [SerializeField] bool isMovingHorizontally;
    [SerializeField] bool isDisappearing;

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

    // Move the card vertically.
    public void moveVertically()
    {
        float step;
        if (goalPosition.y > 0)
        {
            step = CardManager.cardMovementSpeed * Time.deltaTime;
        }
        else
        {
            step = -1 * CardManager.cardMovementSpeed * Time.deltaTime;
        }

        transform.position = new Vector2(transform.position.x, startPosition.y);
        startPosition.y += step;

        if (transform.position.y > goalPosition.y && goalPosition.y > 0)
        {
            transform.position = new Vector2(transform.position.x, CardManager.verticalLowerStartPosition);
            startPosition.y = CardManager.verticalLowerStartPosition;
        }
        else if (transform.position.y < goalPosition.y && goalPosition.y < 0)
        {
            transform.position = new Vector2(transform.position.x, CardManager.verticalUpperStartPosition);
            startPosition.y = CardManager.verticalUpperStartPosition;
        }
    }

    public void moveHorizontally()
    {
        float step = CardManager.cardMovementSpeed * Time.deltaTime;

        transform.position = new Vector2(startPosition.x, startPosition.y);
        startPosition.x += step;

        if (transform.position.x > goalPosition.x)
        {
            transform.position = new Vector2(CardManager.horizontalLeftStartPosition, startPosition.y);
            startPosition.x = CardManager.horizontalLeftStartPosition;
        }
    }

    public IEnumerator disappear()
    {
        // Wait a couple seconds between removing and respawning a card.
        if (transform.localScale.x > 0)
        {
            this.onField = true;
            this.isDisappearing = false;
            this.Remove();

            yield return new WaitForSecondsRealtime(2);

            this.onField = false;
            this.isDisappearing = true;
            this.SpawnRandom();
        }
    }

    private void Start()
    {
        startPosition.x = transform.position.x;
        startPosition.y = transform.position.y;
    }

    // Move the card on menu screens.
    void Update()
    {
        if (isMovingVertically)
        {
            this.moveVertically();
        }
        else if (isMovingHorizontally)
        {
            this.moveHorizontally();
        }
        else if (isDisappearing)
        {
            StartCoroutine(this.disappear());
        }
    }
}
