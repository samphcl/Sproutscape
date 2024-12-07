using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainSpawner : MonoBehaviour
{
    [SerializeField] Transform cloudTransform;
    [SerializeField] GameObject raindrop; 
    [SerializeField] float spawnDistance = 2;
    [SerializeField] float spawnTime = 3f;

    public float timer = 0;
    
    void SpawnRaindrops(){
        Vector3 spawnPos = cloudTransform.position + new Vector3(Random.Range(-1f,1f), 0, 0).normalized * spawnDistance; 
        Instantiate(raindrop, spawnPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= spawnTime){
            SpawnRaindrops();
            timer = 0; 
        }
    }
}
