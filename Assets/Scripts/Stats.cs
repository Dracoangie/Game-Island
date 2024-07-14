using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    
    public int health;
    public int damage;
    public Stats enemyStats;
    public Image healthBar;
    int maxHealth ;

    void Start(){
        maxHealth = health;
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
        if(health > maxHealth) health = maxHealth;
        UpdateHealthBar();
    }

    public void recieveDamage(int damage){
        this.health-=damage;
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = (float)health / maxHealth;
        }
    }
}
