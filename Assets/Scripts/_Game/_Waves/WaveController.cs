using UnityEngine;
using System.Collections;

public class WaveController : MonoBehaviour
{
	public EnemySpawner[] spawners;
	public float waveLength = 20;

	private int spawnedEnemyCount = 0;
	private int killedEnemyCount = 0;

	private float currentTime = 0f;
	private float nextWave = 0;
	private int currentWave = 0;

	// Use this for initialization
	void OnEnable ()
	{
		currentTime = 0;
		nextWave = waveLength;
		RunWave ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		currentTime += Time.deltaTime;
		if (currentTime >= nextWave) {
			OnWaveFinished ();
		}
	}

	public void RunWave ()
	{
		currentWave++;
		Debug.Log ("Starting wave " + currentWave);
		GameController.GetInstance ().overlayManager.ShowWaveIndicator (currentWave);
		WaveConfig config = Waves.GetWave (currentWave - 1);
		bool addedSpawns = false;
		int newSpawns = 0;
		for (int i = 0; i < spawners.Length; i++) {
			SpawnConfig[] spawnArray = config.GetSpawns ((WaveConfig.Spawner)i);
			if (spawnArray.Length >= 1) {
				spawners [i].RunSpawns (spawnArray);
				newSpawns += spawners [i].NumberOfSpawnsLeft;
				addedSpawns = true;
			}
		}
		Debug.Assert (addedSpawns, "Started wave, but didn't add any spawns");
		Debug.Log ("Preparing to spawn " + newSpawns);
		spawnedEnemyCount += newSpawns;
	}

	public void OnEnemyKilled ()
	{
		killedEnemyCount++;
		if (spawnedEnemyCount == killedEnemyCount) {
			Debug.Log ("Wave Ended Early!");
			GameController.GetInstance ().overlayManager.ShowWaveEndedEarly ();
			if (nextWave - currentTime > 5f) {
				nextWave = (int)currentTime + 5f;
			}
		}
	}

	void OnWaveFinished ()
	{
		currentTime = 0;
		nextWave = waveLength;
		RunWave ();
	}
}

