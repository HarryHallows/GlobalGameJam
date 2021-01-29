using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MenuScript : MonoBehaviour
{

    [SerializeField] public Animator myAnim;
    [SerializeField] public bool keyGone;
    [SerializeField] public float animTime; 


    // Start is called before the first frame update
    void Start()
    {
        keyGone = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (keyGone == true)
        {
            myAnim.SetBool("KeyLeaving", true); 
        }
        animTime += Time.deltaTime;

        if (animTime > 28)
        {
            keyGone = true; 
        }
    }
}
