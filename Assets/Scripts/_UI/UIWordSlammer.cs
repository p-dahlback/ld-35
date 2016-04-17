using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIWordSlammer : MonoBehaviour
{
	
	public Text text;
	public AudioSource slam;
	public string[] words;
	public float slamFirstWait = 0.5f;
	public float slamSeparation = 0.3f;

	private int slamIndex = -1;
	private float currentTime = 0;

	// Use this for initialization
	void Start ()
	{
		text.text = "";
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (slamIndex >= words.Length - 1) {
			Destroy (this);
			return;
		}

		currentTime += Time.deltaTime;
		if (slamIndex == -1) {
			if (currentTime >= slamFirstWait) {
				Slam (words [++slamIndex]);
				currentTime -= slamFirstWait;
			}
		} else if (currentTime >= slamSeparation) {
			Slam (words [++slamIndex]);
			currentTime -= slamSeparation;
		}
	}

	private void Slam (string word)
	{
		text.text += word;
		if (slam != null) {
			slam.Stop ();
			slam.Play ();
		}
	}
}
