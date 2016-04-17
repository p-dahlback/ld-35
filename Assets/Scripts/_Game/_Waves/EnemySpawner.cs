using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
	public Vector2 facing = Vector2.left;
	public Vector2 spawnLocation = Vector2.zero;
	public AiCharacterController[] enemies;

	private BlorpAnimation blorp;

	private List<SpawnConfig> spawns;
	private List<SpawnConfig> stoppedSpawns = new List<SpawnConfig> ();
	 
	private bool blocked = false;

	private float currentTime = 0f;

	public int NumberOfSpawnsLeft {
		get {
			int normalCount = spawns != null ? spawns.Count : 0;
			return normalCount + stoppedSpawns.Count;
		}
	}


	// Use this for initialization
	void Start ()
	{	
		blorp = GetComponent<BlorpAnimation> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (NumberOfSpawnsLeft > 0) {
			currentTime += Time.deltaTime;
			if (!CheckSpawnQueue ()) {
				CheckBlockedQueue ();
			}
		}
	}

	private bool CheckSpawnQueue ()
	{
		if (spawns != null) {
			for (int i = 0; i < spawns.Count; i++) {
				if (spawns [i].delay <= currentTime) {
					Spawn (spawns [i]);
					spawns.RemoveAt (i);
					return true;
				}
			}
		}
		return false;
	}

	private void CheckBlockedQueue ()
	{
		for (int i = 0; i < stoppedSpawns.Count; i++) {
			if (spawns [i].delay <= currentTime) {
				Spawn (spawns [i], true);
				spawns.RemoveAt (i);
				break;
			}
		}
	}

	private void Spawn (SpawnConfig config, bool forceSpawn = false)
	{
		if (blocked && !forceSpawn) {
			Debug.Log ("Player blocked a spawn!");
			config.delay += 3f;
			stoppedSpawns.Add (config);
		} else if (config.randomSpawnIndex) {
			SpawnRandom ();
		} else {
			Spawn (config.spawnIndex);
		}
	}

	public void RunSpawns (SpawnConfig[] spawns)
	{
		this.spawns = new List<SpawnConfig> ();
		this.spawns.AddRange (spawns);
		currentTime = 0;
	}

	public void Spawn (int index)
	{
		blorp.enabled = false;

		AiCharacterController controller = Instantiate (enemies [index]);
		controller.transform.position = new Vector2 (transform.position.x + spawnLocation.x, 
			transform.position.y + spawnLocation.y);
		controller.transform.SetParent (GameController.GetInstance ().actorContainer.transform, false);

		controller.Character.animator.SetInteger (AnimatorConstants.Facing, (int)facing.x);

		blorp.enabled = true;
	}

	public void SpawnRandom ()
	{
		Spawn (Random.Range (0, enemies.Length - 1));
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.gameObject.tag == "Player") {
			Debug.Log ("Player entered a tube");
			blocked = true;
		}
	}

	void OnTriggerExit2D (Collider2D collider)
	{
		if (collider.gameObject.tag == "Player") {
			Debug.Log ("Player exited a tube");
			blocked = false;
			if (stoppedSpawns.Count > 0) {
				spawns.AddRange (stoppedSpawns);
			}
		}
	}
}
