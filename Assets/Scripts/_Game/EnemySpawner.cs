using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

	public Vector2 facing = Vector2.left;
	public AiCharacterController[] enemies;

	private BlorpAnimation blorp;

	// Use this for initialization
	void Start ()
	{	
		blorp = GetComponent<BlorpAnimation> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void Spawn (int index)
	{
		blorp.enabled = false;

		AiCharacterController controller = Instantiate (enemies [index]);
		controller.transform.SetParent (GameController.GetInstance ().actorContainer.transform, false);
		controller.transform.position = transform.position;

		controller.Character.animator.SetInteger (AnimatorConstants.Facing, (int)facing.x);

		blorp.enabled = true;
	}

	public void SpawnRandom ()
	{
		Spawn (Random.Range (0, enemies.Length - 1));
	}
}
