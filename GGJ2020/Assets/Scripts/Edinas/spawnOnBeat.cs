using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnOnBeat : MonoBehaviour
{

    public AudioSource audioSource;
    public float updateStep = 0.1f;
    public int sampleDataLenght = 1024;

    private float currentUpdateTime = 0f;

    public float clipLoudness;
    private float[] clipSampleData;

    public GameObject projectile;
    public float sizeFactor = 1;

    public float minSize = 0;
    public float maxSize = 500;


    GameObject randomEnemy;
    public List<GameObject> enemyList = new List<GameObject>();

    [SerializeField] private float stepTimerCheck;


    private void Awake()
    {
        clipSampleData = new float[sampleDataLenght];
    }


    // Update is called once per frame
    void Update()
    {

        TimeStep();
        UpdateStepChange();
      
    }

    private void TimeStep()
    {
        currentUpdateTime += Time.deltaTime;

        if (currentUpdateTime >= updateStep)
        {
            audioSource.clip.GetData(clipSampleData, audioSource.timeSamples);
            clipLoudness = 0f;
            foreach (var sample in clipSampleData)
            {
                clipLoudness += Mathf.Abs(sample);
            }
            clipLoudness /= sampleDataLenght;

            clipLoudness *= sizeFactor;
            clipLoudness = Mathf.Clamp(clipLoudness, minSize, maxSize);

            projectile.transform.localScale = new Vector3(clipLoudness, clipLoudness, clipLoudness);


            currentUpdateTime = 0f;
            SpawnProjectile();
        }
    }

    private void UpdateStepChange()
    {

        stepTimerCheck += Time.deltaTime;

        if (stepTimerCheck < 12)
        {
            updateStep = 0.5f;
        }

        if (stepTimerCheck > 12)
        {
            updateStep = 0.3f;
        }
    }

    private void SpawnProjectile()
    {
         randomEnemy = enemyList[Random.Range(0, enemyList.Count)];
         Instantiate(randomEnemy, this.transform.position, Quaternion.identity);
    }
}
