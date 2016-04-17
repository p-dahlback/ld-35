using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

	private static GameController _instance;

	public PlayerController player;
	public Character defaultBody;
	public float shapeShiftTime = 10f;
	public int playerLives = 3;

	public Canvas canvas;
	public GameOverManager gameOverManager;
	public PlayerDeathManager playerDeathManager;
	public LevelManager levelManager;

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
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (shapeShifted) {
			shapeShiftTimeSinceSwitch += Time.deltaTime;
			if (shapeShiftTimeSinceSwitch >= shapeShiftTime) {
				ReturnBody ();
			}
		}	

		if (Debug.isDebugBuild) {
			if (Input.GetKeyDown (KeyCode.Alpha0)) {
				OnGameOver ();
			} else if (Input.GetKeyDown (KeyCode.Alpha9)) {
				player.character.animator.SetBool (AnimatorConstants.IsDead, true);
				player.OnDeath ();
			}
		}
	}

	public void OnDeath ()
	{
		if (shapeShifted) {
			ReturnBody ();
		} else if (--currentPlayerLives <= 0) {
			OnGameOver ();
		} else {
			PlayerDeathManager deathManager = Instantiate (playerDeathManager);
			deathManager.player = player;
		}
	}

	public void OnGameOver ()
	{
		GameOverManager manager = Instantiate (this.gameOverManager);
		manager.transform.SetParent (canvas.transform, false);
	}

	public void StealBody (Character body)
	{
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
}
