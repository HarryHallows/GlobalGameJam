using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinWheel : MonoBehaviour
{
    string myDir = "2bd";
    int setDir;
    public float spinWheelSpeed = 20f;
    int maxWheelSize = 6;
    public int wheelSize = 4;

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
        void SetWheelSize()
    {
        for (int i = 0; i < wheelSize; i++)
        {

            topWheel[i].GetComponent<SpriteRenderer>().enabled = true;
            rearWheel[i].GetComponent<SpriteRenderer>().enabled = true;
        }

    }

    void SpinWheel()
    {
        for (int i = 0; i < maxWheelSize; i++)
        {
            if (myDir == "Left")
            {
                topWheel[i].transform.RotateAround(this.transform.position, Vector3.back, spinWheelSpeed * Time.deltaTime);
                rearWheel[i].transform.RotateAround(this.transform.position, Vector3.forward, spinWheelSpeed * Time.deltaTime);
            }
            else if (myDir == "Right")
            {
                topWheel[i].transform.RotateAround(this.transform.position, Vector3.forward, spinWheelSpeed * Time.deltaTime);
                rearWheel[i].transform.RotateAround(this.transform.position, Vector3.back, spinWheelSpeed * Time.deltaTime);
            }
  
        }
    }
}
