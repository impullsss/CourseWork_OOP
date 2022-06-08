using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public virtual void Die(GameObject gameObject)
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        health = maxHealth;
    }


}
