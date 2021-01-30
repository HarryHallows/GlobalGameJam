using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossBallShoot : MonoBehaviour
{
    float targetXPos;
    float targetYPos;

    float currentXPos;
    float currentYPos;

    float moveSpeed;
    public GameObject[] directionsToMove;

    float destoryDelay = 10f;
    // Start is called before the first frame update
    void Start()
    {
        //myRotation = Random.Range(0f, 360f);
        pickDir();
        

    }

    // Update is called once per frame
    void Update()
    {
        MovementFunction();
    }

    void pickDir()
    {
        //this.transform.Rotate(0f, 0f, myRotation);
        Debug.Log("Hello from Pickdir");
    }

    void MovementFunction()
    {
        Debug.Log("Hello from MoveFunction");
        //transform.position += Vector3.up * Time.deltaTime * movementSpeed;
    }

    void DestoryMe()
    {
        Destroy(gameObject, destoryDelay);
    }
}
