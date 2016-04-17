using UnityEngine;
using System.Collections;

public class TriggerSoundAnimationBehaviour  : StateMachineBehaviour
{
	public AudioSource audio;

	override public void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		audio.Play ();
	}
}

