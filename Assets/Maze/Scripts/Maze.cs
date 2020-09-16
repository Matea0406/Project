using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Maze : MonoBehaviour
{
    

    public Sprite goal;
    int width;
    int height;
    [SerializeField]
    string connections;

    public MazeGenerator instance;
    bool[,] grid;
    System.Random rg;
    int startX;
    int startY;
    public bool[,] Grid
    {
        get { return grid; }
    }
    
    public Maze(int width, int height, System.Random rg)
    {
        this.width = width;
        this.height = height;
        this.startX = 1;
        this.startY = 1;
        this.rg = rg;
    }
    public Maze(int width, int height, int startX, int startY, System.Random rg)
    {
        this.width = width;
        this.height = height;

        this.startX = startX;
        this.startY = startY;

        this.rg = rg;
    }
    public Vector2 Position
    {
        get
        {
            return new Vector2(width, height);

        }
    }
    public int[] Connections
    {
        get
        {
            connections = connections.Replace(" ", "");
            string[] connectionsStrArr = connections.Split(',');

            return Array.ConvertAll(connectionsStrArr, s => int.Parse(s));
        }
    }
    public void Generate()
    {
        grid = new bool[width, height];

        startX = 1;
        startY = 1;

        grid[startX, startY] = true;

        MazeDigger(startX, startY);
    }
   
   
    void MazeDigger(int x, int y)
    {
        int[] directions = new int[] { 1, 2, 3, 4 };

        Tools.Shuffle(directions, rg);
        for (int i = 0; i < directions.Length; i++)
        {
            if (directions[i] == 1)
            {
                if (y - 2 <= 0)
                    continue;

                if (grid[x, y - 2] == false)
                {
                    grid[x, y - 2] = true;
                    grid[x, y - 1] = true;

                    MazeDigger(x, y - 2);
                }
            }

            if (directions[i] == 2)
            {
                if (x - 2 <= 0)
                    continue;

                if (grid[x - 2, y] == false)
                {
                    grid[x - 2, y] = true;
                    grid[x - 1, y] = true;

                    MazeDigger(x - 2, y);
                }
            }

            if (directions[i] == 3)
            {
                if (x + 2 >= width - 1)
                    continue;

                if (grid[x + 2, y] == false)
                {
                    grid[x + 2, y] = true;
                    grid[x + 1, y] = true;

                    MazeDigger(x + 2, y);
                }
            }

            if (directions[i] == 4)
            {
                if (y + 2 >= height - 1)
                    continue;

                if (grid[x, y + 2] == false)
                {
                    grid[x, y + 2] = true;
                    grid[x, y + 1] = true;

                    MazeDigger(x, y + 2);
                }
            }
        }
    }
    
    public Vector2 GetGoalPosition()
    {
        int radius = 1;

        int endX = width - startX;
        int endY = height - startY;

        for (int x = endX - radius; x <= endX + radius; x++)
        {
            for (int y = endY - radius; y <= endY + radius; y++)
            {
                if (GetCell(x, y))
                {
                    return new Vector2(x, y);
                }
            }
        }


        return Vector2.one;
    }

    public bool GetCell(int x, int y)
    {
        if (x >= width || x < 0 || y >= height || y <= 0)
        {
            return false;
        }

        return grid[x, y];

    }
   
}

public class Tools
{

    public static T[] Shuffle<T>(T[] array, System.Random rg)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            int randomIndex = rg.Next(i, array.Length);

            T tempItem = array[randomIndex];

            array[randomIndex] = array[i];
            array[i] = tempItem;
        }

        return array;
    }
}
