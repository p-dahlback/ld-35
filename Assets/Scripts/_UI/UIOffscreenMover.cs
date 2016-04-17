using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIOffscreenMover : MonoBehaviour
{
	public float targetX;
	public float travelTime;
	public float waitTime;
	public RectTransform element;

	private float startX;
	private float finalX;
	private float currentTime = 0;

	// Use this for initialization
	void OnEnable ()
	{
		currentTime = 0;
		startX = -element.rect.width;
		finalX = 800 + element.rect.width;
		Vector2 pos = element.position;
		pos.x = startX;
		element.position = pos;
	}
	
	// Update is called once per frame
	void Update ()
	{
		currentTime += Time.deltaTime;
		float x = 0;
		if (currentTime >= travelTime * 2 + waitTime) {
			OnFinish ();
			return;
		}

		if (currentTime <= travelTime) {
			float interpolation = Mathf.Min (currentTime / travelTime, 1.0f);
			x = startX + interpolation * (targetX - startX);
		} else if (currentTime <= travelTime + waitTime) {
			x = targetX;
		} else {
			float interpolation = Mathf.Min ((currentTime - waitTime - travelTime) / travelTime, 1.0f);
			x = targetX + interpolation * (finalX - targetX);
		} 

		Vector2 pos = element.position;
		pos.x = x;
		element.position = pos;
	}

	void OnFinish ()
	{
		gameObject.SetActive (false);
	}
}
