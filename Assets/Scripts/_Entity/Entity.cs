using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour
{
	public int health = 1;
	public int maxHealth = 1;

	public void Damage (int damage)
	{
		health -= damage;
		if (health <= 0) {
			health = 0;
			OnDeath ();
		}
	}

	public virtual void OnDeath ()
	{
	}
}

