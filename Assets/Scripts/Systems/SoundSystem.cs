using UnityEngine;

public class SoundSystem : MonoBehaviour
{
	public static SoundSystem main { get; private set; }

	[SerializeField] AudioSource sfx;
	[SerializeField] AudioSource music;
	
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		if(main == null) {
			main = this;
			DontDestroyOnLoad(gameObject);
		}
		else Destroy(gameObject);
	}

	public void PlaySoundEffect(AudioClip sound) {
		sfx.clip = sound;
		sfx.Play();
	}
}
