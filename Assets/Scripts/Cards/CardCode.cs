using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardCode : MonoBehaviour
{
    public Card card;
    public Text cardName;
    public Text action;
    public Image cardArt;

    public GameController gameController;

    
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
                action.text = card.value.ToString();
                break;
            case "Defense":
                action.text = "";
                break;
            case "Heal":
                action.text = card.value.ToString();
                break;
            default:
                break;
        }
    }

    public void Action()
    {
        gameController.CardCombat(card);
    }
}
