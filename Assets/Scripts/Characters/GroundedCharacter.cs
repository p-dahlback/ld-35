using UnityEngine;
using System.Collections;

public abstract class GroundedCharacter : RigidBodyCharacter
{
	
	protected virtual void OnLanded ()
	{
		Debug.Log ("Landed!");
		animator.SetBool (AnimatorConstants.IsGrounded, true);
	}

	protected virtual void OnBeganToFall ()
	{
		animator.SetBool (AnimatorConstants.IsGrounded, false);
	}

	protected override void FixedUpdate ()
	{
		base.FixedUpdate ();
		if (animator.GetBool (AnimatorConstants.IsGrounded) && body.velocity.y < -0.05) {
			OnBeganToFall ();
		}
	}

	protected virtual void OnCollisionStay2D (Collision2D collider)
	{
		if (collider.gameObject.tag == "Floor" && IsBelow (collider)) {
			if (!animator.GetBool (AnimatorConstants.IsGrounded) && Mathf.Abs (body.velocity.y) <= 0.05) {
				OnLanded ();
			}
		}
	}

	private bool IsBelow(Collision2D collider) {
		return collider.transform.position.y < transform.position.y;
	}
}

