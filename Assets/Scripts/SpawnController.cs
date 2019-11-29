using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject[] spawncars;
    public Transform[] spawnpoints;
    public float spawnMinTime = 0.5f, spawnMaxTime = 1f;
    float spawnTime, spawnAfter;
    public float spawnMultiplier = 1f;
    public float spawnMultiplierDelta = 0.05f;

    private void Start()
    {
        spawnTime = Random.Range(spawnMinTime, spawnMaxTime);
    }

    void Update()
    {
        if(spawnAfter > spawnTime)
        {
            spawnTime = Random.Range(spawnMinTime, spawnMaxTime);
            Instantiate(spawncars[Random.Range(0, spawncars.Length)], spawnpoints[Random.Range(0,spawnpoints.Length)].position, Quaternion.identity);
            spawnAfter = 0f;
            spawnMultiplier += spawnMultiplierDelta;
        }
        spawnAfter += Time.deltaTime * spawnMultiplier;
    }
}
