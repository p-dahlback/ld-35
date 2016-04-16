using UnityEngine;
using System.Collections;

public abstract class GroundedCharacter : RigidBodyCharacter
{
	public Layer fallThroughLayer;

	private bool isStandingOnPlatform = false;

	public override bool Drop ()
	{
		if (!isStandingOnPlatform) {
			return false;
		}

		StartCoroutine ("FallThroughPlatforms");
		OnLeftGround ();
		return true;
	}

	protected virtual void OnLanded ()
	{
		animator.SetBool (AnimatorConstants.IsGrounded, true);
		if (controller != null) {
			controller.ActWithoutMovement ();
		}
	}

	protected virtual void OnLeftGround ()
	{
		animator.SetBool (AnimatorConstants.IsGrounded, false);
		isStandingOnPlatform = false;
	}

	protected override void FixedUpdate ()
	{
		base.FixedUpdate ();
		if (animator.GetBool (AnimatorConstants.IsGrounded) && body.velocity.y < -0.05) {
			OnLeftGround ();
		}
	}

	protected virtual void OnCollisionStay2D (Collision2D collider)
	{
		if (collider.gameObject.tag == "Floor" && IsBelow (collider)) {
			if (!animator.GetBool (AnimatorConstants.IsGrounded) && Mathf.Abs (body.velocity.y) <= 0.2) {
				OnLanded ();
			}

			if (collider.gameObject.layer == (int) Layer.Platforms) {
				isStandingOnPlatform = true;
			}
		}
	}

	private bool IsBelow (Collision2D collider)
	{
		return collider.transform.position.y < transform.position.y;
	}

	public virtual IEnumerator FallThroughPlatforms ()
	{
		int layer = gameObject.layer;
		gameObject.layer = (int) fallThroughLayer;
		yield return new WaitForSeconds(0.5f);
		gameObject.layer = layer;
	}
}

