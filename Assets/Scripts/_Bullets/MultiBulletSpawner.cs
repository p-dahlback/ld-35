using UnityEngine;
using System.Collections;

public class MultiBulletSpawner : BulletSpawner
{
	public BulletSpawner[] otherSpawners;

	public override bool SpawnBullet (float horizontalFacing, float verticalFacing)
	{
		bool result = base.SpawnBullet (horizontalFacing, verticalFacing);
		foreach (BulletSpawner other in otherSpawners) {
			result |= other.SpawnBullet (horizontalFacing, verticalFacing);
		}
		return result;
	}
}

