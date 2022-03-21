using UnityEngine;

namespace PlayerStates
{
    public class HoveringState : AState<PlayerController>
    {
        private float elapsedTime = 0f;
        private readonly float hoverAmplitude = .25f; // oscillations amplitude
        private readonly float hoverSpeed = 7; // oscillations per second
        private readonly float rotationSpeed = 100f; // hovering rotation speed
        private Vector3 startPosition;
        private CameraFollow cameraFollow;

        public override void Enter()
        {
            this.context.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.context.GetComponent<Rigidbody>().useGravity = false;
            this.startPosition = this.context.transform.position;
            this.cameraFollow = this.context.GetComponent<CameraFollow>();
            this.cameraFollow.FixCamera();
        }

        public override void Exit()
        {
            this.context.GetComponent<Rigidbody>().useGravity = true;
            this.cameraFollow.FixCamera(false);
        }

        override public void Update()
        {
            if (Input.GetButtonDown("Jump"))
                this.context.SetState(new JumpingState(true));

            this.elapsedTime += Time.deltaTime;
            var offset = new Vector3(0f, Mathf.Sin(this.elapsedTime * this.hoverSpeed), 0f) * this.hoverAmplitude;
            this.context.transform.position = this.startPosition + offset;
            this.context.transform.Rotate(new Vector3(0f, this.rotationSpeed * Time.deltaTime, 0f));
        }

        public override void OnCollisionEnter(Collision collision)
        {
            this.context.SetState(new IdleState());
        }
    }
}
