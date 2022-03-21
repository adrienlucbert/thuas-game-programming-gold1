using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : AStateContext
{
    [SerializeField] private PlayerViewModel viewModel;
    private float minY = -10f; // minimum Y coordinate before resetting player position
    public Vector3 StartPosition
    {
        get;
        private set;
    }

    override public void SetState(IState value)
    {
        base.SetState(value);
        this.viewModel.StateName = this.State.GetType().Name;
    }

    private void Start()
    {
        this.StartPosition = this.transform.position;
        this.SetState(new PlayerStates.IdleState());
    }

    public bool IsOutOfBounds()
    {
        return this.transform.position.y < this.minY;
    }
}
