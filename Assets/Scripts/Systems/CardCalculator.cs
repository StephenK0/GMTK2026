using UnityEngine;

public abstract class CardCalculator : MonoBehaviour
{
	abstract public void SpawnCards(CardSpawning spawner, int level); 
}
