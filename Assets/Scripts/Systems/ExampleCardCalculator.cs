using UnityEngine;
using System.Collections.Generic;

public class ExampleCardCalculator : CardCalculator 
{
	[SerializeField] List<Card> countingCards; //A list of the main cards for counting. 
	[SerializeField] List<Card> distractorsRandom; //The cards that appear off the grid that are distractors. 
	[SerializeField] List<Card> distractorsStiff; //The cards that appear on the grid that are distractors. 
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

			// Set the card movement speed.
			CardManager.cardMovementSpeed = 7;
		}

		if(level > 3) {
			Util.ShuffleList(distractorsRandom);
			free.Add(distractorsRandom[0]);
			free.Add(distractorsRandom[1]);

			// Set the card movement speed and start positions.
			CardManager.cardMovementSpeed = 3;
			CardManager.verticalUpperStartPosition = 20;
			CardManager.verticalLowerStartPosition = -20;
		}

		if(level > 5) {
			Util.ShuffleList(distractorsStiff);
			grid.Add(distractorsStiff[0]);
			grid.Add(distractorsStiff[1]);

			// Set the card movement speed.
			CardManager.cardMovementSpeed = 5;
		}

		spawner.SpawnCards(grid, true);
		spawner.SpawnCards(free, false);
	}
}
