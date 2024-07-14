using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] Enemy;
    GameObject currentEnemy;
    int currentEnemyCount = 1;
    Animator enemyAnim;

    public GameObject player;
    Animator playerAnim;
    int  PlayerDefence = 0;

    public GameObject gamecamera;
    Animator cameraAnim;

    public CardManager cardAdder;
    public GameObject cardContainer;



    void Start()
    {        
        
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name != "Card_Scene")
            player.GetComponent<Stats>().health = gameStats.Instance.getLife();
        

        currentEnemy = Enemy[0];
        Invoke("gameStart", 0.5f);
        playerAnim = player.GetComponent<Animator>();
        cameraAnim = gamecamera.GetComponent<Animator>();
    }

    void gameStart()
    {
        InvokeRepeating("startCombat", 2.0f, 2.0f);
    }

    public void startCombat()
    {
        playerAnim.SetBool("IsAttacking", true);
        player.GetComponent<Stats>().attack(currentEnemy.GetComponent<Stats>());
        Invoke("setAttcBool", 0.3f);
        if(PlayerDefence <= 0)
        {
            currentEnemy.GetComponent<Stats>().attack(player.GetComponent<Stats>());

            if (player.GetComponent<Stats>().health <= 0)
            {
                CancelInvoke("startCombat");
                playerAnim.SetBool("isDead", true);
                Invoke("muerte", 3.0f);
            }
            else  if(currentEnemy.GetComponent<Stats>().health <= 0)
            {
                secuenciaTrasCombate();
            }
        }
        else 
            PlayerDefence --;

        
    }

    public void CardCombat(Card card)
    {
        switch(card.cardType.ToString()){
            case "Attack":
                playerAnim.SetBool("IsAttacking", true);
                currentEnemy.GetComponent<Stats>().recieveDamage(card.value);
                Invoke("setAttcBool", 0.3f);
                if (currentEnemy.GetComponent<Stats>().health <= 0)
                {
                    secuenciaTrasCombate();
                }
                break;
            case "Defense":
                PlayerDefence ++;
                break;
            case "Heal":
                playerAnim.SetBool("isHealing", true);
                player.GetComponent<Stats>().heal(card.value);
                Invoke("setHealBool", 0.3f);
                break;
            default:
                break;
        }
    }
    
    void setAttcBool()
    {
        playerAnim.SetBool("IsAttacking", false);
    }

    void setHealBool()
    {
        playerAnim.SetBool("isHealing", false);
    }

    void secuenciaTrasCombate(){
        CancelInvoke("startCombat");
        if(currentEnemyCount >= Enemy.Length)
        {
            Destroy(currentEnemy);
            playerAnim.SetBool("endScene", true);
            cameraAnim.SetBool("endScene", true);
            setGameStats();
            Invoke("cambioescene", 3.0f);
        }
        else
        {
            Destroy(currentEnemy);
            Invoke("newEnemy", 0.3f);
        }
    }

    void newEnemy()
    {
        currentEnemy = Enemy[currentEnemyCount];
        currentEnemy.transform.position = new Vector3(0.5f, - 0.37f, -0.4f);
        currentEnemyCount++;
        currentEnemy.GetComponent<Stats>().UpdateHealthBar();
        InvokeRepeating("startCombat", 2.0f, 2.0f);
    }

    void cambioescene()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Card_Scene")
        {
            SceneManager.LoadScene("Second_Scene");
        }
        else if (scene.name == "Second_Scene")
        {
            SceneManager.LoadScene("SalaDelTrono");
        }
        else if (scene.name == "SalaDelTrono")
        {
            SceneManager.LoadScene("Card_Scene");
        }
    }

    void setGameStats()
    {
        int counter = 0;
        List<Card> cards = new List<Card>();
        gameStats.Instance.LifeUpdate(player.GetComponent<Stats>().health);

        foreach (Transform child in cardContainer.transform)
        {
            CardCode component = child.GetComponent<CardCode>();
            if (component != null)
            {
                cards.Add(component.card);
                counter++;
            }
        }

        gameStats.Instance.CardsUpdate(cards.ToArray());
    }

    void muerte()
    {
        SceneManager.LoadScene("Card_Scene");
    }

}

