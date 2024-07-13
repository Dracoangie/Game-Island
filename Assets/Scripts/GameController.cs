using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] firstPhaseEnemies = new GameObject[3];
    public GameObject currentEnemy;
    public int maxEnemyHealth = 15;
    public int maxEnemyDamage = 2;
    public int nextEnemyHealthDifference=3;
    public int nextEnemyDamageDifference=1;
    public GameObject player;
    public Transform spawnPoint;
    public GameObject gamecamera;
    public CardManager cardAdder;
    public GameObject currentPlayer;
    public GameObject player2;
    bool PlayerDefence = false;

    void Start()
    {
        InvokeRepeating("startCombat", 2.0f, 2.0f);
    }

    
    void Update()
    {
        
    }

  public void startCombat()
    {
        Debug.Log(PlayerDefence);
        player.GetComponent<Stats>().attack(currentEnemy.GetComponent<Stats>());
        if(!PlayerDefence)
        {
            currentEnemy.GetComponent<Stats>().attack(player.GetComponent<Stats>());

            if (currentEnemy.GetComponent<Stats>().health <= 0)
            {
                CancelInvoke("startCombat");
                Destroy(currentEnemy);
                Invoke("MovePlayer", 2.0f);
                Invoke("SpawnNewEnemy", 4.0f);
            }
        }
        else 
            PlayerDefence = false;
    }

    public void CardCombat(Card card)
    {
        switch(card.cardType.ToString()){
            case "Attack":
                player.GetComponent<Stats>().attack(card.value);

                if (currentEnemy.GetComponent<Stats>().health <= 0)
                {
                    CancelInvoke("startCombat");
                    Invoke("MovePlayer", 2.0f);
                    Invoke("SpawnNewEnemy", 4.0f);
                }
                break;
            case "Defense":
                PlayerDefence = true;
                break;
            case "Heal":
                player.GetComponent<Stats>().heal(card.value);
                break;
            default:
                break;
        }
    }

    void MovePlayer()
    {
        Debug.Log("Moving the character to the right");
       Rigidbody2D rb2d = currentPlayer.GetComponent<Rigidbody2D>();
       
        if (rb2d != null)
        {
            
            rb2d.velocity = new Vector2(2.0f, rb2d.velocity.y);
        }
        else
        {
            
            currentPlayer.transform.Translate(Vector3.right * 2.0f * Time.deltaTime);

        }
        Invoke("DestroyPlayer",2.0f);
        Invoke("changeCurrentPlayer",3.0f);
        Invoke("moveCamera",2.0f);
        StartCoroutine("MoveAndHandleNext");

    }

    void DestroyPlayer(){
        Debug.Log("Destroying the player");
        Destroy(currentPlayer);
    }

    
    IEnumerator MoveAndHandleNext()
    {
        Debug.Log("Waiting to move");
       yield return new WaitForSeconds(5.5f);
       StartCoroutine("MoverPersonaje2");
    }

    void SpawnNewEnemy()
    {
        int randomIndex = Random.Range(0, firstPhaseEnemies.Length);
        GameObject newEnemy = Instantiate(firstPhaseEnemies[randomIndex], spawnPoint.position, Quaternion.identity);

        maxEnemyHealth += nextEnemyHealthDifference;
        maxEnemyDamage += nextEnemyDamageDifference;

        newEnemy.GetComponent<Stats>().health = maxEnemyHealth;
        newEnemy.GetComponent<Stats>().damage = maxEnemyDamage;

        newEnemy.GetComponent<Stats>().enemyStats = player.GetComponent<Stats>();
        player.GetComponent<Stats>().enemyStats = newEnemy.GetComponent<Stats>();

        Destroy(currentEnemy);
        currentEnemy = newEnemy;

        //Invoke("RestartCombat", 2.0f);
    }

    void RestartCombat()
    {
        InvokeRepeating("startCombat", 2.0f, 2.0f);
    }

   void moveCamera()
{
    Transform cameraTransform = gamecamera.GetComponent<Transform>();  
    cameraTransform.position = new Vector3(10,0,-10);
}

    IEnumerator MoverPersonaje2(){
     
     float moveDuration = 1.5f;
     float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            player2.transform.Translate(Vector3.right * 1.5f * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null; 
        }
    }
    void changeCurrentPlayer(){
        if(currentPlayer == player){
            currentPlayer = player2;
        }else{
            //currentPlayer = player3;
        }
    }

}

