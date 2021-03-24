using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    float horizontal;
    public float moveSpeed=20f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey("a")|| Input.GetKey("d"))
        {
            move(horizontal);
        }

    }
    void move(float horizontal)
    {
        Debug.Log("I work");
        rb.velocity += new Vector2(moveSpeed * horizontal * Time.deltaTime, 0f);

    }
}
