using UnityEngine;
using System.Collections;

public class TurtBertController : TurnOnObstacleAiController
{
	// Config
	public float initialAttackThreshold = 2.0f;

	// State
	private float initialAttackTimer = 0;

	private TurtBert TurtBert {
		get { return (TurtBert)character; }
	}

	void Update ()
	{
		if (initialAttackTimer < initialAttackThreshold) {
			initialAttackTimer += Time.deltaTime;
		}
	}

	public override void ActWithoutMovement ()
	{
		if (initialAttackTimer >= initialAttackThreshold) {
			animator.SetBool (AnimatorConstants.IsAttacking, false);
			character.Action2 ();
		}
	}
}
