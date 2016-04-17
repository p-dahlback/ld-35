using UnityEngine;
using System.Collections;

public class JumpBumpAiController : TurnOnObstacleAiController
{
	public float jumpCooldown = 2f;
	public float dropChance = 0.3f;

	private bool didJump = false;
	private float timeSinceJump = 0f;

	protected override void Update ()
	{
		base.Update ();
		if (didJump && Character.animator.GetBool (AnimatorConstants.IsGrounded)) {
			didJump = false;
		}
		if (!didJump && timeSinceJump < jumpCooldown) {
			timeSinceJump += Time.deltaTime;
		}
	}

	public override void ActWithoutMovement ()
	{
		Jump ();
	}

	public void Jump ()
	{
		if (timeSinceJump >= jumpCooldown) {
			GroundedCharacter groundedCharacter = (GroundedCharacter)Character;
			if (groundedCharacter.CanDrop () && Random.Range (0, 99) / 100f <= dropChance) {
				groundedCharacter.Drop ();
			} else {
				bool result = Character.Action1 ();
				if (result) {
					didJump = true;
					timeSinceJump = 0;
				}
			}
		}
	}
}

