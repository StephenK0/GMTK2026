using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayLeaderboard : MonoBehaviour
{
	[SerializeField] List<TMP_Text> leaderboard;
	
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		bool isHighScore = false;
		for(int i = 0; i < leaderboard.Count; i++) {
			if(i >= StaticData.highScores.Count) return;
			leaderboard[i].text += StaticData.highScores[i];
			if(!isHighScore && StaticData.mostRecent == StaticData.highScores[i]) {
				leaderboard[i].text += "[[ New Best! ]]";
				isHighScore = true;
			}
		}
	}
}
