using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chainBase : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform player;
    private Vector2 target;
    [SerializeField] private GameObject[] chainObj;
    [SerializeField] private SpriteRenderer[] spriteObj;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // calcuates current player position
        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        //move towards player registered position.
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            for (int i = 0; i < chainObj.Length; i++)
            {
                //spriteObj[i]. -= 
            }
        }
    }
}
