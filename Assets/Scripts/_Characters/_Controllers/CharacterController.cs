using UnityEngine;
using System.Collections;

public abstract class CharacterController : MonoBehaviour
{
	public virtual Character character {
		get;
		set;
	}

	public abstract void Act ();

	public abstract void ActWithoutMovement ();
}

