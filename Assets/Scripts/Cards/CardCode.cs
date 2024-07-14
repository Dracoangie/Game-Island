using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CardCode : MonoBehaviour
{
    public Card card;
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
    }

    public void Action()
    {
        gameController.CardCombat(card);
    }
}
