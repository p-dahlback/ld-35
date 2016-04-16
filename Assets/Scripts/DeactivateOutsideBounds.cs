using UnityEngine;
using System.Collections;

public class DeactivateOutsideBounds : MonoBehaviour
{
	public float leftConstraint = 0.0f;
	public float rightConstraint = 0.0f;
	public float topConstraint = 0.0f;
	public float bottomConstraint = 0.0f;


	void Awake ()
	{
		if (leftConstraint == 0 && rightConstraint == 0) {
			leftConstraint = Camera.main.ScreenToWorldPoint (new Vector3 (0.0f, 0.0f, 10)).x;
			rightConstraint = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, 0.0f, 10)).x;
		}

		if (topConstraint == 0 && bottomConstraint == 0) {
			topConstraint = Camera.main.ScreenToWorldPoint (new Vector3 (0.0f, 0.0f, 10)).y;
			bottomConstraint = Camera.main.ScreenToWorldPoint (new Vector3 (0.0f, Screen.height, 10)).y;
		}
	}

	void FixedUpdate ()
	{
		if (transform.position.x < leftConstraint
		    || transform.position.x > rightConstraint
		    || transform.position.y < bottomConstraint
		    || transform.position.y > topConstraint) {
			gameObject.SetActive (false);
		}
	}
}
