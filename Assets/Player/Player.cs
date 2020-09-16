using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
     float speed=4;
    public Rigidbody2D rg;
    int targetX=1;
    int targetY=1;

    int currentX=1;
    int currentY=1;
    Vector2 direction = Vector2.zero;
   
    //Vector2 goal = MazeGenerator.instance.mazeGoalPosition;
       void Update()
    {

        bool targetReached = transform.position.x == targetX && transform.position.y == targetY;
        currentX = Mathf.FloorToInt(transform.position.x);
        currentY = Mathf.FloorToInt(transform.position.y);
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        if (direction.x > 0)
        {


            if (MazeGenerator.instance.GetMazeGridCell(currentX + 1, currentY) && targetReached)
            {
                targetX = currentX + 1;
                targetY = currentY;
            }
        }
        else if (direction.x < 0)
        {


            if (MazeGenerator.instance.GetMazeGridCell(currentX - 1, currentY) && targetReached)
            {
                targetX = currentX - 1;
                targetY = currentY;
            }
        }
        else if (direction.y > 0)
        {


            if (MazeGenerator.instance.GetMazeGridCell(currentX, currentY + 1) && targetReached)
            {
                targetX = currentX;
                targetY = currentY + 1;
            }
        }
        else if (direction.y < 0)
        {


            if (MazeGenerator.instance.GetMazeGridCell(currentX, currentY - 1) && targetReached)
            {
                targetX = currentX;
                targetY = currentY - 1;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(targetX, targetY), speed * Time.deltaTime);
      
    }
 

}
