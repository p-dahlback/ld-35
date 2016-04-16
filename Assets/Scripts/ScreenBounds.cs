using UnityEngine;
using System.Collections;

public class ScreenBounds : MonoBehaviour 
{
	public float leftConstraint = 0.0f;
	public float rightConstraint = 0.0f;
	public float topConstraint = 0.0f;
	public float bottomConstraint = 0.0f;
	public float buffer = 1.0f; // set this so the object disappears offscreen before re-appearing on other side

	public Transform body;

	void Awake() 
	{
		if (leftConstraint == 0 && rightConstraint == 0) {
			leftConstraint = Camera.main.ScreenToWorldPoint( new Vector3(0.0f, 0.0f, 10) ).x;
			rightConstraint = Camera.main.ScreenToWorldPoint( new Vector3(Screen.width, 0.0f, 10) ).x;
		}

		if (topConstraint == 0 && bottomConstraint == 0) {
			topConstraint = Camera.main.ScreenToWorldPoint( new Vector3(0.0f, 0.0f, 10) ).y;
			bottomConstraint = Camera.main.ScreenToWorldPoint( new Vector3(0.0f, Screen.height, 10) ).y;
		}
	}

	void FixedUpdate() 
	{
		float x = body.position.x;
		float y = body.position.y;
		if (x < leftConstraint - buffer) {
			x = rightConstraint + buffer;
		} else if (x > rightConstraint + buffer) {
			x = leftConstraint - buffer;
		}

		if (y < bottomConstraint - buffer) {
			y = topConstraint + buffer;
		} else if (y > topConstraint + buffer) {
			y = bottomConstraint - buffer;
		}

		body.position = new Vector3(x, y, body.position.z);
//		body.position.Set(x, y, transform.position.z);
	}
}
