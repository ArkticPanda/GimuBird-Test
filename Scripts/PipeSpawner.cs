using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    private float maxTime = 1.5f;
    private float heightRange = 0.5f;
    public GameObject[] pipes; // Array to store different pipe GameObjects
    private float timer;
    private Vector3 spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTime)
        {
            SpawnPipe();
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    void SpawnPipe()
    {
        
        int randomIndex = Random.Range(0, pipes.Length);
        GameObject selectedPipe = pipes[randomIndex];

        spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
        
        GameObject _pipe = Instantiate(selectedPipe, spawnPos, Quaternion.identity);

        Destroy(_pipe, 10f);
    }
}

