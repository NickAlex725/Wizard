using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : MonoBehaviour
{
    [SerializeField] GameManager _manager;

    private bool _isTurn = false;
    private Player _self;
    private List<Card> _cardsInHand;
    private Card _cardPlayed;

    private void Awake()
    {
        _self = GetComponent<Player>();
    }

    public void StartAITurn()
    {
        Debug.Log("AI is taking turn");
        /*AI just plays first card in hand for now untill
        AI is fully implemented*/
        _isTurn = true;
        _cardsInHand = _self.GetCardsInHand();
        _cardsInHand[0].PlayCard();
        _cardPlayed = _cardsInHand[0];
        _self.SetCardPlayedFromAI(_cardPlayed);
        _isTurn = false;
    }

    public bool IsTurn()
    {
        return _isTurn;
    }
}
