using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : AStateContext
{
    [SerializeField] private PlayerViewModel viewModel;

    override public void SetState(IState value)
    {
        base.SetState(value);
        this.viewModel.StateName = this.State.GetName();
    }

    void Start()
    {
        this.SetState(new PlayerStates.IdleState());
    }

    void Update()
    {
        this.State.Update();
    }
}
