using UnityEngine;
using System.Collections;

public class CameraAspectAdjuster : MonoBehaviour
{
	public Camera mainCamera;
	public float targetAspectRatio;

	// Use this for initialization
	void Awake ()
	{
		float windowAspectRatio = (float)Screen.width / (float)Screen.height;
		float scale = windowAspectRatio / targetAspectRatio;

		// if scaled height is less than current height, add letterbox
		if (scale < 1.0f) {  
			Rect rect = mainCamera.rect;

			rect.width = 1.0f;
			rect.height = scale;
			rect.x = 0;
			rect.y = (1.0f - scale) / 2.0f;

			mainCamera.rect = rect;
		} else if (scale > 1.0f) { // add pillarbox
			float scalewidth = 1.0f / scale;

			Rect rect = mainCamera.rect;

			rect.width = scalewidth;
			rect.height = 1.0f;
			rect.x = (1.0f - scalewidth) / 2.0f;
			rect.y = 0;

			mainCamera.rect = rect;
		}
	}
}
