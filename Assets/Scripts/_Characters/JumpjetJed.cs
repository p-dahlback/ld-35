using UnityEngine;
using System.Collections;

public class JumpjetJed : DeathReplacementCharacter
{
	// Config
	public AttackWithCooldown attackManager;

	public float horizontalJumpSpeed = 5f;

	private float directionX = 0f;

	protected override void Awake ()
	{
		base.Awake ();
		attackManager = GetComponentInChildren<AttackWithCooldown> ();
	}

	protected override void FixedUpdate ()
	{
		base.FixedUpdate ();
		animator.SetBool (AnimatorConstants.IsAttacking, false);
	}

	public override void Move (float horizontalThrust, float verticalThrust)
	{
		directionX = horizontalThrust;
	}

	public override bool Action1 ()
	{
		if (base.Action1 ()) {
			Vector2 velocity = body.velocity;
			velocity.x = horizontalJumpSpeed * directionX;
			body.velocity = velocity;
			return true;
		}
		return false;
	}

	public override bool Action2 ()
	{
		// Fire a shift bullet
		return attackManager.Action2 ();
	}
}
