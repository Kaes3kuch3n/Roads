using UnityEngine;

public class World : MonoBehaviour {

    [SerializeField]
    private GameObject startTile;
    [SerializeField]
    private int worldWidth;
    [SerializeField]
    private int worldHeight;

    private GameObject[,] tiles;

    public static World Instance { get; private set; }

    private void Start()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one world script in the scene!");
        }

        Instance = this;

        tiles = new GameObject[worldWidth, worldHeight];

        for (int y = 0; y < worldWidth; y++)
        {
            for (int x = 0; x < worldHeight; x++)
            {
                GameObject tile = Instantiate(startTile);

                tile.transform.position = new Vector3(x * 0.5F - y * 0.5F, -(x * 0.25F) - y * 0.25F);
                tile.GetComponent<SpriteRenderer>().sortingOrder = x + y;
                tile.transform.parent = this.transform;
                tile.transform.name = "Tile [" + x + ", " + y + "]";
                tiles[x, y] = tile;
            }
        }
    }

    public void ChangeTile(GameObject tile, Sprite newTile)
    {
        tile.GetComponent<SpriteRenderer>().sprite = newTile;
    }
}
