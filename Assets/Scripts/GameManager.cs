using UnityEngine;
using System.Collections.Generic;
using Mono.Cecil.Cil;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<Card> _drawDeck;
    [SerializeField] private Player[] _players;

    private List<Card> _playedCards;
    private int _turnNumber = 1;
    private Card _trumpCard;
    private Card _leadingSuit;
    private Card _currentWinner;

    public void SetUpTurn()
    {
        ShuffleCards();
        DealCards(_turnNumber);
        DetermineTrumpCard();
    }

    public void IncreaseTurnNumber()
    {
        _turnNumber++;
    }

    public Player GetPlayer(int playerNumber)
    {
        return _players[playerNumber-1];
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

    public void CheckForCurrentWinner(Card playedCard)
    {
        if(_currentWinner != null)
        {
            //player has played a trump card, check to see if its the first one
            if(playedCard.GetCardType() == _trumpCard.GetCardType() && _currentWinner.GetCardType() != _trumpCard.GetCardType())
            {
                _currentWinner = playedCard;
            }
            //played has played a trump card and current winner is a trump card, check for higher value
            else if(playedCard.GetCardType() == _trumpCard.GetCardType() && _currentWinner.GetCardType() == _trumpCard.GetCardType())
            {
                //played card has a high value trump card and is current winner
                if(playedCard.GetCardValue() > _currentWinner.GetCardValue())
                {
                    _currentWinner = playedCard;
                }
            }
            //no trump card has been played check for higher value
            else if(playedCard.GetCardType() != _trumpCard.GetCardType() && _currentWinner.GetCardType() != _trumpCard.GetCardType())
            {
                //played card has a high value trump card and is current winner
                if (playedCard.GetCardValue() > _currentWinner.GetCardValue())
                {
                    _currentWinner = playedCard;
                }
            }
        }
        else
        {
            //first card has been played and is the current winner
            _currentWinner = playedCard;
        }
    }

    public Card GetWinningCard()
    {
        for (int i = 0; i < _players.Length; i++)
        {
            //check if wizard is play and make them winner
            if( _players[i].GetCardPlayed().GetCardType() == "Wizard")
            {
                return _players[i].GetCardPlayed();
            }
            CheckForCurrentWinner(_players[i].GetCardPlayed());
        }

        return _currentWinner;
    }
}
