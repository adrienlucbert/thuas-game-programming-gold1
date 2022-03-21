using UnityEngine;

public class CameraFollow : AStateContext
{
    [SerializeField] public Camera attachedCamera;
    public Vector3 StartOffset
    {
        get;
        private set;
    }

    public void FixCamera(bool IsFixed = true)
    {
        if (IsFixed)
            this.SetState(new CameraFollowStates.FixedState());
        else
            this.SetState(new CameraFollowStates.CatchUpState());
    }

    public Vector3 GetOffset()
    {
        return this.attachedCamera.transform.position - this.transform.position;
    }

    private void Start()
    {
        this.StartOffset = this.GetOffset();
        this.SetState(new CameraFollowStates.FollowState());
    }
}
