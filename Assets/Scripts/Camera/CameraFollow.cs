using UnityEngine;

public class CameraFollow : AStateContext
{
    [SerializeField] public Camera attachedCamera;
    public readonly Vector3 offset = new Vector3(0f, 2f, -3.5f);

    public void FixCamera(bool IsFixed = true)
    {
        if (IsFixed)
            this.SetState(new CameraFollowStates.FixedState());
        else
            this.SetState(new CameraFollowStates.CatchUpState());
    }

    private void Start()
    {
        this.SetState(new CameraFollowStates.CatchUpState());
    }
}
