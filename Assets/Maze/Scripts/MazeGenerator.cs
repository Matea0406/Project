using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public bool isStartNode;
    public bool isGoalNode;
    public IDictionary<Vector2, bool> walkablePositions = new Dictionary<Vector2, bool>();
    public int mazeWidth;
    public int mazeHeight;
    public Sprite floorSprite;
    public Sprite roofSprite;
    public Sprite door;
    public static MazeGenerator instance;
    public Vector2 mazeGoalPosition;
    public MazeSprite mazeSpritePrefab;
    public Player playerSpritePrefab;
    public Goal goalSpritePrefab;
   
    Player playerControl;
    System.Random mazeRG;
    Maze maze;
    public GameObject uiPikachuWinsPrefab;
    public GameObject uiTogepiWinsPrefab;
    public GameObject homeButton;
    MazeGenerator mazeGenerator;
   
    //public delegate void MazeReadyAction();
   // public static event MazeReadyAction OnMazeReady;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
       // if (OnMazeReady != null)
      //  {
      //      OnMazeReady();
     //   }
        mazeRG = new System.Random();

        if (mazeWidth % 2 == 0)
            mazeWidth++;

        if (mazeHeight % 2 == 0)
        {
            mazeHeight++;
        }

        maze = new Maze(mazeWidth, mazeHeight, mazeRG);
        maze.Generate();
      
        DrawMaze();
        mazeGoalPosition = maze.GetGoalPosition();
       
        Debug.Log(mazeGoalPosition);
       
    }
    void DrawMaze()
    {
        for (int x = 0; x < mazeWidth; x++)
        {
            for (int y = 0; y < mazeHeight; y++)
            {
                Vector2 position = new Vector2(x, y);

                if (maze.Grid[x, y] == true)
                {
                    CreateMazeSprite(position, floorSprite, transform, 0, mazeRG.Next(0, 3) * 90);
                    walkablePositions.Add(new KeyValuePair<Vector2, bool>(position, true));
                    Debug.Log(position.x+","+position.y);
                }
                else
                {
                    CreateMazeSprite(position, roofSprite, transform, 0, 0);

                }


                

            }
           
        }
     
       
    }
    public static Vector2 GetRandomPozitions()
    {
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }
    void CreateMazeSprite(Vector3 position, Sprite sprite, Transform parent, int sortingOrder, float rotation)
    {
        MazeSprite mazeSprite = Instantiate(mazeSpritePrefab, position, Quaternion.identity) as MazeSprite;
        mazeSprite.SetSprite(sprite, sortingOrder);
        mazeSprite.transform.SetParent(parent);
        mazeSprite.transform.Rotate(0, 0, rotation);
    }
 

    
    public bool GetMazeGridCell(int x, int y)
    {
       return maze.GetCell(x,y);

    }
    public void StartEndGame(bool isPikachuWon)
    {
        StartCoroutine(EndGame(isPikachuWon));
    }
    public void SetGameWon(bool isPikachuWon)
    {
       

        StartEndGame(isPikachuWon);
        Destroy(playerSpritePrefab.gameObject); // Disable blip movement

    }

    IEnumerator EndGame(bool isPikachuWon)
    {
        //cameraTransform.parent = null;

        // yield return MoveCameraToBlock();

        Instantiate(isPikachuWon ? uiPikachuWinsPrefab : uiTogepiWinsPrefab, new Vector2(mazeGoalPosition.x,mazeGoalPosition.y), new Quaternion(0, 0, 0, 0));
        homeButton.SetActive(true);
        yield break;
    }
   
   
}
