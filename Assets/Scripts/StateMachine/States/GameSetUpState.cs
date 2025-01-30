using UnityEngine;

public class GameSetUpState : State
{
    private GameFSM _stateMachine;
    private GameManager _manager;


    public GameSetUpState(GameFSM stateMachine, GameManager manager)
    {
        _stateMachine = stateMachine;
        _manager = manager;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedTick()
    {
        base.FixedTick();
        _stateMachine.ChangeState(_stateMachine.TurnSetUpState);
    }

    public override void Tick()
    {
        base.Tick();
    }
}
