using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private GameObject _prefab;
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
        
        for(int y = 0; y <= height; y++)
        {
            for(int x = 0; x <= width; x++)
            {
                grid = new Tile[height, width];
                GameObject pref = CreatePrefabs();
                var component = pref.GetComponent<Tile>();
                Vector2Int vector2Int = new Vector2Int(y, x);
                grid[y, x] = component;
                grid[y, x].coordinates = vector2Int;
            }
        }
    }

    private GameObject CreatePrefabs()
    {
        Vector3 tr = spawnPoint.transform.position;
         _prefab = Instantiate(prefab, tr, Quaternion.identity);
        return _prefab;
    }
}
