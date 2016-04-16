using UnityEngine;
using System.Collections;

public class PlayerController : CharacterController
{
	const string InputHorizontalAxis = "Horizontal";
	const string InputVerticalAxis = "Vertical";
	const string InputAction1 = "Fire1";
	const string InputAction2 = "Fire2";

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
		if (Input.GetButtonDown (InputAction1)) {
			character.Action1 ();
		} else if (Input.GetButtonUp (InputAction1)) {
			character.StopAction1 ();
		}
	}

	void CheckPerformAction2 ()
	{
		if (Input.GetButtonDown (InputAction2)) {
			character.Action2 ();
		} else if (Input.GetButtonUp (InputAction2)) {
			character.StopAction2 ();
		}
	}
}
