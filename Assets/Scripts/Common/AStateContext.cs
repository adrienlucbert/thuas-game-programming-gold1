using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AStateContext : MonoBehaviour
{
    private IState state;

    protected IState State
    {
        get { return this.state; }
        set { this.SetState(value); }
    }

    virtual public void SetState(IState value)
    {
        this.state = value;
        value.SetContext(this);
        this.state.Start();
    }
}
