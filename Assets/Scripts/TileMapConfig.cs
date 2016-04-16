using UnityEngine;
using System.Collections;

public class TileMapConfig : MonoBehaviour {

	public Color tileColor; 

	// Use this for initialization
	void Start () {
		SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
		foreach (SpriteRenderer renderer in sprites) {
			renderer.color = tileColor;
		}
	}

	public void Flash(Color color1, Color color2) {
	// TODO: Flash all tiles in the map!	
	}
}
