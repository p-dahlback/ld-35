using UnityEngine;
using System.Collections;

public class Blubbob : GroundedCharacter
{
	public Transform sprite;
	public float movementForce = 10.0f;
	public float maxSpeed = 5;
	public float jumpSpeed = 10.0f;
	public float jumpLimiterOnButtonRelease = 0.5f;

	public float attackCooldown = 0.2f;

	private BulletSpawner bulletSpawner;

	private Vector2 tempVelocity = new Vector2 ();
	private bool didAttack = false;
	private float cooldownTimer;


	protected override void Awake ()
	{
		base.Awake ();
		bulletSpawner = GetComponentInChildren<BulletSpawner> ();
	}

	protected override void FixedUpdate ()
	{
		base.FixedUpdate ();
		if (didAttack) {
			cooldownTimer += Time.deltaTime;
			if (cooldownTimer >= attackCooldown) {
				cooldownTimer = 0;
				didAttack = false;
			}
		}
	}

	public override void Move (float horizontalThrust, float verticalThrust)
	{
		if (animator.GetBool (AnimatorConstants.CanMove)) {
			body.AddForce (transform.right * horizontalThrust * movementForce);
		}

		if (Mathf.Abs (body.velocity.x) > maxSpeed) {
			tempVelocity.Set (maxSpeed * Mathf.Sign (body.velocity.x), body.velocity.y);
			body.velocity = tempVelocity;
		}
	}

	public override bool Action1 ()
	{
		// Jump
		if (animator.GetBool (AnimatorConstants.CanJump) && animator.GetBool (AnimatorConstants.IsGrounded)) {
			animator.SetBool (AnimatorConstants.IsJumping, true);
			tempVelocity.Set (body.velocity.x, jumpSpeed);
			body.velocity = tempVelocity;
			OnLeftGround ();
			return true;
		} else {
			return false;
		}
	}

	public override void StopAction1 ()
	{
		// Taper off jump
		if (animator.GetBool (AnimatorConstants.IsJumping)) {
			animator.SetBool (AnimatorConstants.IsJumping, false);
			tempVelocity.Set (body.velocity.x, body.velocity.y * jumpLimiterOnButtonRelease);
			body.velocity = tempVelocity;
		}
	}

	public override bool Action2 ()
	{
		// Fire a shift bullet
		if (!didAttack && animator.GetBool (AnimatorConstants.CanAttack) && !animator.GetBool (AnimatorConstants.IsAttacking)) {
			if (bulletSpawner.CanSpawnBullet ()) {
				animator.SetBool (AnimatorConstants.IsAttacking, true);
				bulletSpawner.SpawnBullet (animator.GetInteger (AnimatorConstants.Facing) , 1);
				didAttack = true;
			}
		}
		return false;
	}

	public override IEnumerator FallThroughPlatforms ()
	{
		float xMovement = animator.GetInteger (AnimatorConstants.Facing) * 50f;
		float yMovement = 50f;
		body.AddForce (new Vector2 (xMovement, yMovement));

		return base.FallThroughPlatforms ();
	}
}
