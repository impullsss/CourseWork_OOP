using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : Character
{
    public GameObject leftBorder;
    public GameObject rightBorder;
    public Rigidbody2D rb;

    public bool isRightDirection;
    bool isShacking = false;// Переменная чтобы сделать небольшое покачивание
    Vector2 pos;
    float shake = .2f;

    private void Start()
    {
        pos = transform.position;
        health = maxHealth;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            isShacking = true;
            health--;
            Invoke("StopShaking", 0.5f);

        }
    }
    void StopShaking()
    {
        isShacking = false;
    }
    public override void Die(GameObject gameObject)
    {
        Destroy(gameObject);
    }
    void Update()
    {
        if (isShacking == true)
        {
            transform.position = pos + UnityEngine.Random.insideUnitCircle * shake;
        }
        if (health <= 0)
        {
            Die(gameObject);
        }

        if (isRightDirection)
        {
            rb.velocity = Vector2.right * speed;
            if (transform.position.x > rightBorder.transform.position.x)
            {
                isRightDirection = false;
            }

        }
        else
        {
            rb.velocity = Vector2.left * speed;
            if (transform.position.x < leftBorder.transform.position.x)
            {
                isRightDirection = true;
            }
        }
    }

}
