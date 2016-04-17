using UnityEngine;
using System.Collections;

public class StartScreenRunnerController : MonoBehaviour
{

	public Vector2 speed = Vector2.zero;
	public float variance = 20f;
	public int varianceLevels = 4;
	public int facing = -1;

	private Rigidbody2D body;

	// Use this for initialization
	void Start ()
	{
		body = GetComponent<Rigidbody2D> ();
		Animator animator = GetComponent<Animator> ();
		animator.SetBool ("IsGoTime", true);

		Run ();
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.gameObject.tag == "Wall" && body.velocity.x < 0) {
			TriggerSwitch ();
		} else if (collider.gameObject.tag == "Floor" && body.velocity.x > 0) {
			TriggerSwitch ();
		}
	}

	void TriggerSwitch ()
	{
		body.velocity = Vector2.zero;
		facing = -facing;
		transform.localScale = new Vector2 (-transform.localScale.x, 1);
		StartCoroutine ("RunBack");
	}

	private IEnumerator RunBack ()
	{
		yield return new WaitForSeconds (Random.Range (2, 6));
		Run ();
	}

	private void Run ()
	{
		float diff = variance - (variance * Random.Range (0, varianceLevels - 1) / 2);
		body.velocity = new Vector2 (facing * speed.x + diff, speed.y);
	}
}
