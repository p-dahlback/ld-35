using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class UISpriteHighlightBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler
{

	public Image image;
	public Animator animator;
	public float highlightChangeTime = 0.5f;

	public string highlightAnimationTrigger;
	public string selectedAnimationTrigger;

	private bool isSelected = false;
	private float defaultAlpha;
	private float startAlpha;
	private float targetAlpha;
	private float currentTime = 0;

	void Start ()
	{
		defaultAlpha = image.color.a;
		startAlpha = defaultAlpha;
		targetAlpha = startAlpha;
	}

	// Update is called once per frame
	void Update ()
	{
		if (startAlpha != targetAlpha) {
			currentTime += Time.deltaTime;
			Color color = image.color;
			float interpolation = Mathf.Min (currentTime / highlightChangeTime, 1);
			color.a = startAlpha + interpolation * (targetAlpha - startAlpha);
			image.color = color;

			if (currentTime >= highlightChangeTime) {
				startAlpha = targetAlpha;
				currentTime = 0;
			}
		}
	}

	public void OnPointerEnter (PointerEventData eventData)
	{
		startAlpha = defaultAlpha;
		targetAlpha = 1.0f;

		animator.SetBool (highlightAnimationTrigger, true); 
	}

	public void OnPointerExit (PointerEventData eventData)
	{
		if (isSelected)
			return;
		
		targetAlpha = defaultAlpha;
		startAlpha = 1.0f;

		animator.SetBool (highlightAnimationTrigger, false); 
	}

	public void OnSelect (BaseEventData eventData)
	{
		isSelected = true;
		animator.SetBool (selectedAnimationTrigger, true); 
	}
}
