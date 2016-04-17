using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	public void LoadSceneAfterDelay (string scene, float delay)
	{
		if (delay > 0) {
			StartCoroutine ("LoadWaitingScene", new object[] { scene, delay });
		} else {
			SceneManager.LoadScene (scene);
		}
	}

	public void QuitAfterDelay (float delay)
	{
		if (delay > 0) {
			StartCoroutine ("QuitApplication", delay);
		} else {
			Application.Quit ();
		}
	}


	private IEnumerator LoadWaitingScene (object[] arguments)
	{
		yield return new WaitForSeconds ((float)arguments [1]);
		SceneManager.LoadScene ((string)arguments [0]);
	}

	private IEnumerator QuitApplication (float delay)
	{
		yield return new WaitForSeconds (delay);
		Application.Quit ();
	}
}

