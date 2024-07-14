using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameStats : MonoBehaviour
{
    public static gameStats Instance;

    [SerializeField] private int Playerlife;
    [SerializeField] private Card[] cards;

    private void Awake()
    {
        if(gameStats.Instance == null)
        {
            gameStats.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }

        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Card_Scene")
            gameStats.Instance.CardsUpdate(null);
    }

    public void LifeUpdate(int Life)
    {
        Playerlife = Life;
    }

    public int getLife(){
        return Playerlife;
    }

    public void CardsUpdate(Card[] cardsAux)
    {
        cards = cardsAux;
    }

    public Card[] getCards(){
        return cards;
    }
}
