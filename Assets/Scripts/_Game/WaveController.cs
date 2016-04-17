using UnityEngine;
using System.Collections;

public class WaveController : MonoBehaviour
{
	public EnemySpawner[] spawners;

	private int spawnedEnemyCount = 0;
	private int killedEnemyCount = 0;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void Spawn () {
		
	}

	public void OnEnemyKilled ()
	{
		killedEnemyCount++;
		if (spawnedEnemyCount == killedEnemyCount) {
			OnWaveFinished ();		
		}
	}

	void OnWaveFinished ()
	{
	}
}

