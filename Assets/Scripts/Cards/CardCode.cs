using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        Scene scene = SceneManager.GetActiveScene();
        
        if (scene.name == "Card_Scene"){
            cardArt.sprite = card.cardArt1;
        }
        else if (scene.name == "Second_Scene"){
            cardArt.sprite = card.cardArt2;

        }else
            cardArt.sprite = card.cardArt3;


        cardName.text = card.cardName;

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
