using UnityEngine;
using System.Collections;

public class Blubbob : GroundedCharacter
{
	public Transform sprite;
	public float speed = 10.0f;
	public float jumpSpeed = 10.0f;
	public float jumpLimiterOnButtonRelease = 0.5f;

	private Vector2 tempVelocity = new Vector2 ();

	public override void Move (float horizontalThrust, float verticalThrust)
	{
		if (animator.GetBool (AnimatorConstants.CanMove)) {
			body.AddForce (transform.right * horizontalThrust * speed);
		}
	}

	public override void Action1 ()
	{
		// Jump
		if (animator.GetBool (AnimatorConstants.CanJump) && animator.GetBool (AnimatorConstants.IsGrounded)) {
			animator.SetBool (AnimatorConstants.IsJumping, true);
			tempVelocity.Set (body.velocity.x, jumpSpeed);
			body.velocity = tempVelocity;
		}
	}

	public override void StopAction1 ()
	{
		// Taper off jump
		if (animator.GetBool (AnimatorConstants.IsJumping)) {
			animator.SetBool (AnimatorConstants.IsJumping, false);
			tempVelocity.Set (body.velocity.x, body.velocity.y * jumpLimiterOnButtonRelease);
			body.velocity = tempVelocity;
		}
	}

	public override void Action2 ()
	{
		// Fire a shift bullet

	}
}
