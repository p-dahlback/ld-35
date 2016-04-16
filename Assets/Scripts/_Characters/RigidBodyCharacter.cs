using UnityEngine;
using System.Collections;

public abstract class RigidBodyCharacter : Character
{
	public Rigidbody2D body;

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

}

