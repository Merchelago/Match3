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
    private RectTransform spawnPoint;
    [SerializeField]
    private Tile[,] grid;

    private void Start()
    {
        
        CreateGrid();
    }

    private void CreateGrid()
    {
        Vector3 tr = gameObject.transform.localPosition;
        for (int y = 0; y < height; y++)
        {
            for(int x = 0; x < width; x++)
            {
                grid = new Tile[height, width];
                GameObject pref = CreatePrefabs(tr);
                pref.transform.SetParent(gameObject.transform, false);
                var tile = pref.GetComponent<Tile>();
                var rect = pref.GetComponent<RectTransform>();

                rect.position = new Vector3(spawnPoint.position.x+x, spawnPoint.position.y+y);
                
                Vector2Int vector2Int = new Vector2Int(y, x);
                grid[y, x] = tile;
                grid[y, x].coordinates = vector2Int;
            }
        }
    }

    private GameObject CreatePrefabs(Vector3 tr)
    {
        
         _prefab = Instantiate(prefab, tr, Quaternion.identity);
        return _prefab;
    }
}
