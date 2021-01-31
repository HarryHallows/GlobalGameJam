using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barjectile : MonoBehaviour
{
    float frametime = 24;
    float delaygrowthtime ;

    float despawnSize;
    

    float destoryDelay = 3f;
    // Start is called before the first frame update
    void Start()
    {
        delaygrowthtime = Random.Range(20f, 40f);
    }

    // Update is called once per frame
    void Update()
    {
        scaleIncrease();
    }
    
    void scaleIncrease()
    {
        frametime -= 1;
        if (frametime <= 0)
        {
            frametime = 24;
            delaygrowthtime -= 1;
            if (delaygrowthtime <= 0)
            {
                despawnSize += 0.05f;
                this.transform.localScale += new Vector3(0f, 0.05f, 0f);
                this.transform.position += new Vector3(0f, 0.05f, 0f);
                if (despawnSize >= 3)
                {
                    DestoryMe();
                }
            }
        }
        
    }

    void DestoryMe()
    {
        Debug.Log("Hello from Destroy me");
        Destroy(gameObject, destoryDelay);
    }
}
