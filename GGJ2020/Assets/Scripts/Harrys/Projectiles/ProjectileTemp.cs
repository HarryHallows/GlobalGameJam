using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTemp : MonoBehaviour, IPooledObjects
{
    // Start is called before the first frame update


    public void OnObjectSpawn()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 1, 0);

        if (this.transform.position.y > 10)
        {
            this.gameObject.SetActive(false);
        }
    }
}
