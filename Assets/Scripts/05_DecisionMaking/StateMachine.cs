using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class StateMachine : MonoBehaviour
{
    public IState CurrentState { get; private set; }
    
    public void TransitionTo(IState nextState)
    {
        CurrentState.Exit();
        CurrentState = nextState;
        CurrentState.Enter();
    }

    protected void Initialize(IState initialState)
    {
        CurrentState = initialState;
        CurrentState.Enter();
    }

    protected virtual void Update()
    {
        CurrentState?.Update();
    }
}