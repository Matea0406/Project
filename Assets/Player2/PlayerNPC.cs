using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNPC : MonoBehaviour
{
    int targetX = 1;
    int targetY = 1;

    int currentX = 1;
    int currentY = 1;
    float speed=4;
   
  
    void Update()
    {
       bool targetReached = transform.position.x == targetX && transform.position.y == targetY;
       transform.position = Vector2.MoveTowards(transform.position, new Vector2(targetX, targetY), speed * Time.deltaTime);
       
    }
 
}

