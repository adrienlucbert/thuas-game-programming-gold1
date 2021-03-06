using UnityEngine;

namespace PlayerStates
{
    public class IdleState : AState<PlayerController>
    {
        override public void Update()
        {
            if (this.context.IsOutOfBounds())
                this.context.SetState(new ResettingState());
            else if (Input.GetButtonDown("Jump"))
                this.context.SetState(new JumpingState());
            else if (Input.GetAxisRaw("Horizontal") != 0f || Input.GetAxisRaw("Vertical") != 0f)
                this.context.SetState(new MovingState());
        }
    }
}
