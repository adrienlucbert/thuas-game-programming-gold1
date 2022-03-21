using UnityEngine;

namespace PlayerStates
{
    public class ResettingState : AState<PlayerController>
    {
        private readonly float duration = 1f;
        private float startTime;
        private Vector3 startPosition;

        public override void Enter()
        {
            this.startTime = Time.time;
            this.startPosition = this.context.transform.position;
        }

        private Vector3 GetPosition()
        {
            float elapsedTime = Time.time - this.startTime;
            if (elapsedTime < this.duration)
            {
                float t = elapsedTime / this.duration;
                t = t * t * (3f - 2f * t);
                return Vector3.Lerp(this.startPosition, this.context.StartPosition, t);
            }
            else
            {
                this.context.SetState(new IdleState());
                return this.context.StartPosition;
            }
        }

        override public void Update()
        {
            this.context.transform.position = this.GetPosition();
        }
    }
}