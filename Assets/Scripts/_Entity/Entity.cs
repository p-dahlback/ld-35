using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour
{
	public int health = 1;
	public int maxHealth = 1;
	public bool isInvincible = false;
	public InvincibilityFlash invincibility;
	public AudioSource damageSound;
	public AudioSource deathSound;

	private Character character;

	void Awake ()
	{
		character = GetComponent<Character> ();
	}

	public void Damage (int damage)
	{
		if (health <= 0) {
			return;
		}

		if (isInvincible) {
			return;
		}

		health -= damage;
		bool playedSound = false;
		if (damage > 0) {
			if (health <= 0) {
				if (deathSound != null) {
					deathSound.Play ();
					playedSound = true;
				}
				health = 0;
				OnDeath ();
			} else if (invincibility != null) {
				invincibility.gameObject.SetActive (true);
			}

			if (!playedSound && damageSound != null) {
				damageSound.Play ();
			}
		}
	}

	public virtual void OnDeath ()
	{
		character.OnDeath ();
	}
}

