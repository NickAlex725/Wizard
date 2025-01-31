using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _centerOfHand;
    [SerializeField] private List<Card> _cardsInHand;
    [SerializeField] private bool _isAI;
    [SerializeField] GameManager _manager;

    private int _numberOfCardsInHand;
    private Vector3 _offsetVec;
    private Vector3 _cardSpawnPoint;
    private PlayerInput _input;
    private bool _isTurn = false;
    private Card _cardPlayed;


    private void Awake()
    {
        if (!_isAI)
        {
            _input = GetComponent<PlayerInput>();
            _input.DeactivateInput();
        }
    }

    public void AddCardToHand(Card card)
    {
        _cardsInHand.Add(card);
        _numberOfCardsInHand++;
        /*_offsetVec = new Vector3(1 * _numberOfCardsInHand, 0, 0);
        //_cardSpawnPoint = _centerOfHand.position + _offsetVec;
        Instantiate(card, _cardSpawnPoint, _centerOfHand.rotation);*/
        Instantiate(card, _centerOfHand);
    }

    // input for clicking on a card
    public void OnSelect(InputAction.CallbackContext context)
    {
        if (_isTurn)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                var card = hitInfo.collider.gameObject.GetComponent<Card>();
                if (card != null)
                {
                    //_playedCard = new Card(card.GetCardValue(), card.GetCardType());
                    //_playedCard.SetValues(card.GetCardValue(), card.GetCardType());
                    //Debug.Log(_playedCard);
                    //_playedCard.PlayCard();
                    card.PlayCard();
                    _cardPlayed = card;
                    //_manager.AddCardToPlayedCards(card);
                    _isTurn = false;
                }
            }
        }
    }

    public Card GetCardPlayed()
    {
        return _cardPlayed;
    }

    public void SetCardPlayedFromAI(Card card)
    {
        _cardPlayed = card;
    }

    public List<Card> GetCardsInHand()
    {
        return _cardsInHand;
    }

    public void EnableInput()
    {
        _input.ActivateInput();
        _isTurn = true;
    }

    public void DisableInput()
    {
        _input.DeactivateInput();
    }

    public bool IsTurn()
    {
        return _isTurn;
    }

    public bool IsAI()
    {
        return _isAI;
    }

}
