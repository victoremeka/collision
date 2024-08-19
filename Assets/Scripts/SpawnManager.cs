using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float spawnInterval = 3f;  // seconds between each spawn.
    float nextSpawnTime;
    Vector2 screenHalfSize, pos;
    public GameObject obstacle, player;
    bool ready = false;
    UIManager uiManager;

    void Start(){
        screenHalfSize = new (Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize);
        uiManager = FindObjectOfType<UIManager>();
        uiManager.LoadingComplete += LoadGame;
    }

    void Update()
    {
        if(Time.time > nextSpawnTime && ready){
            nextSpawnTime = Time.time + spawnInterval;

            float spawnHalfSize = Random.Range(0.5f,2f)/2;
            pos = new (Random.Range(-(screenHalfSize.x-spawnHalfSize), screenHalfSize.x-spawnHalfSize), screenHalfSize.y+spawnHalfSize);
            GameObject instance = Instantiate(obstacle, pos, Quaternion.identity);
            instance.transform.localScale = 2 * spawnHalfSize * Vector2.one;
        }
    }

    void LoadGame(){
        Instantiate(player, new Vector2(0,-4), Quaternion.identity);
        ready = true;
    }
}
