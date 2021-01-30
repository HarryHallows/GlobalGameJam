using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthSpike : MonoBehaviour
{
    public string MyDir = "South";
    public string MyState = "Idle";
    int MyTimer = 24;
    float destoryDelay = 10f;

    // Start is called before the first frame update
    void Start()
    {
        MyState = "Growing";
    }

    // Update is called once per frame
    void Update()
    {
        Growth();
        Moving();
    }

    void Growth()
    {
        if (MyState == "Growing")
        {
            if (this.transform.localScale != new Vector3(0.5f, 0.5f, 0.5f))
            {
                MyTimer -= 1;
                if (MyTimer <= 0)
                {
                    this.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
                    MyTimer = 24;
                }

            }

            if (this.transform.localScale == new Vector3(0.5f, 0.5f, 0.5f))
            {
                MyState = "Move";
            }

        }
    }

    void Moving()
    {
        if (MyState == "Move")
        {
            if (MyDir == "South")
            {
                this.transform.position = this.transform.position + new Vector3(0f, -0.1f, 0f);
            }else if (MyDir == "North")
            {
                this.transform.position = this.transform.position + new Vector3(0f, 0.1f, 0f);
            }
            else if (MyDir == "East")
            {
                this.transform.position = this.transform.position + new Vector3(-0.1f, 0f, 0f);
            }
            else if (MyDir == "West")
            {
                this.transform.position = this.transform.position + new Vector3(-0.1f, 0f, 0f);
            }
        }
    }

    void DestoryMe()
    {
        Destroy(gameObject, destoryDelay);
    }
}
