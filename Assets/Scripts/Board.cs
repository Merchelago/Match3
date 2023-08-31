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
        grid = new Tile[height, width];
        
        
        for (int y = 0; y < height; y++)
        {
            for(int x = 0; x < width; x++)
            {
                
                GameObject pref = CreateCell();
                pref.transform.SetParent(gameObject.transform, false);
                var tile = pref.GetComponent<Tile>();
                var rect = pref.GetComponent<RectTransform>();

                //rect.position = new Vector3(vect.x+x, vect.y+y*-1);
                
                
                grid[y, x] = tile;
                grid[y, x].coordinates = new(x,y);
            }
        }
    }

    private GameObject CreateCell()
    {
        
        _prefab = Instantiate(prefab);
        return _prefab;
    }
}
