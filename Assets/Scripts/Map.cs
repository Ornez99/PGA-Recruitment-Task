using UnityEngine;
using Zenject;

public class Map : MonoBehaviour
{
    [SerializeField] private int size;
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject ground;
    private Node[,] grid;
    private Texture2D groundTexture2D;
    private float slowGroundSpeed = 0.2f;
    private float fastGroundSpeed = 1f;
    Chest.Factory chestFactory;
    Doors.Factory doorsFactory;

    private void Awake()
    {
        GenerateGrid();
        PlaceDoors();
        PlaceChest();
        GenerateWalls();
        CreateGroundTexture();
        SetGroundTextureAndSize();
    }
    
    [Inject]
    private void Construct(Chest.Factory chestFactory, Doors.Factory doorsFactory)
    {
        this.chestFactory = chestFactory;
        this.doorsFactory = doorsFactory;
    }

    private void GenerateGrid()
    {
        grid = new Node[size, size];
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                grid[x, y] = new Node(true, x, y);
            }
        }
        grid[(size / 2) - 1, (size / 2) - 1].buildable = false;
    }

    private void GenerateWalls()
    {
        for(int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                if(x == 0 || y == 0 || x == size - 1 || y == size - 1)
                {
                    Node node = grid[x, y];
                    if (node.buildable)
                    {
                        Instantiate(wall, node.centerPosition, Quaternion.Euler(0, GetRotationOfBuilding(node), 0));
                        node.buildable = false;
                    }
                }
            }
        }
    }

    private void PlaceChest()
    {
        bool chestPlaced = false;
        while(chestPlaced == false)
        {
            int xId = Random.Range(1, size - 1);
            int yId = Random.Range(1, size - 1);
            if(grid[xId,yId].buildable == true)
            {
                Node node = grid[xId, yId];
                node.buildable = false;
                Chest ins = chestFactory.Create();
                ins.transform.position = node.centerPosition + Vector3.up * 0.5f;
                ins.transform.rotation = Quaternion.Euler(0, GetRotationOfBuilding(node) - 180, 0);

                chestPlaced = true;
            }
        }
    }

    private void PlaceDoors()
    {
        int side = Random.Range(0, 4);
        int xId = 0;
        int yId = 0;
        switch (side)
        {
            case 0:
                yId = size - 1;
                xId = Random.Range(1, size - 1);
                break;
            case 1:
                yId = Random.Range(1, size - 1);
                xId = size - 1;
                break;
            case 2:
                yId = 0;
                xId = Random.Range(1, size - 1);
                break;
            case 3:
                yId = Random.Range(1, size - 1);
                xId = 0;
                break;
        }
        
        Node node = grid[xId, yId];
        node.buildable = false;
        Doors ins = doorsFactory.Create();
        ins.transform.position = node.centerPosition;
        ins.transform.rotation = Quaternion.Euler(0, GetRotationOfBuilding(node), 0);
    }

    private float GetRotationOfBuilding(Node node)
    {
        int mediumPoint = size / 2;
        int xDiff = Mathf.Abs(node.xId - mediumPoint);
        int yDiff = Mathf.Abs(node.yId - mediumPoint);

        if(xDiff > yDiff)
        {
            if (node.xId < mediumPoint)
                return 270;
            else
                return 90;
        }
        else
        {
            if (node.yId < mediumPoint)
                return 180;
            else
                return 0;
        }
    }

    private void CreateGroundTexture()
    {
        groundTexture2D = new Texture2D(size, size);
        int seed = Random.Range(0, 9999);
        float[,] groundNoise = Noise.GenerateNoiseMap(size, seed, 1, 4, 1, 0.5f, Vector2.zero);

        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                float textureAStrength = (groundNoise[x, y] >= 0.5f) ? 1 : 0;
                float textureBStrength = 1 - textureAStrength;
                grid[x,y].speed = (groundNoise[x, y] >= 0.5f) ? slowGroundSpeed : fastGroundSpeed;
                groundTexture2D.SetPixel(x, y, new Color(textureAStrength, textureBStrength, 0, 0));
            }
        }
    }

    private void SetGroundTextureAndSize()
    {
        groundTexture2D.Apply();
        ground.GetComponent<Renderer>().material.SetTexture("_Control", groundTexture2D);
    }

    public Node GetClosestNodeFromPos(Vector3 position)
    {
        if (position.x < 0 || position.x >= size || position.z < 0 || position.z >= size)
            return null;

        return grid[Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.z)];
    }

    public Node GetNodeFromPos(Vector3 position)
    {
        if (position.x < 0 || position.x >= size || position.z < 0 || position.z >= size)
            return null;

        return grid[Mathf.FloorToInt(position.x), Mathf.FloorToInt(position.z)];
    }
}
