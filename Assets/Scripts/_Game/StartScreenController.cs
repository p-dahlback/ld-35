using UnityEngine;
using System.Collections;

public class StartScreenController : MonoBehaviour
{
	public LevelManager levelManager;
	public GameObject screenFade;

	public AudioSource startSound;

	public void StartGame ()
	{
		levelManager.LoadSceneAfterDelay ("Level1", 2.0f);
		screenFade.SetActive (true);

		if (startSound != null) {
			startSound.Play ();
		}
	}

	public void Quit ()
	{
		Application.Quit ();
	}
}
