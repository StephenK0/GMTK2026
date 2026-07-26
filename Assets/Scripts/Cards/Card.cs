using UnityEngine;

/*
 * Note: Currently, with the way animations are implemented, a card is still on screen when removed for a few frames (albeit partially). 
 */
public class Card : MonoBehaviour
{
	private protected Vector3 away;
	private protected bool onField = false;
	int animationTimer = 0;
	const int animationLength = 35;
	Vector3 initialSize;
	
	private DisplayMode currentAnimation;

	private void Start() {
		initialSize = transform.localScale;
		away = new Vector3(-15, 0);
	}
	private void Update() {
		if(currentAnimation == DisplayMode.show) {
			animationTimer++;
			if(animationTimer >= animationLength) currentAnimation = DisplayMode.none;
		}
		else if(currentAnimation == DisplayMode.hide) {
			animationTimer--;
			if(animationTimer <= 0) {
				currentAnimation = DisplayMode.none;
				transform.position = away;
			}
		}
		transform.localScale = new Vector3(initialSize.x * animationTimer / animationLength, initialSize.y, initialSize.z); 

	}

	//Plays the card disappear animation and either destroys or returns to the object pool (if we want to do object pooling). 
	//TODO!!
	public void Remove() {
		if(!onField) Debug.LogError("Attempting to remove card " + gameObject.name + " from the playing field, but it was already removed!");
		onField = false;
		currentAnimation = DisplayMode.hide; 
		animationTimer = 2;
	}
	
	public void Spawn(GameObject g) {
		if(onField) Debug.LogError("Attempting to add card " + gameObject.name + " to the playing field, but it was already added!");
		transform.position = g.transform.position;
		transform.rotation = g.transform.rotation;
		this.onField = true;
		currentAnimation = DisplayMode.show; 
		animationTimer = 0;
	}

	//Spawns the card to a random location on screen, rather than to a specific gameObject. 
	//TODO!!
	public void SpawnRandom() {
		if(onField) Debug.LogError("Attempting to add card " + gameObject.name + " to the playing field, but it was already added!");
		transform.position = Random.insideUnitCircle * 5;
		transform.Rotate(0, 0, Random.Range(-180, 180)); //TODO: Make more reliable!
		this.onField = true;
		currentAnimation = DisplayMode.show; 
		animationTimer = 0;
	}

	private enum DisplayMode {
		none, 
		show, 
		hide
	}
}
