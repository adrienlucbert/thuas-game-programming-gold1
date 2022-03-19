using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateContext
{
    public void SetState(State newState);
}
