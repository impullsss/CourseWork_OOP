using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character
{
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;


    private int extraJumps;
    public int extraJumpsValue;

    Animator animator;
    private bool isJumping;


    // Тут добавил Атаку
    
    public GameObject attackHitBox;


    override public void Die(GameObject gameObject)
    {
        //здесь должна быть анимация смерти

        //gameObject.transform.position = new Vector3(-3, 0);  //перемещение персонажа на исходную позицию
        //health = maxHealth;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }

private void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        attackHitBox.SetActive(false); // Вначале сцены атака не активна
    }


    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (animator)
        {
            animator.SetBool("Run", Mathf.Abs(moveInput) >= 0.01);//
        }
        

        if(facingRight == false && moveInput>0)
        {
            Flip();
        } else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void Update()
    {
        isJumping = isGrounded;
        if (!isJumping && !isGrounded)
        {
            animator.SetTrigger("Fall");
        }


        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }


        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
            if (animator)
            {
                isJumping = true;
                animator.SetTrigger("Jump");        
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        if (health <= 0) Die(gameObject);

        if (Input.GetKeyDown(KeyCode.L))
        {
            animator.SetTrigger("Player_Attack");
            StartCoroutine(DoAttack());
        }

    }

    IEnumerator DoAttack()// Метод позволяющий атаковать и включающий BoxCollider атаки на 1 секунду
    {
        attackHitBox.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        attackHitBox.SetActive(false);

        

    }



}
