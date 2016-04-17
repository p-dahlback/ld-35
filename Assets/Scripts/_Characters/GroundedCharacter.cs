using UnityEngine;
using System.Collections;

public abstract class GroundedCharacter : RigidBodyCharacter
{
	// Config
	public Layer fallThroughLayer;
	public Layer normalLayer;
	public Vector2 dropForceBump = new Vector2(50, 50);

	// State
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
		float xMovement = animator.GetInteger (AnimatorConstants.Facing) * dropForceBump.x;
		float yMovement = dropForceBump.y;
		body.AddForce (new Vector2 (xMovement, yMovement));

		gameObject.layer = (int) fallThroughLayer;
		yield return new WaitForSeconds(0.5f);
		Entity entity = GetComponent<Entity>();
		if (entity != null && !entity.invincibility) {
			Debug.Assert (normalLayer != Layer.Invincible, "Was invincible after it wore off");
		}
		gameObject.layer = (int) normalLayer;
	}
}

