using UnityEngine;
using System.Collections;

public class HeartBeat : MonoBehaviour {

	public Vector2 defaultScale = Vector2.one;
	public Vector2 fullScale = new Vector2(2, 2);
	public float beatTime = 0.5f;

	private float currentTime = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;
		currentTime %= beatTime;
		float interpolation = currentTime / beatTime;
			
		Vector2 scale = transform.localScale;
		scale.x = defaultScale.x + interpolation * (fullScale.x - defaultScale.x);
		scale.y = defaultScale.y + interpolation * (fullScale.y - defaultScale.y);
		transform.localScale = scale;
	}
}
