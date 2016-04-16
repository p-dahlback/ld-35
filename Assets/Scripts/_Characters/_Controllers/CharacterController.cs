using UnityEngine;
using System.Collections;

public abstract class CharacterController : MonoBehaviour
{
	public Character character;

	public abstract void Act ();

	public abstract void ActWithoutMovement ();
}

