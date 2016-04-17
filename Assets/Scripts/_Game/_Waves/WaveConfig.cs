using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class WaveConfig
{
	public enum Spawner
	{
		TopLeftSpawner = 0,
		TopRightSpawner = 1,
		BottomRightSpawner = 2,
		BottomLeftSpawner = 3,
	}

	private SpawnConfig[][] spawnMatrix;

	public static WaveConfig Config ()
	{
		return new WaveConfig ();
	}

	public WaveConfig ()
	{
		spawnMatrix = new SpawnConfig[4][];
	}

	public WaveConfig SetSpawns (Spawner spawner, params SpawnConfig[] spawns)
	{
		Debug.Assert (spawnMatrix != null && spawnMatrix.Length > 0, "Cannot set empty spawns. An unset spawner will be empty by default - don't set it manually.");
		spawnMatrix [(int)spawner] = spawns;
		return this;
	}

	public SpawnConfig[] GetSpawns (Spawner spawner)
	{
		Debug.Assert (HasSpawns (), "Wave had no spawns when we tried to get them");
		if (spawnMatrix [(int)spawner] == null)
			return new SpawnConfig[0];
		return spawnMatrix [(int)spawner];
	}

	private bool HasSpawns ()
	{
		foreach (SpawnConfig[] spawnArray in spawnMatrix) {
			if (spawnArray != null && spawnArray.Length > 0)
				return true;
		}
		return false;
	}
}

