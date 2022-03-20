using UnityEngine;

namespace PlayerStates
{
    public class MovingState : AState<PlayerController>
    {
        private Rigidbody rigidBody;

        override public string GetName()
        {
            return "MovingState";
        }

        public override void Start()
        {
            this.rigidBody = this.context.GetComponent<Rigidbody>();
        }

        override public void Update()
        {
            if (Input.GetButtonDown("Jump"))
                this.context.SetState(new JumpingState());
            else if (Input.GetAxisRaw("Horizontal") == 0f && Input.GetAxisRaw("Vertical") == 0f)
                this.context.SetState(new IdleState());

            this.rigidBody.AddForce(new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")) * 1000f * Time.deltaTime);
        }
    }
}