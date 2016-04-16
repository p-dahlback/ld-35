using UnityEngine;
using System.Collections;

public class BulletSpawner : MonoBehaviour
{

	public Transform bullet;
	public Vector2 facing = new Vector2 (1, 1);
	public Vector2 velocity;

	public int maxBulletsOnScreen = 10;
	private Transform[] bullets;

	void Awake ()
	{
		bullets = new Transform[maxBulletsOnScreen];
	}

	public bool SpawnBullet (float horizontalFacing, float verticalFacing)
	{
		Transform bullet = GetBullet ();

		if (bullet != null) {
			bullet.gameObject.SetActive (true);
			bullet.position = transform.position;

			Rigidbody2D body = bullet.GetComponent<Rigidbody2D> ();
			body.velocity = new Vector2(velocity.x * facing.x * horizontalFacing, velocity.y * facing.y * verticalFacing);

			SpriteRenderer sprite = bullet.GetComponentInChildren<SpriteRenderer>();
			sprite.flipX = horizontalFacing < 0;
			return true;
		}
		return false;
	}

	public bool CanSpawnBullet () {
		foreach (Transform bullet in bullets) {
			if (bullet == null) {
				return true;
			}
			if (!bullet.gameObject.activeSelf) {
				return true;
			}
		}
		return false;
	}

	private Transform GetBullet ()
	{
		bool create = false;
		int emptyIndex = -1;
		for (int i = 0; i < bullets.Length; i++) {
			if (bullets[i] == null) {
				create = true;
				emptyIndex = i;
				break;
			}

			if (!bullets[i].gameObject.activeSelf) {
				return bullets[i];
			}
		}

		if (create) {
			Transform newBullet = Instantiate (this.bullet);
			bullets[emptyIndex] = newBullet;
			return newBullet;
		} else {
			return null;
		}
	}
}
