using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class SpawnConfig
{
	public bool randomSpawnIndex = false;
	public int spawnIndex = 0;
	public float delay = 0.0f;

	public static SpawnConfig Spawn (bool randomIndex)
	{
		return Spawn (randomIndex, 0f);
	}

	public static SpawnConfig Spawn (bool randomIndex, float delay)
	{
		return new SpawnConfig{ randomSpawnIndex = randomIndex, delay = delay };
	}

	public static SpawnConfig Spawn (int index)
	{
		return Spawn (index, 0f);
	}

	public static SpawnConfig Spawn (int index, float delay)
	{
		return new SpawnConfig { spawnIndex = index, delay = delay };
	}
}

