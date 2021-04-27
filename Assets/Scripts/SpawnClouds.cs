using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnClouds : MonoBehaviour
{
    public float spawnHeight;
    public float heightVariation;
    public float spawnArea;
    public int cloudAmount;

    public GameObject cloudObj;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < cloudAmount; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(transform.position.x - spawnArea, transform.position.x + spawnArea), Random.Range(spawnHeight - heightVariation, spawnHeight + heightVariation), Random.Range(transform.position.z - spawnArea, transform.position.z + spawnArea));
            Instantiate(cloudObj, spawnPos, Quaternion.identity, this.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
