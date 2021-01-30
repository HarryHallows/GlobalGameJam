using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    string myDir = "2bd";
    int setDir;
    public float spinWheelSpeed = 20f;
    int maxWheelSize = 6;
    public int wheelSize = 4;
    [SerializeField]private GameObject[] leftWheel;
    [SerializeField] private GameObject[] rightWheel;
    [SerializeField] private GameObject[] topWheel;
    [SerializeField] private GameObject[] rearWheel;
    // Start is called before the first frame update
    void Start()
    {
        SetWheelSize();
        setDir = Random.Range(1, 3);
        print(setDir);
        
    }

    // Update is called once per frame
    void Update()
    {
        SpinWheel();
        setRotation();
    }

    void SetWheelSize()
    {
        for (int i = 0; i < wheelSize; i++)
        {
            leftWheel[i].GetComponent<SpriteRenderer>().enabled = true;
            rightWheel[i].GetComponent<SpriteRenderer>().enabled = true;
            topWheel[i].GetComponent<SpriteRenderer>().enabled = true;
            rearWheel[i].GetComponent<SpriteRenderer>().enabled = true;
        }

    }

    void setRotation()
    {
        if (setDir == 2)
        {
            myDir = "Left";
        }
        else if (setDir == 1)
        {
            myDir = "Right";
        }
    }

    void SpinWheel()
    {
        for (int i = 0; i < maxWheelSize; i++)
        {
            if (myDir == "Left")
            {
                leftWheel[i].transform.RotateAround(this.transform.position, Vector3.forward, spinWheelSpeed * Time.deltaTime);
                rightWheel[i].transform.RotateAround(this.transform.position, Vector3.forward, spinWheelSpeed * Time.deltaTime);
                topWheel[i].transform.RotateAround(this.transform.position, Vector3.forward, spinWheelSpeed * Time.deltaTime);
                rearWheel[i].transform.RotateAround(this.transform.position, Vector3.forward, spinWheelSpeed * Time.deltaTime);
            }

            else if (myDir == "Right")
            {
                leftWheel[i].transform.RotateAround(this.transform.position, Vector3.back, spinWheelSpeed * Time.deltaTime);
                rightWheel[i].transform.RotateAround(this.transform.position, Vector3.back, spinWheelSpeed * Time.deltaTime);
                topWheel[i].transform.RotateAround(this.transform.position, Vector3.back, spinWheelSpeed * Time.deltaTime);
                rearWheel[i].transform.RotateAround(this.transform.position, Vector3.back, spinWheelSpeed * Time.deltaTime);
            }
           
        }
    }
}
