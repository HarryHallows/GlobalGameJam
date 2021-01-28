using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("       COMPONENT VARIABLES        ")]
    [Space]
    [SerializeField] private Rigidbody2D rb;

    [Header("GameObjects")]
    [SerializeField] private GameObject colourWheel;
    [SerializeField] private GameObject colourWheelPicker;

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
    [SerializeField] private string colourState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovementInputs();
        ColourInput();
    }

    private void FixedUpdate()
    {
        Movement();   
    }


    private void ColourInput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            colourWheel.SetActive(true);
            colourWheelPicker.SetActive(true);
        }
       
        if(Input.GetMouseButtonUp(0))
        {
            Debug.Log("Mouse Button up");
            colourWheel.SetActive(false);
            colourWheelPicker.SetActive(false);
        }

        if(colourWheel.activeSelf == true)
        {
            Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - colourWheelPicker.transform.position;

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            colourWheelPicker.transform.rotation = rotation;

            Debug.Log(colourWheelPicker.transform.eulerAngles.z);

            //Pink colour Pick
            if(colourWheelPicker.transform.eulerAngles.z <= 12 && colourWheelPicker.transform.eulerAngles.z >= 0 || colourWheelPicker.transform.eulerAngles.z <= 360 && colourWheelPicker.transform.eulerAngles.z >= 345)
            {
                Debug.Log("IM SETTING GAMESTATE TO TURN PINK");
                colourState = "Pink";
            }

            //orange colour pick
            if(colourWheelPicker.transform.eulerAngles.z <= 55 && colourWheelPicker.transform.eulerAngles.z >= 22)
            {
                Debug.Log("IM SETTING GAMESTATE TO TURN ORANGE");
                colourState = "Orange";
            }

            //teal colour pick
            if(colourWheelPicker.transform.eulerAngles.z <= 338 && colourWheelPicker.transform.eulerAngles.z >= 304)
            {
                Debug.Log("IM SETTING GAMESTATE TO TURN TEAL");
                colourState = "Teal";
            }

            
        }


        if(colourState == "Pink")
        {
            this.GetComponent<SpriteRenderer>().color = new Color32(237, 0, 255, 225);
        }

        if(colourState == "Teal")
        {
            this.GetComponent<SpriteRenderer>().color = new Color32(0, 245, 255, 225);
        }

        if(colourState == "Orange")
        {
            this.GetComponent<SpriteRenderer>().color = new Color32(255, 124, 0, 225);
        }
    }
    private void MovementInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(moveX, moveY).normalized; 

        if(Input.GetKeyDown(KeyCode.Space))
        {
            isDashing = true;
        }
    }

    private void Movement()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        if(isDashing)
        {
            rb.MovePosition(transform.position + moveDirection * dashSpeed);
            isDashing = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.tag == "PinkEnemy" && isDashing == false || colourState != "Pink")
       {
            gameState = "Lose";
       }

        if(collision.tag == "TealEnemy" && isDashing == false || colourState != "Teal")
        {
            gameState = "Lose";
        }

        if(collision.tag == "OrangeEnemy" && isDashing == false || colourState != "Orange")
        {
            gameState = "Lose";
        }
    }
}
