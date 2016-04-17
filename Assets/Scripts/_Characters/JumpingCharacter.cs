using UnityEngine;
using System.Collections;

public abstract class JumpingCharacter : GroundedCharacter
{
	public float jumpSpeed = 10.0f;
	public float jumpLimiterOnButtonRelease = 0.5f;
	public AudioSource jumpSound;

	public override bool Action1 ()
	{
		// Jump
		if (animator.GetBool (AnimatorConstants.CanJump) && animator.GetBool (AnimatorConstants.IsGrounded)) {
			animator.SetBool (AnimatorConstants.IsJumping, true);
			body.velocity = new Vector2 (body.velocity.x, jumpSpeed);
			OnLeftGround ();
			if (jumpSound != null) {
				jumpSound.Play ();
			}
			return true;
		} else {
			return false;
		}
	}

	public override void StopAction1 ()
	{
		// Taper off jump
		if (animator.GetBool (AnimatorConstants.IsJumping)) {
			animator.SetBool (AnimatorConstants.IsJumping, false);
			body.velocity = new Vector2 (body.velocity.x, body.velocity.y * jumpLimiterOnButtonRelease);
		}
	}
}

