using UnityEngine;
using System.Collections;

public class PlayerController : CharacterController
{
	const string InputHorizontalAxis = "Horizontal";
	const string InputVerticalAxis = "Vertical";
	const string InputActionJump = "Fire1";
	const string InputActionAttack = "Fire2";

	private Entity entity;

	private RigidbodyCopier rigidBodyCopier;
	private AnimatorCopier animatorCopier = new AnimatorCopier ();

	public override Character Character {
		get {
			return base.Character;
		}
		set {
			base.Character = value;
			entity = value.GetComponent<Entity> ();
		}
	}

	void Awake ()
	{
		rigidBodyCopier = GetComponent<RigidbodyCopier> ();
	}

	public override void Act ()
	{
		if (character != null && character.isActiveAndEnabled) {
			CheckMove ();

			CheckPerformAction1 ();
			CheckPerformAction2 ();
		}
	}

	public override void ActWithoutMovement ()
	{
		if (character != null && character.isActiveAndEnabled) {
			CheckPerformAction1 ();
			CheckPerformAction2 ();
		}
	}

	public void StealBody (Character body)
	{
		bool hasPreviousBody = Character != null;
		if (hasPreviousBody) {
			animatorCopier.CopyFrom (Character.animator);
			Destroy (Character.gameObject);
		}
		Character = body;

		Rigidbody2D rigidBody2dConfig = Character.GetComponentInChildren<Rigidbody2D> ();
		rigidBodyCopier.Copy (rigidBody2dConfig);
		Destroy (rigidBody2dConfig.gameObject);
		body.gameObject.SetActive (true);

		if (hasPreviousBody) {
			animatorCopier.ApplyCopyTo (body.animator);
		}
			
		entity.invincibility.gameObject.SetActive (true);
	}

	public override void OnDeath ()
	{
		Rigidbody2D body = GetComponent<Rigidbody2D>();
		body.gravityScale = 0;
		base.OnDeath ();
		GameController.GetInstance ().OnDeath ();
	}

	void CheckMove ()
	{
		float horizontalThrust = Input.GetAxis (InputHorizontalAxis);
		float verticalThrust = Input.GetAxis (InputVerticalAxis);
		character.Move (horizontalThrust, verticalThrust);
	}

	void CheckPerformAction1 ()
	{
		if (Input.GetButtonDown (InputActionJump)) {
			bool handled = false;
			if (Input.GetAxis (InputVerticalAxis) < -0.5) {
				handled = character.Drop ();
			}
			if (!handled) {
				character.Action1 ();
			}
		} else if (Input.GetButtonUp (InputActionJump)) {
			character.StopAction1 ();
		}
	}

	void CheckPerformAction2 ()
	{
		if (Input.GetButtonDown (InputActionAttack)) {
			character.Action2 ();
		} else if (Input.GetButtonUp (InputActionAttack)) {
			character.StopAction2 ();
		}
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.gameObject.tag == "Enemy") {
			entity.Damage (1);
		}
	}
}
