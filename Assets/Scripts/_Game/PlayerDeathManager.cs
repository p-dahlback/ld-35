using UnityEngine;
using System.Collections;

public class PlayerDeathManager : MonoBehaviour
{
	public float deathTimer = 2;
	public PlayerController player;
	public bool respawnWhereYouDied = false;
	public Vector2 respawnPosition = Vector2.zero;

	private float currentTime = 0;

	// Use this for initialization
	void Start ()
	{
		currentTime = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		currentTime += Time.deltaTime;
		if (currentTime >= deathTimer) {
			GameController.GetInstance ().ReturnBody ();
			if (!respawnWhereYouDied) {
				player.transform.position = respawnPosition;
			}
			Destroy (gameObject);
		}
	}
}

