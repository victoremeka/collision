using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using static SpawnManager;

public class Obstacle : MonoBehaviour
{
    public float speed = 1f, rotationSpeed = 1f;
    Vector3 velocity;
    int rotDirection;
    float screenHalfHeight;
    void Start()
    {
        rotDirection = Random.Range(0,2).Equals(0) ? -1 : 1;
        screenHalfHeight = Camera.main.orthographicSize;
        velocity = Vector3.down * speed;
    }

    void Update()
    {
        transform.position += velocity * Time.deltaTime;

        if (transform.position.y < -(screenHalfHeight+transform.localScale.y/2) )
        {
            Destroy(gameObject);
        }

        transform.rotation *= Quaternion.Euler(0,0,rotationSpeed*rotDirection);
    }
}
