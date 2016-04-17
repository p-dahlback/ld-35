using UnityEngine;
using System.Collections;

public class StartScreenController : MonoBehaviour
{
	public LevelManager levelManager;
	public GameObject screenFade;

	public void StartGame ()
	{
		levelManager.LoadSceneAfterDelay ("Level1", 2.0f);
		screenFade.SetActive (true);
	}

	public void Quit ()
	{
		Application.Quit ();
	}
}
