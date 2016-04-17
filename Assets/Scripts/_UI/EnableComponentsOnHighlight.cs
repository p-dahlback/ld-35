using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class EnableComponentsOnHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public MonoBehaviour[] components;

	public void OnPointerEnter (PointerEventData eventData)
	{
		foreach (MonoBehaviour component in components) {
			component.enabled = true;
		}
	}

	public void OnPointerExit (PointerEventData eventData)
	{
		foreach (MonoBehaviour component in components) {
			component.enabled = false;
		}
	}
}
