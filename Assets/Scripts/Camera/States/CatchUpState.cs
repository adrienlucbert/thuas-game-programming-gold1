using UnityEngine;

namespace CameraFollowStates
{
    class CatchUpState : AState<CameraFollow>
    {
        private readonly float duration = .5f;
        private float startTime;
        private Vector3 startOffset;

        override public void Enter()
        {
            this.startTime = Time.time;
            this.startOffset = this.context.attachedCamera.transform.position - this.context.transform.position;
        }

        private Vector3 GetOffset()
        {
            float elapsedTime = Time.time - this.startTime;
            if (elapsedTime < this.duration)
            {
                float t = elapsedTime / this.duration;
                t = t * t * (3f - 2f * t);
                Vector3 offset = Vector3.Lerp(this.startOffset, this.context.offset, t);
                return offset;
            }
            else
            {
                this.context.SetState(new FollowState());
                return this.context.offset;
            }
        }

        override public void LateUpdate()
        {
            this.context.attachedCamera.transform.position = this.context.transform.position + this.GetOffset();
        }
    }
}
