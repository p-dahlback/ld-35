using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
	private string[][] words = new string[][] {
		new string[] { "MONDO", " HUGE", "\nGAME OVER" },
		new string[] { "GAME", " OVER", "\nMAN" },
		new string[] { "BOOM", " BOOM", " BAM", "\n<i>SLAM</i>" },
		new string[] { "YOU", " ARE", "\nDEAD" },
		new string[] { "<i>THAT</i>", " JUST", "\nHAPPENED" },
		new string[] { "BLAM." }
	};


	public Text gameOverText;
	public Button retryButton;
	public Button quitButton;
	public Text goText;

	public string levelToLoadOnRetry = "Level1";
	public float retryDelay = 2f;
	public float quitDelay = 2f;


	private string[] currentWords;

	// Use this for initialization
	void Start ()
	{
		UIWordSlammer slammer = gameOverText.GetComponent<UIWordSlammer> ();
		slammer.words = words [Random.Range (0, words.Length - 1)];
		StartCoroutine ("DisableActors", 2.5f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void Retry ()
	{
		FadeAwayUI ();

		goText.gameObject.SetActive (true);

		Animator quitAnimator = quitButton.GetComponentInChildren<Animator> ();
		quitAnimator.gameObject.SetActive (false);

		Animator animator = retryButton.GetComponentInChildren<Animator> ();
		animator.transform.SetParent (transform.parent, true);
		animator.SetBool ("IsGoTime", true);

		Rigidbody2D body = animator.gameObject.GetComponent<Rigidbody2D> ();
		body.velocity = new Vector2 (-500, 0);

		GameController.GetInstance ().levelManager.LoadSceneAfterDelay (levelToLoadOnRetry, retryDelay);
	}

	public void Quit ()
	{
		FadeAwayUI ();

		Animator retryAnimator = retryButton.GetComponentInChildren<Animator> ();
		retryAnimator.gameObject.SetActive (false);

		Animator animator = quitButton.GetComponentInChildren<Animator> ();
		animator.transform.SetParent (transform.parent, true);
		animator.SetBool ("IsQuitTime", true);

		Rigidbody2D body = animator.gameObject.GetComponent<Rigidbody2D> ();
		body.gravityScale = 100f;
		body.AddForce (new Vector2 (0, 12000));

		GameController.GetInstance ().levelManager.QuitAfterDelay (quitDelay); 
	}

	private void FadeAwayUI ()
	{
		UIFader retryFader = retryButton.GetComponentInChildren<UIFader> (true);
		UIFader quitFader = quitButton.GetComponentInChildren<UIFader> (true);
		UIFader textFader = gameOverText.GetComponentInChildren<UIFader> (true);

		UISpriteHighlightBehaviour[] highlights = GetComponentsInChildren <UISpriteHighlightBehaviour> ();
		foreach (UISpriteHighlightBehaviour behaviour in highlights) {
			Destroy (behaviour);
		}

		retryFader.targetAlpha = 0f;
		retryFader.fadeTime = 0.3f;
		retryFader.waitBeforeFade = 0f;
		retryFader.gameObject.SetActive (true);

		textFader.gameObject.SetActive (true);

		if (quitFader != null) {
			quitFader.targetAlpha = 0f;
			quitFader.fadeTime = 0.3f;
			quitFader.waitBeforeFade = 0f;
			quitFader.gameObject.SetActive (true);
		}

		retryButton.enabled = false;
		quitButton.enabled = false;
	}

	private IEnumerator DisableActors (float delay)
	{
		yield return new WaitForSeconds (delay);
		GameController.GetInstance ().actorContainer.SetActive (false);
	}
}

