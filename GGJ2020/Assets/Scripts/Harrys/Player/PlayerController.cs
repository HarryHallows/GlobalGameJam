using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    [Header("       COMPONENT VARIABLES        ")]
    [Space]
    [SerializeField] private Rigidbody2D rb;

    [Header("GameObjects")]
    [SerializeField] private GameObject colourWheel;
    [SerializeField] private GameObject colourWheelPicker;
    [SerializeField] private GameObject[] trailObj;

    private Color myColor;
   

    [Header("       DATA VARIABLES      ")]

    [Header("Vectors")]
    private Vector3 moveDirection;

    [Header("Floats")] 
    [SerializeField] private float moveSpeed;
    [SerializeField] private float dashSpeed;

    [SerializeField] private float loseTimer = 3f;

    [Header("Boolean")]
    [SerializeField] private bool isDashing;


    [SerializeField] private bool pinkColour;
    [SerializeField] private bool tealColour;
    [SerializeField] private bool orangeColour;
    [SerializeField] private bool yellowColour;

    [Header("Strings")]
    [SerializeField] public string gameState;
    [SerializeField] private string colourState;

    // Start is called before the first frame update
    void Start()
    {
       // trailObj[0].GetComponent<ParticleSystem>().startColor = myColor;
       // trailObj[1].GetComponent<ParticleSystem>().startColor = myColor;
    }

    // Update is called once per frame
    void Update()
    {
        MovementInputs();
        ColourInput();
        GameState();
    }

    private void FixedUpdate()
    {
        Movement();   
    }

    public void GameState()
    {
        if(gameState == "LoseAnim")
        {
            loseTimer -= Time.deltaTime;

            this.GetComponent<SpriteRenderer>().color -= new Color32(1, 1, 1, 1);
            Debug.Log("player has been hit reducing alpha..... dead");

            if (loseTimer <= 0)
            {
                gameState = "Lose";
            }

        }


        if (gameState == "Lose")
        {
            SceneManager.LoadScene(2);    
        }

        if(gameState == "Win")
        {
            SceneManager.LoadScene(3);
        }
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
            pinkColour = true;

            tealColour = false;
            orangeColour = false;
            yellowColour = false;



            this.GetComponent<SpriteRenderer>().color = new Color32(237, 0, 255, 225);
            trailObj[3].SetActive(true);

            trailObj[0].SetActive(false);
            trailObj[1].SetActive(false);
            trailObj[2].SetActive(false);
            trailObj[4].SetActive(false);
        }

        if(colourState == "Teal")
        {
             tealColour = true;

            pinkColour = false;
            orangeColour = false;
            yellowColour = false;


            this.GetComponent<SpriteRenderer>().color = new Color32(0, 245, 255, 225);

            trailObj[0].SetActive(true);

            trailObj[1].SetActive(false);
            trailObj[2].SetActive(false);
            trailObj[3].SetActive(false);
            trailObj[4].SetActive(false);
        }

        if(colourState == "Orange")
        {
            orangeColour = true;

            pinkColour = false;
            tealColour = false;
            yellowColour = false;


            this.GetComponent<SpriteRenderer>().color = new Color32(255, 124, 0, 225);
            trailObj[2].SetActive(true);

            trailObj[0].SetActive(false);
            trailObj[1].SetActive(false);
            trailObj[3].SetActive(false);
            trailObj[4].SetActive(false);
        }

        if (colourState == "Yellow")
        {
            yellowColour = true;

            tealColour = false;
            pinkColour = false;
            yellowColour = false;



            this.GetComponent<SpriteRenderer>().color = new Color32(255, 224, 0, 225);
            trailObj[1].SetActive(true);

            trailObj[0].SetActive(false);
            trailObj[2].SetActive(false);
            trailObj[3].SetActive(false);
            trailObj[4].SetActive(false);
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

        //Vertical Clamp
        if(this.transform.position.y > 10)
        {
            Debug.Log("Move player to bottom");
            this.transform.position = new Vector3(0, -10, 0);
        }

        if (this.transform.position.y < -10)
        {
            this.transform.position = new Vector3(0, 10, 0);
        }

        //Horizontal Clamp
        if (this.transform.position.x > 18)
        {
            Debug.Log("Move player to other side");
            this.transform.position = new Vector3(-18, 0, 0);
        }

        if (this.transform.position.x < -18)
        {
            this.transform.position = new Vector3(18, 0, 0);
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
       if(collision.CompareTag ("PinkEnemy") && pinkColour == false)
       {        
           gameState = "LoseAnim";            
       }

        if(collision.CompareTag("TealEnemy") && tealColour == false)
        {   
            gameState = "LoseAnim";        
        }

        if(collision.CompareTag("OrangeEnemy") && orangeColour == false)
        {       
            gameState = "LoseAnim";              
        }

        if (collision.CompareTag("YellowEnemy") && yellowColour == false)
        { 
            gameState = "LoseAnim";      
        }
    }
}
