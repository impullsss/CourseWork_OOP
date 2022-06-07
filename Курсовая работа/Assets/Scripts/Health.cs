using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public virtual void Die(GameObject gameObject) { }
    public void TakeHit (int damage)
    {
        health -= damage;

        if (health <=0)
        {
            Die(gameObject);
        }
    }
    
    void Start()
    {
        health = maxHealth;
    }


}
