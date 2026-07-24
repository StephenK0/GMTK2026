using UnityEngine;
using System.Collections.Generic;

public class CardSpawning : MonoBehaviour
{
	[SerializeField] List<GameObject> spawnPoints; //The grid that many cards snap to. 
	Queue<GameObject> spawnPointsAvailable; //The available parts of that grid, where new cards can be placed. 
	HashSet<Card> cardsSpawned;


	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Awake()
	{
		spawnPointsAvailable = new Queue<GameObject>();
		cardsSpawned = new HashSet<Card>();
	}
	void Start() {
		Reset();
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}

	public void SpawnCards(List<Card> cards, bool prioritizeGrid) {
		foreach(Card card in cards) {
			if(spawnPointsAvailable.Count == 0) prioritizeGrid = false;
			if(prioritizeGrid) card.Spawn(spawnPointsAvailable.Dequeue());
			else card.SpawnRandom();
			cardsSpawned.Add(card);
		}
	}

	//Removes all cards placed by this CardSpawning. 
	//Also resets spawnPointsAvailable to contain all the spawn points (in a randomized order). 
	public void Reset() {
		//Reset the currently active cards. 
		foreach(Card card in cardsSpawned) {
			card.Remove(); //Plays the animation to remove a card, and then either destroys it or sends it back to the object pool. I'm not sure yet whether we should implement object pooling. 
		}
		cardsSpawned.Clear();
		
		//Reset the available spawnpoints. 
		List<GameObject> temp = spawnPoints;
		Util.ShuffleList(temp);
		spawnPointsAvailable.Clear();
		foreach(GameObject spawnPoint in temp) spawnPointsAvailable.Enqueue(spawnPoint);
	}
}
