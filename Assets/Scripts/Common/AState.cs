using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    public void SetContext(AStateContext context);
    public string GetName();
    public void Start();
    public void Update();
}

abstract public class AState<ContextT> : IState where ContextT : AStateContext
{
    protected ContextT context;

    public void SetContext(AStateContext context)
    {
        this.context = context as ContextT;
    }

    abstract public string GetName();

    virtual public void Start()
    {
    }

    virtual public void Update()
    {
    }
}

// Default ContextT value: AStateContext
abstract public class AState : AState<AStateContext>
{
}
