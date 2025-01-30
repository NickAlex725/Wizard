using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _centerOfHand;
    [SerializeField] private List<Card> _cardsInHand;

    private int _numberOfCardsInHand;
    private Vector3 _offsetVec;
    private Vector3 _cardSpawnPoint;


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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray ,out RaycastHit hitInfo))
        {
            var card = hitInfo.collider.gameObject.GetComponent<Card>();
            //Debug.Log("raycast hit something: " + hitInfo.collider.gameObject);
            if (card != null)
                {
                    card.PlayCard();
                }
        }
    }

}
