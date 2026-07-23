using UnityEngine;

public class Card : MonoBehaviour
{
	private protected Vector3 away;
	private bool onField = false;

	private void Start() {
		away = new Vector3(-15, 0);
	}

	//Plays the card disappear animation and either destroys or returns to the object pool (if we want to do object pooling). 
	//TODO!!
	public void Remove() {
		if(!onField) Debug.LogError("Attempting to remove card " + gameObject.name + " from the playing field, but it was already removed!");
		transform.position = away;
		onField = false;
	}
	
	public void Spawn(GameObject g) {
		if(onField) Debug.LogError("Attempting to add card " + gameObject.name + " to the playing field, but it was already added!");
		transform.position = g.transform.position;
		transform.rotation = g.transform.rotation;
		onField = true;
	}

	//Spawns the card to a random location on screen, rather than to a specific gameObject. 
	//TODO!!
	public void SpawnRandom() {
		if(onField) Debug.LogError("Attempting to add card " + gameObject.name + " to the playing field, but it was already added!");
		transform.position = Random.insideUnitCircle * 5;
		transform.Rotate(0, 0, Random.Range(-180, 180)); //TODO: Make more reliable!
		onField = true;
	}
}
