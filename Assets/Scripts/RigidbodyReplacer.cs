using UnityEngine;
using System.Collections;

public class RigidbodyReplacer : MonoBehaviour
{

	Rigidbody2D body;

	void Awake ()
	{
		body = GetComponent<Rigidbody2D> ();
	}

	public void Steal (GameObject other)
	{
		Rigidbody2D otherBody = other.GetComponentInChildren<Rigidbody2D> ();

		if (otherBody != null) {
			DestroyImmediate (body);

			Rigidbody2D newBody = Instantiate (otherBody);
			body = newBody;
		} else {
			Debug.LogAssertion("Expected character to have a rigid body in a child object");
		}
	}
}
