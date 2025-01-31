using UnityEngine;

public abstract class State
{
    public float StateDuration { get; private set; } = 0;

    //run once state is entered
    public virtual void Enter()
    {
        StateDuration = 0;
    }

    //run once state is ended
    public virtual void Exit()
    {
        
    }

    //for physics
    public virtual void FixedTick()
    {

    }

    //for update
    public virtual void Tick()
    {
        StateDuration += Time.deltaTime;
    }
}