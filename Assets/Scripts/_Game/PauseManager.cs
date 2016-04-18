using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PauseManager : MonoBehaviour
{
	private static PauseManager _instance;

	private bool isPaused = false;
	private float timeScale;

	public static PauseManager GetInstance ()
	{
		return _instance;
	}

	void Awake ()
	{
		if (_instance == null) {
			_instance = this;
		} else {
			Destroy (_instance.gameObject);
			_instance = this;
		}
	}

	// Update is called once per frame
	void Update ()
	{
		if (!Debug.isDebugBuild) {
			Destroy (this);
			return;
		}
		
		if (Input.GetKeyDown (KeyCode.P)) {
			if (isPaused) {
				UnPause ();
			} else {
				Pause ();
			}
		}
	}

	private void Pause ()
	{
		timeScale = Time.timeScale;
		Time.timeScale = 0f;
		isPaused = true;
	}

	private void UnPause ()
	{
		Time.timeScale = timeScale;
	}
}

