using UnityEngine;
using System.Collections;

public class DesktopOnly : MonoBehaviour
{
	void Awake ()
	{
		if (Application.isWebPlayer || Application.isMobilePlatform)
		{
			gameObject.SetActive (false);
		}
	}
}

