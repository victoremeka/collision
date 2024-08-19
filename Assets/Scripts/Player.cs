using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    float screenHalfWidth, verticalPos;
    public float speed = 4f;
    public event Action UpdateScore;

    void Awake(){
        screenHalfWidth = Camera.main.orthographicSize * Camera.main.aspect;
        verticalPos = transform.position.y;
    }
   
   void Update(){
        transform.position += speed * Time.deltaTime * new Vector3(Input.GetAxis("Horizontal"), 0);
        if (Math.Abs(transform.position.x) > screenHalfWidth+transform.localScale.x/2){
            transform.position = new Vector3(-transform.position.normalized.x * (screenHalfWidth+transform.localScale.x/2), verticalPos);
        }
   }

   void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.CompareTag("Obstacle")){
        Destroy(collider.gameObject);
        UpdateScore?.Invoke();
    }
   }
    
}
