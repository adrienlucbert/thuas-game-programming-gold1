namespace CameraFollowStates
{
    class FollowState : AState<CameraFollow>
    {
        override public void LateUpdate()
        {
            this.context.attachedCamera.transform.position = this.context.transform.position + this.context.StartOffset;
        }
    }
}
