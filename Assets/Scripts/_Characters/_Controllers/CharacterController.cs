using UnityEngine;
using System.Collections;

public abstract class CharacterController : MonoBehaviour
{
	public Character character;

	public virtual Character Character {
		get { return this.character; }
		set { this.character = value; }
	}

	public abstract void Act ();

	public abstract void ActWithoutMovement ();
}

