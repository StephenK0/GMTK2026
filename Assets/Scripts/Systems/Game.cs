using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
/*
 * Responsible for the main gameplay loop, such as keeping track of how many sets the player has completed. 
 * TODO!!
 */
public class Game : MonoBehaviour
{
	public static Game main { get; private set; }
	
	int setsCompleted = 0; //The number of sets the player has completed. Used for calculating difficulty and final score. 
	
	float timer; //How long before the game ends, measured in seconds. 
	
	[SerializeField] float timerReset = 100; //How long the game lasts, assuming the player never gets extra time from perfect sets.
	
	[SerializeField] float bonusTime = 5; //How much extra time the player gets for perfectly completing a set. 
	
	[SerializeField] string gameOverScene = "GameOver"; //How much extra time the player gets for perfectly completing a set. 

	bool rewardFlag = true;
	
	//[SerializeField] TMP_Text timerDisplay;
	//[SerializeField] TMP_Text scoreDisplay;
	[SerializeField] TMP_Text display;

	[SerializeField] CardCalculator calculator;
	[SerializeField] CardSpawning spawner;

	private void Start() {
		if(main == null) main = this;
		else Debug.LogError("Duplicate Game " + gameObject.name + " detected!");

		timer = timerReset;
		NewSet();
	}

	private void Update() {
		timer -= Time.deltaTime;
		if(timer <= 0) DoGameOver();
		//timerDisplay.text = "" + Mathf.Floor(timer);
		//scoreDisplay.text = "" + setsCompleted;
		display.text = "" + Mathf.Floor(timer / 60).ToString("00") + ":" + Mathf.Floor(timer) % 60 + "   " + setsCompleted.ToString("000");
	}

	public void PlayerCompleteSet() {
		setsCompleted += 1;
		//CardManager.nextCardToClick = 10;
		
		if(rewardFlag) timer += bonusTime;

		NewSet();

		rewardFlag = true;
	}

	public void PlayerMistake() {
		rewardFlag = false;
    Debug.Log("The player made a mistake...");
	}

	//Starts a new set. 
	private void NewSet() {
		spawner.Reset();
		calculator.SpawnCards(spawner, setsCompleted);
	}

	//TODO!!
	private void DoGameOver() {
		StaticData.AddHighScore(setsCompleted);
        	SceneManager.LoadScene(gameOverScene);
		MainPlayingCard.ResetCount();
	}
}
