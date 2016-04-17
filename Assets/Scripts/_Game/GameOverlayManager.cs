using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverlayManager : MonoBehaviour
{
	public DoubleEndedProgressController shapeShiftProgress;
	public Text timerText;
	public Text lifeText;
	public HeartBeat lifeHeart;

	// Use this for initialization
	void Start ()
	{
		
	}

	void Update ()
	{
		float time = Time.timeSinceLevelLoad;
		UpdateTimer (time);
	}

	public void SetLife (int lives)
	{
		lifeText.text = lives.ToString ();

		Color color = lifeText.color;
		if (lives == 0) {
			color = Color.gray;
			color.a = 0.5f;
			MaskableGraphic graphic = lifeHeart.GetComponent<MaskableGraphic> ();
			graphic.color = Color.gray;
			lifeHeart.transform.localScale = Vector2.one;
			lifeHeart.enabled = false;
		} else {
			color.a = 1.0f;
			lifeHeart.beatTime = 0.5f * ((float) lives / GameController.GetInstance().playerLives);
		}
		lifeText.color = color;
	}

	public void SetShapeShiftProgress (float progress)
	{
		shapeShiftProgress.SetProgress (1.0f - progress);
	}

	public void ShowWaveIndicator (int index) 
	{
	}

	public void ShowWaveEndedEarly ()
	{
	}

	private void UpdateTimer (float seconds)
	{
		float hours = (int)seconds / 3600;
		float minutes = (int)seconds / 60;
		float secondsLeft = seconds - hours * 3600 + minutes * 60;

		if (hours == 0) {
			timerText.text = string.Format ("{0:00}:{1:00}", minutes, secondsLeft);
		} else {
			timerText.text = string.Format ("{0:00}:{1:00}:{2:00}", hours, minutes, secondsLeft);
		}
	}
}
