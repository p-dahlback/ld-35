using UnityEngine;
using System.Collections;

public class RigidbodyCopier : MonoBehaviour
{

	Rigidbody2D body;

	void Awake ()
	{
		body = GetComponent<Rigidbody2D> ();
	}

	public void Copy (Rigidbody2D otherBody)
	{
		if (otherBody != null) {
			body.useAutoMass = otherBody.useAutoMass;
			body.mass = otherBody.mass;
			body.centerOfMass = otherBody.centerOfMass;
			body.drag = otherBody.drag;
			body.angularDrag = otherBody.angularDrag;
			body.gravityScale = otherBody.gravityScale;
			body.isKinematic = otherBody.isKinematic;
			body.interpolation = otherBody.interpolation;
			body.sleepMode = otherBody.sleepMode;
			body.collisionDetectionMode = otherBody.collisionDetectionMode;
			body.constraints = otherBody.constraints;
		} else {
			Debug.LogAssertion ("Expected character to have a rigid body in a child object");
		}
	}
}
