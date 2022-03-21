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
        if (this.state != null)
            this.state.Exit();
        this.state = value;
        value.SetContext(this);
        this.state.Enter();
    }

    virtual protected void Update()
    {
        this.State.Update();
    }

    virtual protected void FixedUpdate()
    {
        this.State.FixedUpdate();
    }

    virtual protected void LateUpdate()
    {
        this.State.LateUpdate();
    }

    private void OnCollisionEnter(Collision collision)
    {
        this.State.OnCollisionEnter(collision);
    }
}
