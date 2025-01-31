using UnityEngine;

public class Card : MonoBehaviour
{
    
    [SerializeField] private int _cardValue;
    [SerializeField] private string _cardType;

    public Card(int cardValue, string cardType)
    {
        _cardValue = cardValue;
        _cardType = cardType;
    }

    public void SetValues(int cardValue, string cardType)
    {
        _cardValue = cardValue;
        _cardType = cardType;
    }

    public void PlayCard()
    {
        Debug.Log("Playing card with a value of " +  _cardValue +
             " and a type of " + _cardType);
    }

    public void HoverOverCard()
    {
        //animate the card being lidted to show that you're hovering over it
    }

    public string GetCardType()
    {
        return _cardType;
    }

    public int GetCardValue()
    {
        return _cardValue;
    }

}
