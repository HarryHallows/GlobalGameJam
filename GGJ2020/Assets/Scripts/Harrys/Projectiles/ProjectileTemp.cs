using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTemp : MonoBehaviour
{

    [SerializeField] private Transform[] targetObjects;
    [SerializeField] private GameObject player;

    [SerializeField] private Rigidbody2D rb;


    [SerializeField] private float moveSpeed;


    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    [SerializeField] private Vector3 offset;

    // Start is called before the first frame update
    

    private void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * moveSpeed * Time.deltaTime, Space.World);
        

        if (this.transform.position.y > 10)
        {
            Destroy(gameObject,3f);
        }

        if (this.transform.position.y < -10)
        {
            this.gameObject.SetActive(false);
        }

        if (this.transform.position.x > 20)
        {
            Destroy(gameObject, 3f);
        }

        if (this.transform.position.x < -20)
        {
            this.gameObject.SetActive(false);
        }
    }


}
