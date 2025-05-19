using System;

public class Transition
{
    public IState From { get; private set; }
    public IState To { get; private set; }
    
    public StateMachine StateMachine { get; private set; }
    
    public Func<bool> Condition { get; private set; }
    
    public Transition(IState from, IState to, Func<bool> condition, StateMachine stateMachine)
    {
        From = from;
        To = to;
        Condition = condition;
        StateMachine = stateMachine;
    }

    public void CheckCondition()
    {
        if (StateMachine.CurrentState == From && (Condition?.Invoke() ?? false))
        {
            StateMachine.TransitionTo(To);
        }
    }
}