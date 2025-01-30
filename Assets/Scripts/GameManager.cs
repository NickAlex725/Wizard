using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<Card> _drawDeck;
    [SerializeField] private Player[] _players;

    private int _turnNumber = 1;
    private Card _trumpCard;
    private Card _leadingSuit;

    public void SetUpTurn()
    {
        ShuffleCards();
        DealCards(_turnNumber);
        DetermineTrumpCard();
    }

    private void ShuffleCards()
    {
        //copy to a new temp list
        var tempList = new List<Card>(_drawDeck);
        _drawDeck.Clear();
        //randomly add back the cards to the _drawDeck
        var count = tempList.Count;
        for (int i = 0; i < count; i++)
        {
            var index = Random.Range(0, tempList.Count);
            _drawDeck.Add(tempList[index]);
            tempList.RemoveAt(index);
        }
        tempList.Clear();
    }

    private void DealCards(int numberOfCardsForEachPlayer)
    {
        for (int i = 0; i < numberOfCardsForEachPlayer; i++)
        {
            //add 1 card to each player and remove them from _drawDeck
            for (int j = 0; j < _players.Length; j++)
            {
                _players[j].AddCardToHand(_drawDeck[0]);
                _drawDeck.RemoveAt(0);
            }
        }
    }

    private void DetermineTrumpCard()
    {
        if(_drawDeck.Count > 0)
        {
            //top card in list is trump card
            _trumpCard = _drawDeck[0];
            Instantiate(_trumpCard, new Vector3(0, 0.1f, 0), Quaternion.identity);
        }
        else
        {
            //this is the last turn, there is no trump card
            _trumpCard = null;
            return;
        }
    }
}
