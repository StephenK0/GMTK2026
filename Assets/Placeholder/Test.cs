using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Test : MonoBehaviour
{
	[SerializeField] CardSpawning spawner;
	[SerializeField] List<Card> cards;
	int i = 0;
	
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}

	public void AddCardsGrid() {
		spawner.SpawnCards(cards, true);
	}

	public void AddCards() {
		spawner.SpawnCards(cards, false);
	}
	public void AddCardsGridIncremental() {
		List<Card> temp = new List<Card>();
		temp.Add(cards[i]);
		spawner.SpawnCards(temp, true);
		i++; //Note that this will break when you've incrementally added all of the cards once. 
	}
}
