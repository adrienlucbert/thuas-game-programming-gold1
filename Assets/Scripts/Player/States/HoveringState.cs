using UnityEngine;

namespace PlayerStates
{
    public class HoveringState : AState<PlayerController>
    {
        override public string GetName()
        {
            return "HoveringState";
        }

        override public void Update()
        {
            if (Input.GetButtonDown("Jump"))
                this.context.SetState(new IdleState());
        }
    }
}