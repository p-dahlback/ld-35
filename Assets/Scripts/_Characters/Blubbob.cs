using UnityEngine;
using System.Collections;

public class Blubbob : JumpingCharacter
{
	// Config
	public AttackWithCooldown attackManager;

	protected override void Awake ()
	{
		base.Awake ();
		attackManager = GetComponentInChildren<AttackWithCooldown> ();
	}

	public override bool Action2 ()
	{
		// Fire a shift bullet
		if (animator.GetBool (AnimatorConstants.IsGrounded)) {
			return attackManager.Action2 ();
		}
		return false;
	}
}
