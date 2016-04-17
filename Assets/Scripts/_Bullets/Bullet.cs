using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	public int damage = 1;
	public bool shouldDie = false;

	protected virtual void OnTriggerEnter2D (Collider2D collider)
	{
		Entity entity = collider.gameObject.GetComponent<Entity> ();
		if (entity != null) {
			entity.Damage (damage);
			Destroy (gameObject);
		}
	}

	void OnDisable ()
	{
		if (shouldDie) {
			Destroy (gameObject);
		}
	}
}

