using UnityEngine;
using System.Collections;
using System;

public class InvincibilityFlash : MonoBehaviour
{
	public Entity entity;
	public Character character;
	public SpriteRenderer sprite;
	public float invincibilityTime = 2;
	public int flashesPerSecond = 4;
	public float minAlpha = 0.2f;
	public float maxAlpha = 0.8f;

	private int previousLayer = -1;
	private int previousFallthroughLayer = -1;
	private float elapsedTime = 0;

	private bool finished = false;

	void OnEnable ()
	{
		entity.isInvincible = true;
		elapsedTime = 0;

		if (character is GroundedCharacter) {
			GroundedCharacter groundedCharacter = (GroundedCharacter)character;
			previousLayer = (int)groundedCharacter.normalLayer;
			previousFallthroughLayer = (int)groundedCharacter.fallThroughLayer;
			groundedCharacter.normalLayer = Layer.Invincible;
			groundedCharacter.fallThroughLayer = Layer.InvincibleFallThrough;
			if (character.gameObject.layer == previousFallthroughLayer) {
				character.gameObject.layer = (int)Layer.InvincibleFallThrough;
			} else {
				character.gameObject.layer = (int)Layer.Invincible;
			}
		} else {
			previousLayer = character.gameObject.layer;
			character.gameObject.layer = (int)Layer.Invincible;
		}
	}

	void OnDisable ()
	{
		Finish ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		elapsedTime += Time.deltaTime;
		if (elapsedTime >= invincibilityTime) {
			Finish ();
		} else {
			Flash ();
		}
	}

	private void Flash ()
	{
		Color color = sprite.color;
		float interpolation = (float)(Math.Cos ((elapsedTime * flashesPerSecond) * Math.PI * 2) + 1) / 2;
		color.a = minAlpha + interpolation * (maxAlpha - minAlpha);
		sprite.color = color;
	}

	private void Finish ()
	{
		if (finished)
			return;

		finished = true;
		entity.isInvincible = false;
		Color color = sprite.color;
		color.a = 1.0f;
		sprite.color = color;

		if (character is GroundedCharacter) {
			GroundedCharacter groundedCharacter = (GroundedCharacter)character;
			groundedCharacter.normalLayer = (Layer)previousLayer;
			groundedCharacter.fallThroughLayer = (Layer)previousFallthroughLayer;
			if (character.gameObject.layer == (int)Layer.InvincibleFallThrough) {
				character.gameObject.layer = previousFallthroughLayer;
			}
		} else {
			character.gameObject.layer = previousLayer;
		}

		gameObject.SetActive (false);
	}
}

