using UnityEngine;
using System.Collections;
using System;

public class TriggerChangeAnimationBehaviour : StateMachineBehaviour
{

	[Serializable]
	public class BoolTriggerDefinition
	{
		public string name;

		public bool enterValue;

		public bool exitValue;
	}

	public BoolTriggerDefinition[] triggers;


	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{

		foreach (BoolTriggerDefinition trigger in triggers) {
			animator.SetBool (trigger.name, trigger.enterValue);
		}
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{

		foreach (BoolTriggerDefinition trigger in triggers) {
			animator.SetBool (trigger.name, trigger.exitValue);
		}
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}

