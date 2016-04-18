using UnityEngine;
using System.Collections;

public class DebugInputController : MonoBehaviour
{
	private GameController gameController;

	// Use this for initialization
	void Start ()
	{
		gameController = GameController.GetInstance ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Debug.isDebugBuild) {
			if (Input.GetKeyDown (KeyCode.Alpha0)) {
				gameController.OnGameOver ();
			} else if (Input.GetKeyDown (KeyCode.Alpha9)) {
				if (gameController.player.IsAlive) {
					gameController.player.character.animator.SetBool (AnimatorConstants.IsDead, true);
					gameController.player.OnDeath ();
				}
			} else if (Input.GetKeyDown (KeyCode.Alpha8)) {
				gameController.waveController.enabled = true;
				gameController.waveController.RunWave ();
			}
		}
	}
}

