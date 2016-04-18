using UnityEngine;
using System.Collections;

public class JumpjetJedController : JumpBumpAiController
{
	// Config
	public float initialAttackThreshold = 3.0f;
	public float initialJumpThreshold = 1.0f;
	public float initialGroundSpeed = 5f;

	// State
	private float initialAttackTimer = 0;
	private float initialJumpTimer = 0;


	protected override void Start ()
	{
		base.Start ();
		int facing = Character.animator.GetInteger (AnimatorConstants.Facing);
		Rigidbody2D body = GetComponent<Rigidbody2D> ();
		Vector2 velocity = body.velocity;
		velocity.x = facing * initialGroundSpeed;
		body.velocity = velocity;
	}

	protected override void Update ()
	{
		base.Update ();
		if (initialAttackTimer < initialAttackThreshold) {
			initialAttackTimer += Time.deltaTime;
		}

		if (initialJumpTimer < initialJumpThreshold) {
			initialJumpTimer += Time.deltaTime;
			if (initialJumpTimer >= initialJumpThreshold) {
				// Block pipes to keep Jed from getting stuck in there.
				passThroughPipes = false;
			}
		}
	}

	public override void ActWithoutMovement ()
	{
		if (initialAttackTimer >= initialAttackThreshold) {
			animator.SetBool (AnimatorConstants.IsAttacking, false);
			character.Action2 ();
		}
		if (initialJumpTimer >= initialJumpThreshold) {
			Jump ();
		}
	}
}

