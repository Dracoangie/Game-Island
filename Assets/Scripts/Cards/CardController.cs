using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    public Card card;
    public Text cardName;
    public Text action;
    public Image cardArt;

    // Start is called before the first frame update
    void Start()
    {
        setCard();
    }

    public void setCard()
    {
        cardName.text = card.cardName;
        cardArt.sprite = card.cardArt;

        switch(card.cardType.ToString()){
            case "Attack":
                action.text = card.attack.ToString();
                break;
            case "Defense":
                action.text = "";
                break;
            case "Effect":
                action.text = card.description;
                break;
            default:
                break;
        }
    }
}
