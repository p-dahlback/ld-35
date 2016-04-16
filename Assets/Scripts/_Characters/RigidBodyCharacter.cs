using UnityEngine;
using System.Collections;

public abstract class RigidBodyCharacter : Character
{
	// Config
	public Rigidbody2D body;
	public float movementForce = 10.0f;
	public float maxSpeed = 5;

	// Utilities
	private Vector2 tempVelocity = new Vector2 ();

	protected override void Awake ()
	{
		base.Awake ();
		if (body == null) {
			body = GetComponentInParent<Rigidbody2D> ();
		}
	}

	protected override void FixedUpdate ()
	{
		base.FixedUpdate ();

		animator.SetFloat (AnimatorConstants.MovementSpeedX, body.velocity.x);
		animator.SetFloat (AnimatorConstants.MovementSpeedY, body.velocity.y);
		if (body.velocity.x != 0) {
			animator.SetInteger (AnimatorConstants.Facing, (int) Mathf.Sign(body.velocity.x));
		}
	}

	public override void Move (float horizontalThrust, float verticalThrust)
	{
		if (animator.GetBool (AnimatorConstants.CanMove)) {
			body.AddForce (transform.right * horizontalThrust * movementForce);
		}

		if (Mathf.Abs (body.velocity.x) > maxSpeed) {
			tempVelocity.Set (maxSpeed * Mathf.Sign (body.velocity.x), body.velocity.y);
			body.velocity = tempVelocity;
		}
	}
}

