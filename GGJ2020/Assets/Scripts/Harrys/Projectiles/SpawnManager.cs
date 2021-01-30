using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Conductor conductor;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject[] spawnObj;


    public enum SpawnState {SPAWNING, WAITING, COUNTING };

    [System.Serializable]
   public class Wave
   {
        public string name;
        public Transform musicNote;
        public int count;
        public float spawnRate;
   }

    public Wave[] waves;
    private int nextWave = 0; //wave index

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    [SerializeField] private float waveCountDown;
    [SerializeField] private float searchCountDown = 1f; //count down looking for music notes alive

    private SpawnState state = SpawnState.COUNTING;
    
    // Start is called before the first frame update
    void Start()
    {
       // objPooler = ObjectPooler.Instance;

        conductor = conductor.GetComponent<Conductor>();

        waveCountDown = timeBetweenWaves;

        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points referenced");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // WaveSpawner();
        IndividualSpawner();
        WaveStates();
    }

    private void WaveStates()
    {
        if(state == SpawnState.WAITING)
        {
            //Check if notes are still alive
            if(!NoteIsAlive())
            {
                //start next round
                WaveCompleted();
                return;
            }
            else
            {
                return;
            }
        }

        if (waveCountDown <= 0)
        {            
            if(state != SpawnState.SPAWNING)
            {
                // start spawning notes
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountDown -= Time.deltaTime;
        }
    }

    private void WaveCompleted()
    {
        Debug.Log("Wave completed");

        state = SpawnState.COUNTING;

        waveCountDown = timeBetweenWaves;

        if(nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("ALL waves complete! looping");
        }
        else
        {
            nextWave++;
        }
    }

    private bool NoteIsAlive()
    {
        searchCountDown -= Time.deltaTime;
       
        if(searchCountDown <= 0)
        {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectsWithTag("MusicNotes").Length == 0)
            {
                return false;
            }
        }

        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning wave: " + _wave.name);

        state = SpawnState.SPAWNING;
        
        for (int i = 0; i < _wave.count; i++)
        {
            // Spawn
            SpawnNotes(_wave.musicNote);
            yield return new WaitForSeconds(1f/_wave.spawnRate);
        }      

        state = SpawnState.WAITING;

        yield break;
    }

    private void SpawnNotes(Transform _notes)
    {
        //Spawn Notes 

        Debug.Log("spawning Notes" + _notes.name);

        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_notes, _sp.position, _sp.rotation);

    }

    //Spawn objects in waves with breaks in between
    private void WaveSpawner()
    {
        //objPooler.SpawnFromPool("Triangle", transform.position, Quaternion.identity);
    }

    //Spawn Objects one by one
    private void IndividualSpawner()
    {
    
    }

    //A mix of the individual and wave spawner alternating on and off
    private void HybridSpawner()
    {

    }
}
