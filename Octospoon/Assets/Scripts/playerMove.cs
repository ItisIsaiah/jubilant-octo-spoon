using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMove : MonoBehaviour
{
    //Movement
    float horizontal;
    Vector2 moveC;

    //
    public Material fade;

    //speeds
    public float jumpForce=20f;
    public float moveSpeed = 20f;
    public float controllerMoveSpeed = 20f;

    //logic
    Rigidbody2D rb;
    bool facingRight = true;

    public Transform[] groundpoints;
    PlayerControls controls;

    public Animator anim;
    // Start is called before the first frame update

    void Awake()
    {
        controls = new PlayerControls();
        controls.Gameplay.Jump.performed += ctx=> jump();

        controls.Gameplay.Move.performed += ctx => moveC = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => moveC = Vector2.zero;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");




        Vector2 m = new Vector2(moveC.x*controllerMoveSpeed, moveC.y) * Time.deltaTime;
        transform.Translate(m, Space.World);


        //

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Same");
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
   
    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
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
        anim.SetFloat("speed2", Mathf.Abs(moveC.x));
    }
   void OnDrawGizmos()
    {
        
    }
}

