using UnityEngine;
using System.Collections.Generic;

// Store all static data (data that persists throughout the game, regardless of level).
// Partially based off the class of the same name in our previous game, A Very Serious Racing Spinner. 

public class StaticData 
{
	public static List<int> highScores { get; private set; } //The list of high scores saved. 
	public static int mostRecent { get; private set; } //The value of the most recent score. 
	
	private static int savesLength = 10; //How many scores should be saved in the leaderboard. 
	
	public static void AddHighScore(int score) {
		if(highScores == null) InitializeLeaderboard();
		highScores.Add(score);
		highScores.Sort();
		highScores.Reverse();
		highScores = highScores.GetRange(0, savesLength);
		mostRecent = score;
		Debug.Log("Highscores: ");
		Util.PrintList(highScores);
	}

	static void InitializeLeaderboard() {
		highScores = new List<int>();
		for(int i = 0; i < savesLength; i++) highScores.Add(0);
	}
}


