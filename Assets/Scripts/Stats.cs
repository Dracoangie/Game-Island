using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    
    public int health;
    public int damage;
    public Stats enemyStats;
    public TextMeshPro enemyLiveBar;

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

    public void recieveDamage(int damage){
        this.health-=damage;
    }
}
