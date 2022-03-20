using UnityEngine;

namespace PlayerStates
{
	public class JumpingState : AState<PlayerController>
	{
		override public string GetName()
		{
			return "JumpingState";
		}

		override public void Update()
		{
			if (Input.GetButtonDown("Jump"))
				this.context.SetState(new HoveringState());

		}
	}
}