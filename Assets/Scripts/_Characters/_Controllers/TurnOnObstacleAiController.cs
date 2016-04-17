using UnityEngine;
using System.Collections;

public class TurnOnObstacleAiController : AiCharacterController
{
	// Resources
	protected SpriteRenderer sprite;
	protected Animator animator;

	private Vector2 tempVelocity = new Vector2 ();


	public override Character Character {
		get {
			return base.Character;
		}
		set {
			base.Character = value;
			sprite = value.GetComponent<SpriteRenderer> ();
			animator = value.GetComponent<Animator> ();
		}
	}

	protected RigidBodyCharacter RigidBodyCharacter {
		get { return (RigidBodyCharacter) character; }
	}

	public override void Act ()
	{
		Move ();
		ActWithoutMovement ();
	}

	public override void ActWithoutMovement ()
	{
		// Can only move. Override in extending classes
	}

	void OnCollisionEnter2D (Collision2D collider)
	{
		if (IsWall (collider) || IsEnemy (collider)) {
			Rigidbody2D body = RigidBodyCharacter.body;
			tempVelocity.Set (-body.velocity.x, body.velocity.y);
			body.velocity = tempVelocity;
			sprite.flipX = body.velocity.x < 0;
			animator.SetInteger (AnimatorConstants.Facing, (int)Mathf.Sign (body.velocity.x));
		}
	}

	private void Move ()
	{
		tempVelocity.Set (RigidBodyCharacter.maxSpeed * animator.GetInteger (AnimatorConstants.Facing), RigidBodyCharacter.body.velocity.y);
		RigidBodyCharacter.body.velocity = tempVelocity;
	}

	private bool IsWall (Collision2D collider)
	{
		return collider.gameObject.tag == "Wall";
	}

	private bool IsEnemy (Collision2D collider)
	{
		return collider.gameObject.layer == (int) Layer.Enemy || collider.gameObject.layer == (int) Layer.EnemyFallThrough;
	}
}

