using UnityEngine;
using System.Collections;

public class TurtBert : DeathReplacementCharacter
{
	// Config
	public AttackWithCooldown attackManager;

	protected override void Awake ()
	{
		base.Awake ();
		attackManager = GetComponentInChildren<AttackWithCooldown> ();
	}

	protected override void Update ()
	{
		base.Update ();
		animator.SetBool (AnimatorConstants.IsAttacking, false);
	}

	public override bool Action2 ()
	{
		// Fire a shift bullet
		return attackManager.Action2 ();
	}
}
