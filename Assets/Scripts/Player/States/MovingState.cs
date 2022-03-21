using UnityEngine;

namespace PlayerStates
{
    public class MovingState : AState<PlayerController>
    {
        private float moveSpeed = 10.0f;

        override public void Update()
        {
            if (this.context.IsOutOfBounds())
                this.context.SetState(new ResettingState());
            else if (Input.GetButtonDown("Jump"))
                this.context.SetState(new JumpingState());
            else if (Input.GetAxisRaw("Horizontal") == 0f && Input.GetAxisRaw("Vertical") == 0f)
                this.context.SetState(new IdleState());

            var direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            direction = this.context.transform.InverseTransformDirection(direction);
            this.context.transform.Translate(direction * this.moveSpeed * Time.deltaTime);
        }
    }
}
