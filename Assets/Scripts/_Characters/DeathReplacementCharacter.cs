using UnityEngine;
using System.Collections;

public abstract class DeathReplacementCharacter : JumpingCharacter
{
	public Transform deathReplacement;

	public override void OnDeath ()
	{
		base.OnDeath ();
		if (deathReplacement != null) {
			Transform replacement = Instantiate (deathReplacement);
			replacement.position = transform.position;
			replacement.parent = transform.parent;
			Destroy (gameObject);
		} else if (controller is AiCharacterController) {
			Destroy (controller.gameObject);
		}
	}
}

