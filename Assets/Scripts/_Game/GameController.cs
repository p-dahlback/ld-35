using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

	private static GameController _instance;

	public PlayerController player;
	public Character defaultBody;
	public float shapeShiftTime = 10f;
	public int playerLives = 3;
	public float firstWaveDelay = 5.0f;

	public Canvas canvas;
	public GameOverlayManager overlayManager;
	public WaveController waveController;
	public GameOverManager gameOverManager;
	public PlayerDeathManager playerDeathManager;
	public LevelManager levelManager;
	public GameObject actorContainer;
	public GameObject bulletContainer;

	private int currentPlayerLives = 0;

	private bool shapeShifted = false;
	private float shapeShiftTimeSinceSwitch = 0;

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
	void Start ()
	{
		currentPlayerLives = playerLives;
		overlayManager.SetShapeShiftProgress (1.0f);

		StartCoroutine ("StartWavesWithDelay", firstWaveDelay);
	}
		
	// Update is called once per frame
	void Update ()
	{
		if (shapeShifted) {
			shapeShiftTimeSinceSwitch += Time.deltaTime;
			overlayManager.SetShapeShiftProgress (Mathf.Min (shapeShiftTimeSinceSwitch / shapeShiftTime, 1.0f));
			if (shapeShiftTimeSinceSwitch >= shapeShiftTime) {
				ReturnBody ();
			}
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
	}

	public void OnDeath ()
	{
		if (shapeShifted) {
			overlayManager.SetShapeShiftProgress (1.0f);
			ReturnBody ();
		} else { 
			if (--currentPlayerLives <= 0) {
				OnGameOver ();
			} else {
				PlayerDeathManager deathManager = Instantiate (playerDeathManager);
				deathManager.player = player;
			}
			overlayManager.SetLife (currentPlayerLives);
		}
	}

	public void OnGameOver ()
	{
		waveController.enabled = false;

		GameOverManager manager = Instantiate (this.gameOverManager);
		manager.transform.SetParent (canvas.transform, false);
	}

	public void StealBody (Character body)
	{
		if (!player.IsAlive) {
			// Can't steal a body while respawning or game over'd
			Debug.Log ("Ignoring body snatching; player is dead!");
			return;
		}

		Character newBody = body.ClonePrefabForParent (player.transform);
		player.StealBody (newBody);
		shapeShifted = true;
		shapeShiftTimeSinceSwitch = 0;
	}

	public void ReturnBody ()
	{
		shapeShifted = false;
		Character body = Instantiate (defaultBody);
		body.transform.parent = player.transform;
		body.transform.localPosition = Vector2.zero;
		player.StealBody (body);
	}

	private IEnumerator StartWavesWithDelay (float delay)
	{
		yield return new WaitForSeconds (delay);
		Debug.Log ("Enabling waves");
		waveController.enabled = true;
	}
}
