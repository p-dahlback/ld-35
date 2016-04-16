using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private static GameController _instance;

	public PlayerController player;
	public Character defaultBody;


	public static GameController GetInstance ()
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

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	public void StealBody (Character body) {
		player.StealBody (body);
	}
}
