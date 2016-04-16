using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	public int damage = 1;

	protected virtual void OnTriggerEnter2D (Collider2D collider)
	{
		Entity entity = collider.gameObject.GetComponent<Entity> ();
		if (entity != null) {
			entity.Damage (damage);
			Destroy (gameObject);
		}
	}
}

