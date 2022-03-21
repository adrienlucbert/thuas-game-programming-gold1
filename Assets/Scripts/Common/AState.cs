using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    public void SetContext(AStateContext context);
    public void Enter();
    public void Exit();
    public void Update();
    public void FixedUpdate();
    public void LateUpdate();
    public void OnCollisionEnter(Collision collision);
}

abstract public class AState<ContextT> : IState where ContextT : AStateContext
{
    protected ContextT context;

    public void SetContext(AStateContext context)
    {
        this.context = context as ContextT;
    }

    virtual public void Enter()
    {
    }

    virtual public void Exit()
    {
    }

    virtual public void Update()
    {
    }
    virtual public void FixedUpdate()
    {
    }
    virtual public void LateUpdate()
    {
    }

    virtual public void OnCollisionEnter(Collision collision)
    {
    }
}

// Default ContextT value: AStateContext
abstract public class AState : AState<AStateContext>
{
}
