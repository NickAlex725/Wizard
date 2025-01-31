using UnityEngine;

public class Player1State : State
{
    private GameFSM _stateMachine;
    private GameManager _manager;

    private Player _player;

    public Player1State(GameFSM stateMachine, GameManager manager)
    {
        _stateMachine = stateMachine;
        _manager = manager;
    }

    public override void Enter()
    {
        base.Enter();
        _player = _manager.GetPlayer(1);
        _player.EnableInput();
    }

    public override void Exit()
    {
        base.Exit();
        _player.DisableInput();
    }

    public override void FixedTick()
    {
        base.FixedTick();
        if(!_player.IsTurn())
            _stateMachine.ChangeState(_stateMachine.Player2State);
    }

    public override void Tick()
    {
        base.Tick();
    }
}
