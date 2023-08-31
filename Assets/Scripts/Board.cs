using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private int width;
    [SerializeField]
    private int height;
    [SerializeField]
    private GameObject spawnPoint;
    [SerializeField]
    private Tile[,] grid;

    private void Start()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        Vector3 tr = spawnPoint.transform.position;
        for(int y = 0; y <= height; y++)
        {
            for(int x = 0; x <= width; x++)
            {
                grid = new Tile[height, width];
                var cell = Instantiate(prefab, tr, Quaternion.identity);
                Vector2Int vector2Int = new Vector2Int(y, x);
                //grid[y, x] = (Tile)cell;
                grid[y, x].coordinates = vector2Int;
            }
        }
    }

}
