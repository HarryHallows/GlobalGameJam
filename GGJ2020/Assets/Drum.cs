using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drum : MonoBehaviour
{
   [SerializeField] GameObject[] Animation; // [0 = drumstick, 1 = point a 2 = point b]
   [SerializeField] GameObject[] Spawning; // 0 = spawn point 2 = spawnin prefab.


    //attack animation
    [SerializeField] private string drumState = "Descend";
    [SerializeField] private float drumSpeed = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (drumState == "Descend")
        {
            if (Animation[0].transform.position.y != Animation[1].transform.position.y)
            {
                Animation[0].transform.position += new Vector3(0f, -drumSpeed, 0f) * Time.deltaTime;
            }

            if (Animation[0].transform.position.y <= Animation[1].transform.position.y)
            {
                print("Hello from second descend");
                drumState = "Ascend";
            }
        }

        if (drumState == "Ascend")
        {
            if (Animation[0].transform.position.y != Animation[2].transform.position.y)
            {
                Animation[0].transform.position += new Vector3 (0f, drumSpeed, 0f) * Time.deltaTime;
            }

            if (Animation[0].transform.position.y >= Animation[2].transform.position.y)
            {
                drumState = "Descend";
            }
        }
    }

    void Playdrum()
    {

    }
}
