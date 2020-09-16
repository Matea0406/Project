using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    bool isTriggered = false;
    void Update()
    {
        transform.position = MazeGenerator.instance.mazeGoalPosition;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((string.Equals(collision.tag, "PlayerOne") || (string.Equals(collision.tag, "PlayerTwo")) && !isTriggered))
                {
            MazeGenerator levelManager = GameObject.FindGameObjectWithTag("Maze").GetComponent<MazeGenerator>();
            levelManager.SetGameWon(string.Equals(collision.tag, "PlayerOne"));
            Debug.Log(collision.tag);
            Debug.Log(levelManager);
            isTriggered = true;
        }
       
    }
}
