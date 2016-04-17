using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DoubleEndedProgressController : MonoBehaviour
{
	public HorizontalLayoutGroup group;

	private RectTransform rectTransform;

	// Use this for initialization
	void Start ()
	{
		if (group == null) {
			group = GetComponent<HorizontalLayoutGroup> ();
		}
		rectTransform = group.GetComponent<RectTransform> ();
	}

	public void SetProgress (float progress)
	{
		float fullWidth = rectTransform.rect.width;
		RectOffset offset = new RectOffset (group.padding.left, 
			                    group.padding.right,
			                    group.padding.top,
			                    group.padding.bottom);
		offset.left = (int)((1.0f - progress) * fullWidth / 2);
		offset.right = (int)((1.0f - progress) * fullWidth / 2);
		group.padding = offset;

	}
}
