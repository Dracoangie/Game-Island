using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public Card[] cards;
    public GameObject cardPrefab;
    public Transform cardContainer;

    void Start()
    {
        AddCard(2);
    }

    public void AddCard(int numCards)
    {
        for(int i = 0; i < numCards; i++)
        {
            GameObject newCard = Instantiate(cardPrefab, cardContainer);

            newCard.GetComponent<CardController>().card = cards[Random.Range(0, cards.Length)];
            newCard.GetComponent<CardController>().setCard();

            if (cardContainer != null)
            {
                newCard.transform.SetParent(cardContainer, false);
            }
        }
    }
}
