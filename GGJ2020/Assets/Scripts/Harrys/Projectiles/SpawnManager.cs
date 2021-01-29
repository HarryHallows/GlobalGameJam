using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Conductor conductor;

    [SerializeField] private GameObject spawnPoint;

    [SerializeField] private GameObject[] spawnObj;


    ObjectPooler objPooler;


    // Start is called before the first frame update
    void Start()
    {
        objPooler = ObjectPooler.Instance;

        conductor = conductor.GetComponent<Conductor>();
    }

    // Update is called once per frame
    void Update()
    {
        //Instantiate 2 waves every 8 beats

          WaveSpawner();
        

        // objPooler.SpawnFromPool("Triangle", transform.position, Quaternion.identity);
    }

    //Spawn objects in waves with breaks in between
    private void WaveSpawner()
    {
        objPooler.SpawnFromPool("Triangle", transform.position, Quaternion.identity);
    }

 

    //Spawn Objects one by one
    private void IndividualSpawner()
    {

    }

    IEnumerator IndividualSpawnLogic()
    {
        yield return new WaitForSeconds(0);
    }

    //A mix of the individual and wave spawner alternating on and off
    private void HybridSpawner()
    {

    }

    IEnumerator HybridSpawnLogic()
    {
        yield return new WaitForSeconds(0);
    }
}
