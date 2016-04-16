using UnityEngine;
using System.Collections;

public class TurtBert : JumpingCharacter {
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
		return attackManager.Action2 ();
	}
}
