using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    Conductor conductor;

    [SerializeField] private GameObject spawnPoint;

    [SerializeField] private GameObject[] spawnObj;

    // Start is called before the first frame update
    void Start()
    {
        conductor = conductor.GetComponent<Conductor>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Spawn objects in waves with breaks in between
    private void WaveSpawner()
    {
      
    }

    IEnumerator WaveSpawnLogic()
    {
        if (conductor.secPerBeat == 8)
        {
            //Instantiate 2 waves every 8 beats 
        }

        if (conductor.secPerBeat == 16)
        {
            //Instantiate 6 waves every 16 beats 
        }

        yield return new WaitForSeconds(0);
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
