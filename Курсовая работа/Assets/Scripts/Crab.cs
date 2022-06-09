using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{
    public GameObject leftBorder;
    public GameObject rightBorder;
    public Rigidbody2D rigidbody;
    public bool isRightDirection;
    public bool isGrounded;
    public int damage;
    public float speed;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform") isGrounded = true;
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Health health = collision.gameObject.GetComponent<Health>();
            health.health -= damage;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform") isGrounded = false;
    }

     private void FixedUpdate()
    {
        if(animator) animator.SetFloat("Speed", Mathf.Abs(rigidbody.velocity.x));
    }

    public void Update()
    {
        if (isRightDirection && isGrounded)
        {
            rigidbody.velocity = Vector2.right * speed;

            if (transform.position.x > rightBorder.transform.position.x)
                isRightDirection = !isRightDirection;
        }
        else if (isGrounded)
        {
            rigidbody.velocity = Vector2.left * speed;
            if (transform.position.x < leftBorder.transform.position.x)
                isRightDirection = !isRightDirection;
        }

    }

}
