using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    float horizontal;
    float jumpForce;
    public float moveSpeed = 20f;
    Rigidbody2D rb;
    bool facingRight = true;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");



        


        if (Input.GetKey(KeyCode.Space))
        {
            jump();
        }

        if (Input.GetKeyDown("a") || Input.GetKeyDown("d"))
        {
            flip();
            Debug.Log("me too!");
        }
        HandleAnimation();
        move(horizontal);
    }

    void move(float horizontal)
    {
        
        if (Input.GetKey("a") || Input.GetKey("d"))
        {
            Debug.Log("I work");
            rb.velocity += new Vector2(moveSpeed * horizontal * Time.deltaTime, 0f);
        }
        


    }

    void jump()
    {
        rb.AddForce(transform.up * jumpForce);
    }

    void flip()
    {

        if (facingRight&&horizontal<0 || !facingRight && horizontal > 0) {
            transform.Rotate(0f, 180f, 0);
            facingRight=!facingRight;
        }
       




    }
    void HandleAnimation()
    {
        anim.SetFloat("speed", Mathf.Abs(horizontal));
    }
}

