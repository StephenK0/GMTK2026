using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static int nextCardToClick = 10;

    public static int cardMovementSpeed = 90;

    // These shall be modified, since the Main Menu and MainGame scenes involve vertical movement.
    public static int verticalUpperStartPosition = 600;
    public static int verticalLowerStartPosition = -200;

    // These will not be modified, since the Main Menu does not involve horizontal movement.
    public static int horizontalRightStartPosition = 60;
    public static int horizontalLeftStartPosition = -15;
}
