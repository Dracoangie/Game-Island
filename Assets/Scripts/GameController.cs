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

    int  PlayerDefence = 0;

    Animator playerAnim;

    void Start()
    {
        InvokeRepeating("startCombat", 2.0f, 2.0f);
        playerAnim = player.GetComponent<Animator>();
    }

    
    void Update()
    {
        
    }

    public void secuenciaTrasCombate(){
        CancelInvoke("startCombat");
                Destroy(currentEnemy);
                Debug.Log("Enviando a caminar");
                Invoke("MovePlayer", 2.0f);
                Invoke("SpawnNewEnemy", 4.0f);
    }

    public void startCombat()
    {
        playerAnim.SetBool("IsAttacking", true);
        player.GetComponent<Stats>().attack(currentEnemy.GetComponent<Stats>());
        if(PlayerDefence <= 0)
        {
            currentEnemy.GetComponent<Stats>().attack(player.GetComponent<Stats>());

            if (currentEnemy.GetComponent<Stats>().health <= 0)
            {
                secuenciaTrasCombate();
            }
        }
        else 
            PlayerDefence --;

        
        Invoke("setAttcBool", 0.3f);
    }

    public void CardCombat(Card card)
    {
        switch(card.cardType.ToString()){
            case "Attack":
                playerAnim.SetBool("IsAttacking", true);
                player.GetComponent<Stats>().attack(card.value);

                if (currentEnemy.GetComponent<Stats>().health <= 0)
                {
                    secuenciaTrasCombate();
                }
                Invoke("setAttcBool", 0.3f);
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

    void MovePlayer()
    {
        Debug.Log("Moviendose");
        Rigidbody2D rb2d = player.GetComponent<Rigidbody2D>();
       
        if (rb2d != null)
        {
            Debug.Log(rb2d.velocity);
            rb2d.velocity = new Vector2(2.0f, rb2d.velocity.y);
            Debug.Log(rb2d.velocity);
        }
        else
        {
            Debug.Log("Moviendo el transform");
            player.transform.Translate(Vector3.right * 2.0f * Time.deltaTime);

        }
        Invoke("DestroyPlayer",2.0f);
        Invoke("changeCurrentPlayer",3.0f);
        Invoke("moveCamera",2.0f);
        StartCoroutine("MoveAndHandleNext");

    }

    void DestroyPlayer(){
        Destroy(currentPlayer);
    }

    
    IEnumerator MoveAndHandleNext()
    {
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

