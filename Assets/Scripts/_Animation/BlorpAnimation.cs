using UnityEngine;
using System.Collections;

public class BlorpAnimation : MonoBehaviour
{
	public Vector2 defaultScale = Vector2.one;
	public Vector2 fullScale = new Vector2 (1.2f, 1.2f);
	public float animationTime = 1.0f;
	public float tension = 0.8f;

	private float currentTime = 0;

	void OnEnable ()
	{
		currentTime = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		currentTime += Time.deltaTime;
		if (currentTime >= animationTime) {
			transform.localScale = defaultScale;
			enabled = false;
		} else {
			float interpolation = InterpolateWithOvershoot (currentTime);
			transform.localScale = new Vector2 (
				defaultScale.x + interpolation * (fullScale.x - defaultScale.x),
				defaultScale.y + interpolation * (fullScale.y - defaultScale.y));
		}
	}

	private float InterpolateWithOvershoot (float t)
	{
		t -= 1.0f;
		return t * t * ((tension + 1) * t + tension) + 1.0f;
	}
}
