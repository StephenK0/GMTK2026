using UnityEngine;
/*
 * Responsible for the main gameplay loop, such as keeping track of how many rounds the player has completed. 
 */
public class Game : MonoBehaviour
{
	public static Game main { get; private set; }
	
	public void PlayerCompleteSet() {}

	public void PlayerMistake() 
	{
		Debug.Log("The player made a mistake...");
	}
}
