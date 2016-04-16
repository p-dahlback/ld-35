using UnityEngine;
using System.Collections;

public class ThiefBullet : Bullet
{
	protected override void OnTriggerEnter2D (Collider2D collider)
	{
		if (IsEnemy (collider)) {
			Character character = collider.gameObject.GetComponent<Character> ();
			if (character != null) {
				GameController.GetInstance ().StealBody (character);
				Destroy (gameObject);
			}
		}
		base.OnTriggerEnter2D (collider);
	}

	private bool IsEnemy (Collider2D collider)
	{
		return collider.gameObject.layer == (int)Layer.Enemy || collider.gameObject.layer == (int)Layer.Enemy;
	}
}

