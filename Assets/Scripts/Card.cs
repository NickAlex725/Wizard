using UnityEngine;

public class Card : MonoBehaviour
{
    
    [SerializeField] private int _cardValue;
    [SerializeField] private string _cardType;

    public void PlayCard()
    {
        Debug.Log("Playing card with a value of " +  _cardValue +
             " and a type of " + _cardType);
        // remove card from players hand
        // animate card to the middle of the table

    }

    public void HoverOverCard()
    {
        //animate the card being lidted to show that you're hovering over it
    }

    public string GetCardType(Card card)
    {
        return _cardType;
    }

    public int GetCardValue(Card card)
    {
        return _cardValue;
    }

}
