using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public Card[] cards;
    public Image[] cardevolutions;
    public GameObject cardPrefab;
    public Transform cardContainer;
    public int startCards = 3;

    public GameController gameController;

    void Start()
    {
        AddCard(startCards);
    }

    public void AddCard(int numCards)
    {
        for(int i = 0; i < numCards; i++)
        {
            GameObject newCard = Instantiate(cardPrefab, cardContainer);

            newCard.GetComponent<CardCode>().card = cards[Random.Range(0, cards.Length)];
            newCard.GetComponent<CardCode>().setCard();

            newCard.GetComponent<CardCode>().gameController = gameController;

            if (cardContainer != null)
            {
                newCard.transform.SetParent(cardContainer, false);
            }
        }
        if(gameStats.Instance.getCards() != null){
            
        for(int i = 0; i < gameStats.Instance.getCards().Length ; i++)
        {
            GameObject newCard = Instantiate(cardPrefab, cardContainer);

            newCard.GetComponent<CardCode>().card = gameStats.Instance.getCards()[i];
            newCard.GetComponent<CardCode>().setCard();

            newCard.GetComponent<CardCode>().gameController = gameController;

            if (cardContainer != null)
            {
                newCard.transform.SetParent(cardContainer, false);
            }
        }
        }
    }
}
