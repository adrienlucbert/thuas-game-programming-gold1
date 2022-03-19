using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected IStateContext context;

    public void SetContext(IStateContext context)
    {
        this.context = context;
    }

    abstract public string GetName();

    virtual public void Update()
    {
    }
}
