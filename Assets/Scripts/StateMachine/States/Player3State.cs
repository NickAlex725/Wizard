using UnityEngine;

public class Player3State : State
{
    private GameFSM _stateMachine;
    private GameManager _manager;

    private Player _player;
    private PlayerAI _AI;

    public Player3State(GameFSM stateMachine, GameManager manager)
    {
        _stateMachine = stateMachine;
        _manager = manager;
    }

    public override void Enter()
    {
        base.Enter();
        _player = _manager.GetPlayer(3);
        if (_player.IsAI())
        {
            _AI = _player.GetComponent<PlayerAI>();
            _AI.StartAITurn();
        }
        else
        {
            /*this player is not an AI
            could add multiplayer logic here later*/
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedTick()
    {
        base.FixedTick();
        if (_AI != null || !_AI.IsTurn())
        {
            _stateMachine.ChangeState(_stateMachine.Player4State);
        }
    }

    public override void Tick()
    {
        base.Tick();
    }
}