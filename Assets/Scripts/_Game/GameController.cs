﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

	private static GameController _instance;

	public PlayerController player;
	public Character defaultBody;
	public float shapeShiftTime = 5f;

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
		Character body = Instantiate (defaultBody);
		body.transform.parent = player.transform;
		body.transform.localPosition = Vector2.zero;
		player.StealBody (body);
		shapeShifted = false;
	}
}
