using UnityEngine;

namespace PlayerStates
{
    public class JumpingState : AState<PlayerController>
    {
        private bool isJumping = false;
        private readonly float thrust = 5.0f;

        public JumpingState(bool IsJumping = false)
        {
            this.isJumping = IsJumping;
        }

        override public void Update()
        {
            if (this.context.IsOutOfBounds())
                this.context.SetState(new ResettingState());
            else if (Input.GetButtonDown("Jump"))
                this.context.SetState(new HoveringState());

            if (!this.isJumping)
            {
                this.isJumping = true;
                this.context.GetComponent<Rigidbody>().AddForce(Vector3.up * thrust, ForceMode.Impulse);
            }
        }

        public override void OnCollisionEnter(Collision collision)
        {
            this.context.SetState(new IdleState());
        }
    }
}
