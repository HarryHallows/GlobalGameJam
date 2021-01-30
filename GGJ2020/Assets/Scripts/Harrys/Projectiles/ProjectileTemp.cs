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


        Destroy(gameObject, 10f);
    }


}
