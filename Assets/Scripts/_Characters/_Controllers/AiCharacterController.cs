using UnityEngine;
using System.Collections;

public abstract class AiCharacterController : CharacterController
{
	public override void OnDeath ()
	{
		base.OnDeath ();
		if (gameObject.tag == "Enemy") {
			GameController.GetInstance ().waveController.OnEnemyKilled ();
		}
	}
}

