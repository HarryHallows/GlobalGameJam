using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{

    private GameObject player;

    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    [SerializeField] private Vector3 offset;

    // Start is called before the first frame update
    private void LateUpdate()
    {
        player = GameObject.Find("Player");

        target = player.GetComponent<Transform>();

        Vector3 desiredPos = target.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, speed * Time.deltaTime);
        transform.position = smoothPos;
    }
}
