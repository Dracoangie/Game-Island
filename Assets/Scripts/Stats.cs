using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    
    public int health;
    public int damage;
    public Stats enemyStats;
    public Text enemyLiveBar;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void attack(Stats enemyStats){
        enemyStats.recieveDamage(this.damage);
    }

    public void attack(int AttDamage){
        enemyStats.recieveDamage(AttDamage);
    }

    public void heal(int heal){
        health += heal;
    }

    public void recieveDamage(int damage){
        this.health-=damage;
    }
}
