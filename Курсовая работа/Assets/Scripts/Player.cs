using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int Speed = 10;
    float force;
    public Rigidbody2D rigidbody;
    int minimalHeight = -50;

    private void Start()
    {
        int applesCount = 3 + 5;

        Debug.Log(applesCount);
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * Time.deltaTime * Speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * Time.deltaTime * Speed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * Time.deltaTime * Speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * Time.deltaTime * Speed);
        }
        if (transform.position.y < minimalHeight)
        {
            transform.position = new Vector3(0, 0, 0);  
        }
    }
}

