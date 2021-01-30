using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Conductor conductor;

    [SerializeField] private GameObject spawnPoint;

    [SerializeField] private GameObject[] spawnObj;


    ObjectPooler objPooler;

    GameObject randomEnemy;
    public List<GameObject> enemyList = new List<GameObject>();

    [SerializeField] private float spawnTimer;


    // Start is called before the first frame update
    void Start()
    {
        objPooler = ObjectPooler.Instance;

        conductor = conductor.GetComponent<Conductor>();

        spawnTimer = 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        // WaveSpawner();

        //objPooler.SpawnFromPool("Triangle", transform.position, Quaternion.identity);

        IndividualSpawner();

    }

    //Spawn objects in waves with breaks in between
    private void WaveSpawner()
    {
        objPooler.SpawnFromPool("Triangle", transform.position, Quaternion.identity);
    }

    //Spawn Objects one by one
    private void IndividualSpawner()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            randomEnemy = enemyList[Random.Range(0, enemyList.Count)];

            Instantiate(randomEnemy, this.transform.position, Quaternion.identity);

            spawnTimer = 2.5f;
        }
    }

    //A mix of the individual and wave spawner alternating on and off
    private void HybridSpawner()
    {

    }
}
