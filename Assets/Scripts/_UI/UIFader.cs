using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIFader : MonoBehaviour
{
	public MaskableGraphic graphic;
	public float fadeTime = 1.0f;
	public float targetAlpha = 0.0f;
	public float waitBeforeFade = 0.0f;

	private float startAlpha;

	private float currentTime = 0;
	private bool doWait = false;

	void OnEnable ()
	{
		startAlpha = graphic.color.a;
		currentTime = 0;
		if (waitBeforeFade > 0) {
			doWait = true;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		currentTime += Time.deltaTime;
		if (doWait) {
			if (currentTime >= waitBeforeFade) {
				currentTime -= waitBeforeFade;
				doWait = false;
			} else {
				return;
			}
		}

		Color color = graphic.color;
		float interpolation = Mathf.Min (currentTime / fadeTime, 1.0f);
		color.a = startAlpha + interpolation * (targetAlpha - startAlpha);
		graphic.color = color;

		if (currentTime >= fadeTime) {
			gameObject.SetActive (false);
		}
	}
}

