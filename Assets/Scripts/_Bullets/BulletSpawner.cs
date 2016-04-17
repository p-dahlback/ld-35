using UnityEngine;
using System.Collections;

public class BulletSpawner : MonoBehaviour
{

	public Bullet bullet;
	public Vector2 facing = new Vector2 (1, 1);
	public Vector2 velocity;

	public int maxBulletsOnScreen = 10;
	private Bullet[] bullets;

	void Awake ()
	{
		bullets = new Bullet[maxBulletsOnScreen];
	}

	void OnDestroy ()
	{
		foreach (Bullet bullet in bullets) {
			if (bullet != null) {
				if (bullet.enabled) {
					bullet.shouldDie = true;
				} else {
					Destroy (bullet.gameObject);
				}
			}
		}
	}

	public bool SpawnBullet (float horizontalFacing, float verticalFacing)
	{
		Bullet bullet = GetBullet ();

		if (bullet != null) {
			bullet.gameObject.SetActive (true);
			bullet.transform.position = transform.position;

			Rigidbody2D body = bullet.GetComponent<Rigidbody2D> ();
			body.velocity = new Vector2 (velocity.x * facing.x * horizontalFacing, velocity.y * facing.y * verticalFacing);

			SpriteRenderer sprite = bullet.GetComponentInChildren<SpriteRenderer> ();
			if (sprite != null) {
				sprite.flipX = horizontalFacing < 0;
			}
			return true;
		}
		return false;
	}

	public bool CanSpawnBullet ()
	{
		foreach (Bullet bullet in bullets) {
			if (bullet == null) {
				return true;
			}
			if (!bullet.gameObject.activeSelf) {
				return true;
			}
		}
		return false;
	}

	private Bullet GetBullet ()
	{
		bool create = false;
		int emptyIndex = -1;
		for (int i = 0; i < bullets.Length; i++) {
			if (bullets [i] == null) {
				create = true;
				emptyIndex = i;
				break;
			}

			if (!bullets [i].gameObject.activeSelf) {
				return bullets [i];
			}
		}

		if (create) {
			Bullet newBullet = Instantiate (this.bullet);
			newBullet.gameObject.layer = gameObject.layer;
			newBullet.transform.parent = GameController.GetInstance ().bulletContainer.transform;
			bullets [emptyIndex] = newBullet;
			return newBullet;
		} else {
			return null;
		}
	}
}
