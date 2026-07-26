using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class ExampleCardCalculator : CardCalculator 
{
	[SerializeField] List<Card> countingCards; //A list of the main cards for counting. 
	[SerializeField] List<Card> distractorsRandom; //The cards that appear off the grid that are distractors. 
	[SerializeField] List<Card> distractorsStiff; //The cards that appear on the grid that are distractors. 
	[SerializeField] List<Card> distractorsFancy; //The cards that appear on the grid that are distractors and also move and/or teleport. 

	[SerializeField] Text guidedInstructions;

	public override void SpawnCards(CardSpawning spawner, int level) {
		List<Card> grid = new List<Card>();
		List<Card> free = new List<Card>();
		
		//Add all counting cards to the grid. 
		foreach(Card card in countingCards) grid.Add(card);

		//If level is high enough, add a few shuffled cards from the grid to the off-grid cards. 
		Util.ShuffleList(grid);
		if(level > 7) {
			free.Add(grid[0]);
			free.Add(grid[1]);
			grid.RemoveAt(1);
			grid.RemoveAt(0);

			// Alter the guidedInstructions.
			guidedInstructions.text = "Keep going!";
	        }

		if(level > 3) {
			Util.ShuffleList(distractorsRandom);
			free.Add(distractorsRandom[0]);
			free.Add(distractorsRandom[1]);

			// Set the card movement speed and start positions.
			CardManager.cardMovementSpeed = 3;
			CardManager.verticalUpperStartPosition = 20;
			CardManager.verticalLowerStartPosition = -20;

			// Alter the guidedInstructions.
			guidedInstructions.text = "Keep counting down. Avoid clicking anything else!";
		}

		if(level > 5) {
			Util.ShuffleList(distractorsStiff);
			grid.Add(distractorsStiff[0]);
			grid.Add(distractorsStiff[1]);

			// Set the card movement speed.
			CardManager.cardMovementSpeed = 5;
		}
		if(level > 8) {
			guidedInstructions.text = "";
		}

		if(level > 9) {
			Util.ShuffleList(distractorsFancy);
			// Set the card movement speed.
			CardManager.cardMovementSpeed = 7;
			free.Add(distractorsFancy[0]);
			free.Add(distractorsFancy[1]);
			free.Add(distractorsFancy[2]);
		}

		if(level > 25) {
			guidedInstructions.text = "HOW";
		}

		spawner.SpawnCards(grid, true);
		spawner.SpawnCards(free, false);
	}
}
