using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour
{
	public Character prefabForCloning;

	private CharacterController _controller;

	public CharacterController controller {
		set { 
			_controller = value;
			if (_controller != null) {
				_controller.Character = this;
			}
		}
		get { return _controller; }
	}

	public Animator animator;


	public abstract void Move (float horizontalThrust, float verticalThrust);

	public abstract bool Action1 ();

	public abstract bool Action2 ();

	public virtual bool Drop ()
	{
		return false;
	}

	public virtual void StopAction1 ()
	{
	}

	public virtual void StopAction2 ()
	{
	}

	public Character ClonePrefabForParent(Transform parent) {
		Character clone = Instantiate(prefabForCloning);
		clone.transform.parent = parent;
		clone.transform.localPosition = Vector2.zero;
		return clone;
	}

	protected virtual void Awake ()
	{
		if (controller == null) {
			controller = GetComponentInParent<CharacterController> ();
		}

		if (animator == null) {
			animator = GetComponent<Animator> ();
		}
	}

	protected virtual void FixedUpdate ()
	{
		if (controller != null) {
			controller.Act ();
		}
	}
}

