using UnityEngine;

public abstract class State
{
    public float StateDuration { get; private set; } = 0;

    //run once state is entered
    public virtual void Enter()
    {
        StateDuration = 0;
        Debug.Log("Now enetering a state");
    }

    //run once state is ended
    public virtual void Exit()
    {
        Debug.Log("Now exiting a state");
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