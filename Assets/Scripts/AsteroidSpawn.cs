using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] asteroidObjects;
    [SerializeField] private float asteroidsFrequency;
    [SerializeField] private Vector2 forceRange;

    private float timer;
    private Camera mainCamera;

    private int count = 0;
    
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
        timer -= Time.deltaTime;
    
        if(timer <= 0 && count <= 5){
            SpawnAsteroid();
            timer += asteroidsFrequency;
            count++;
        }
    }

    void SpawnAsteroid(){
        int side = Random.Range(0,4);

        Vector2 spawnPoint = Vector2.zero;
        Vector2 direction = Vector2.zero;

        switch(side){
            case 0:
                spawnPoint.x = 0;
                spawnPoint.y = Random.value;
                direction = new Vector2(1.0f,Random.Range(-1.0f,1.0f));
                break;
            case 1:
            spawnPoint.x = 1;
            spawnPoint.y = Random.value;
            direction = new Vector2(-1.0f,Random.Range(-1.0f,1.0f));
                break;
            case 2:
                spawnPoint.x = Random.value;
                spawnPoint.y = 0;
                direction = new Vector2(Random.Range(-1.0f,1.0f),1.0f);
                break;
            case 3:
                spawnPoint.x = Random.value;
                spawnPoint.y = 1;
                direction = new Vector2(Random.Range(-1.0f,1.0f),-1.0f);
                break;
        }
        Vector3 worldSpawnPoint = mainCamera.ViewportToWorldPoint(spawnPoint);
        worldSpawnPoint.z = 10;
        
        GameObject currentAsteroid = asteroidObjects[Random.Range(0, asteroidObjects.Length)];
        GameObject instance = Instantiate(currentAsteroid, worldSpawnPoint, Quaternion.Euler(0f,0f,Random.Range(0f,360f)));
        

        Rigidbody asteroidBody = instance.GetComponent<Rigidbody>();

        asteroidBody.velocity = direction.normalized * Random.Range(forceRange.x, forceRange.y);
    }
    
}
