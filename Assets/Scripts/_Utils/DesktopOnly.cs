using UnityEngine;
using System.Collections;

public class DesktopOnly : MonoBehaviour
{
	public bool removeInEditor = false;

	void Awake ()
	{
		CheckIsAllowed ();
	}

	void OnEnable ()
	{
		CheckIsAllowed ();
	}

	private void CheckIsAllowed ()
	{
		#if UNITY_WEBGL
			gameObject.SetActive (false);
		#else
		if (Application.isWebPlayer || Application.isMobilePlatform || (Application.isEditor && removeInEditor)) {
			gameObject.SetActive (false);
		}
		#endif
	}
}

