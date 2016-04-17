using UnityEngine;
using System.Collections;

public class AttackWithCooldown : MonoBehaviour
{
	// Config
	public float attackCooldown = 0.2f;
	public Rigidbody2D body;
	public Animator animator;
	public BulletSpawner bulletSpawner;
	public AudioSource attackSound;


	// State
	private bool didAttack = false;
	private float cooldownTimer;


	void Awake ()
	{
		if (body == null) {
			body = GetComponentInParent<Rigidbody2D> ();
		}
		if (animator == null) {
			animator = GetComponent<Animator> (); 
		}
		if (bulletSpawner == null) {
			bulletSpawner = GetComponentInChildren<BulletSpawner> ();
		}
	}

	void FixedUpdate ()
	{
		if (didAttack) {
			cooldownTimer += Time.fixedDeltaTime;
			if (cooldownTimer >= attackCooldown) {
				cooldownTimer = 0;
				didAttack = false;
			}
		}
	}

	public bool Action2 ()
	{
		// Fire a shift bullet
		if (!didAttack && animator.GetBool (AnimatorConstants.CanAttack) && !animator.GetBool (AnimatorConstants.IsAttacking)) {
			if (bulletSpawner.CanSpawnBullet ()) {
				animator.SetBool (AnimatorConstants.IsAttacking, true);
				bulletSpawner.SpawnBullet (animator.GetInteger (AnimatorConstants.Facing), 1);
				didAttack = true;
				cooldownTimer = 0;

				if (attackSound != null) {
					attackSound.Play ();
				}
			}
		}
		return false;
	}
}

