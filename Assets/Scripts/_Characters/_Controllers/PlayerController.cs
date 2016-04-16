using UnityEngine;
using System.Collections;

public class PlayerController : CharacterController
{
	const string InputHorizontalAxis = "Horizontal";
	const string InputVerticalAxis = "Vertical";
	const string InputActionJump = "Fire1";
	const string InputActionAttack = "Fire2";

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
}
