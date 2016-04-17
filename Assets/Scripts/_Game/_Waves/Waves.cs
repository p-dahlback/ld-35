using UnityEngine;
using System.Collections;

public class Waves
{
	const int TopLeftSpawner = 0;
	const int TopRightSpawner = 1;
	const int BottomRightSpawner = 2;
	const int BottomLeftSpawner = 3;

	static WaveConfig[] waves;

	static Waves ()
	{
		waves = new WaveConfig[] {
			WaveConfig.Config () // Wave 1
				.SetSpawns (WaveConfig.Spawner.TopLeftSpawner, SpawnConfig.Spawn (0)),
			WaveConfig.Config () // Wave 2
				.SetSpawns (WaveConfig.Spawner.TopLeftSpawner, SpawnConfig.Spawn (0))
				.SetSpawns (WaveConfig.Spawner.BottomRightSpawner, SpawnConfig.Spawn (0)),
			WaveConfig.Config () // Wave 3
				.SetSpawns (WaveConfig.Spawner.BottomLeftSpawner, SpawnConfig.Spawn (1, 5f))
				.SetSpawns (WaveConfig.Spawner.TopRightSpawner, SpawnConfig.Spawn (0)),
			WaveConfig.Config () // Wave 4
				.SetSpawns (WaveConfig.Spawner.BottomRightSpawner, SpawnConfig.Spawn (1))
				.SetSpawns (WaveConfig.Spawner.TopLeftSpawner, SpawnConfig.Spawn (1)),
			WaveConfig.Config () // Wave 5
				.SetSpawns (WaveConfig.Spawner.TopLeftSpawner, SpawnConfig.Spawn (0, 5f))
				.SetSpawns (WaveConfig.Spawner.TopRightSpawner, SpawnConfig.Spawn (0))
				.SetSpawns (WaveConfig.Spawner.BottomLeftSpawner, SpawnConfig.Spawn (0)),
			WaveConfig.Config () // Wave 6
				.SetSpawns (WaveConfig.Spawner.TopLeftSpawner, SpawnConfig.Spawn (1, 5f))
				.SetSpawns (WaveConfig.Spawner.TopRightSpawner, SpawnConfig.Spawn (0))
				.SetSpawns (WaveConfig.Spawner.BottomLeftSpawner, SpawnConfig.Spawn (1))
				.SetSpawns (WaveConfig.Spawner.BottomRightSpawner, SpawnConfig.Spawn (0, 12f)),
			WaveConfig.Config () // Wave 7
				.SetSpawns (WaveConfig.Spawner.BottomRightSpawner, SpawnConfig.Spawn (1))
				.SetSpawns (WaveConfig.Spawner.BottomLeftSpawner, SpawnConfig.Spawn (1, 5f))
				.SetSpawns (WaveConfig.Spawner.TopRightSpawner, SpawnConfig.Spawn (1, 5f)),
			WaveConfig.Config () // Wave 8
				.SetSpawns (WaveConfig.Spawner.TopLeftSpawner, SpawnConfig.Spawn (1, 5f))
				.SetSpawns (WaveConfig.Spawner.TopRightSpawner, SpawnConfig.Spawn (0), SpawnConfig.Spawn(0, 5f))
				.SetSpawns (WaveConfig.Spawner.BottomLeftSpawner, SpawnConfig.Spawn (1))
				.SetSpawns (WaveConfig.Spawner.BottomRightSpawner, SpawnConfig.Spawn (0, 12f)),

		};
	}

	public static WaveConfig GetWave (int index)
	{
		Debug.Assert (index >= 0, "Can't get wave for index " + index);
		
		if (index < waves.Length) {
			Debug.Assert (waves [index] != null, "Wave was null at " + index); 
			return waves [index];
		}
		Debug.Assert (waves [waves.Length - 1] != null, "Wave was null at " + (waves.Length - 1)); 
		return waves [waves.Length - 1];
	}

	public static bool HasMoreWaves (int index)
	{
		return index < waves.Length;
	}
}

