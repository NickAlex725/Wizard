using UnityEngine;

public class EndOfTurnState : State
{
    private GameFSM _stateMachine;
    private GameManager _manager;


    public EndOfTurnState(GameFSM stateMachine, GameManager manager)
    {
        _stateMachine = stateMachine;
        _manager = manager;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("winner is: " + _manager.GetWinningCard());
    }

    public override void Exit()
    {
        base.Exit();
        _manager.IncreaseTurnNumber();
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
