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

	protected virtual void Awake ()
	{
	}

	protected virtual void Start ()
	{
	}

	protected virtual void Update ()
	{
	}

	protected virtual void FixedUpdate ()
	{
	}

	public virtual void OnDeath ()
	{
	}
}

