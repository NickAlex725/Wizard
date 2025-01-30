using UnityEngine;

public class TurnSetUpState : State
{
    private GameFSM _stateMachine;
    private GameManager _manager;


    public TurnSetUpState(GameFSM stateMachine, GameManager manager)
    {
        _stateMachine = stateMachine;
        _manager = manager;
    }

    public override void Enter()
    {
        base.Enter();
        _manager.SetUpTurn();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();
    }
}
