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
    [SerializeField] private Rigidbody2D rb;
    bool timeToGo = false;
    [SerializeField] private Transform targetTrans;
    private float angleBetween = 0.0f;
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
        if (chainObj[0].transform.position.x != target.x && chainObj[0].transform.position.y != target.y)
            {
                transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            }
        if (chainObj[0].transform.position.x == target.x && chainObj[0].transform.position.y == target.y)
            {


            for (int i = 0; i < chainObj.Length; i++)
                {
                  spriteObj[i].GetComponent<SpriteRenderer>().color -= new Color32(1, 1, 1, 1);
                  Destroy(chainObj[i].gameObject, 2f);
                }

            
            }
    }
}
