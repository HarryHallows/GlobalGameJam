using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourFollow : MonoBehaviour
{


    public bool down; 
    public float speed = 1.5f;
    private Vector3 target;

    void Start()
    {
        target = transform.position;
        
    }

    void Update()
    {

        

        if (Input.GetMouseButtonUp(0))
        {
            down = false; 
        }

        if (Input.GetMouseButtonDown(0))
        {
            down = true;
        }


        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (down == false)
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
        }
    }
}






