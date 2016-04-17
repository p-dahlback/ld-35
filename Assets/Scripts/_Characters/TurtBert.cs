using UnityEngine;
using System.Collections;

public class TurtBert : JumpingCharacter
{
	// Config
	public AttackWithCooldown attackManager;
	public Transform deathReplacement;

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

	public override bool Action2 ()
	{
		// Fire a shift bullet
		return attackManager.Action2 ();
	}

	public override void OnDeath ()
	{
		base.OnDeath ();
		if (deathReplacement != null) {
			Transform replacement = Instantiate (deathReplacement);
			replacement.parent = transform.parent;
			Destroy (gameObject);
		} else if (controller is AiCharacterController) {
			Destroy (controller.gameObject);
		}
	}
}
