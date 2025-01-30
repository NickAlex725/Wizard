using UnityEngine;

[RequireComponent(typeof(GameManager))]
public class GameFSM : StateMachineMB
{
    private GameManager _gameManager;

    //state vars here
    public GameSetUpState GameSetUpState { get; private set; }
    public TurnSetUpState TurnSetUpState { get; private set; }
    public Player1State Player1State { get; private set; }
    public Player2State Player2State { get; private set; }
    public Player3State Player3State { get; private set; }
    public Player4State Player4State { get; private set; }
    public EndOfTurnState EndOfTurnState { get; private set; }

    private void Awake()
    {
        _gameManager = GetComponent<GameManager>();
        //state instantiation here
        GameSetUpState = new GameSetUpState(this, _gameManager);
        TurnSetUpState = new TurnSetUpState(this, _gameManager);
        Player1State = new Player1State(this, _gameManager);
        Player2State = new Player2State(this, _gameManager);
        Player3State = new Player3State(this, _gameManager);
        Player4State = new Player4State(this, _gameManager);
        EndOfTurnState = new EndOfTurnState(this, _gameManager);
    }

    private void Start()
    {
        ChangeState(GameSetUpState);
    }

}
