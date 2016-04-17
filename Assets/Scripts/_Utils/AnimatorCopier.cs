using UnityEngine;
using System.Collections;

public class AnimatorCopier
{
	private bool isGrounded = false;
	private bool isJumping = false;
	private bool isAttacking = false;
	private int facing = 1;
	private float movementSpeedX = 0f;
	private float movementSpeedY = 0f;

	public void CopyFrom (Animator animator)
	{
//		isGrounded = animator.GetBool (AnimatorConstants.IsGrounded);
//		isJumping = animator.GetBool (AnimatorConstants.IsJumping);
//		isAttacking = animator.GetBool (AnimatorConstants.IsAttacking);
		facing = animator.GetInteger (AnimatorConstants.Facing);
		movementSpeedX = animator.GetFloat (AnimatorConstants.MovementSpeedX);
		movementSpeedY = animator.GetFloat (AnimatorConstants.MovementSpeedY);
	}

	public void ApplyCopyTo (Animator animator)
	{
//		animator.SetBool (AnimatorConstants.IsGrounded, isGrounded);
//		animator.SetBool (AnimatorConstants.IsJumping, isJumping);
//		animator.SetBool (AnimatorConstants.IsAttacking, isAttacking);
		animator.SetInteger (AnimatorConstants.Facing, facing);
		animator.SetFloat (AnimatorConstants.MovementSpeedX, movementSpeedX);
		animator.SetFloat (AnimatorConstants.MovementSpeedY, movementSpeedY);
	}
}

