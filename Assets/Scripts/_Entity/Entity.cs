using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour
{
	public int health = 1;
	public int maxHealth = 1;
	public bool isInvincible = false;
	public InvincibilityFlash invincibility;

	private Character character;

	void Awake ()
	{
		character = GetComponent<Character> ();
	}

	public void Damage (int damage)
	{
		if (isInvincible) {
			return;
		}

		health -= damage;
		if (health <= 0) {
			health = 0;
			OnDeath ();
		} else if (invincibility != null) {
			invincibility.gameObject.SetActive(true);
		}
	}

	public virtual void OnDeath ()
	{
		character.OnDeath ();
	}
}

