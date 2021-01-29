using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePattern : MonoBehaviour
{
    public string MyState = "Idle"; // Idle // Spawning // Growing // 
    public GameObject myChild;
    public GameObject Duplicate;
    public float velocidad;
    int SpawnTime;
    int SpawnTimer = 24;
    int GrowthTime = 24;

    int XposEast;
    int XposWest;

    // Start is called before the first frame update
    void Start()
    {
        velocidad = 50f;
        SpawnTime = Random.Range(10, 24);
        MyState = "Spawning";
        //XposEast = this.transform.position.x(-5);
    }

    // Update is called once per frame
    void Update()
    {
        Idle();
        Spawning();
        Growing();
    }

    void Idle()
    {
        if (MyState == "Idle")
        {
            //print("Hello");
            myChild.transform.RotateAround(this.transform.localPosition, Vector3.back, Time.deltaTime * velocidad);

        }
    }

    void Spawning()
    {
        if (MyState == "Spawning")
            myChild.transform.RotateAround(this.transform.localPosition, Vector3.back, Time.deltaTime * velocidad);
        {
            SpawnTimer -= 1;
            if (SpawnTimer <= 0)
            {
                SpawnTimer = Random.Range(30, 98);
                SpawnTime -= 1;
                if (SpawnTime <= 0)
                {
                    MyState = "Migrate";
                    Instantiate(Duplicate, myChild.transform.position, Quaternion.identity);
                    SpawnTime = 24;
                    
                }
            }
        }

    }
    void Growing()
    {
        if (MyState == "Migrate")
        {
            
        }
    }
}
