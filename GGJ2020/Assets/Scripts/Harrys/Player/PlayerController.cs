using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("       COMPONENT VARIABLES        ")]
    [Space]
    [SerializeField] private Rigidbody2D rb;


    [Header("       DATA VARIABLES      ")]

    [Header("Vectors")]
    private Vector3 moveDirection;

    [Header("Floats")] 
    [SerializeField] private float moveSpeed;
    [SerializeField] private float dashSpeed;

    [Header("Boolean")]
    [SerializeField] private bool isDashing;

    [Header("Strings")]
    [SerializeField] private string gameState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovementInputs();
    }

    private void FixedUpdate()
    {
        Movement();   
    }

    private void MovementInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(moveX, moveY).normalized; 

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isDashing = true;
        }
    }

    private void Movement()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        if (isDashing)
        {
            rb.MovePosition(transform.position + moveDirection * dashSpeed);
            isDashing = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.tag == "Enemy" && isDashing == false)
       {
            gameState = "Lose";
       }
    }
}
