using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance
    {
        get;
        private set;
    }

    Table[][] tableGrid;

    [SerializeField]
    private GameObject TablePrefab;

    [SerializeField]
    private FoodType[] FoodOptions;

    [SerializeField]
    private int gridWidth = 3;

    [SerializeField]
    private int gridHeight = 2;

    [SerializeField]
    private float horizontalSpace = 1.5f;

    [SerializeField]
    private float verticalSpace = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance)
        {
            Destroy(this);
        }
        Instance = this;

        //Possibly generate table grid here


        tableGrid = new Table[gridWidth][];
        for (int i = 0; i < gridWidth;i++)
        {
            tableGrid[i] = new Table[gridHeight];
            for (int j = 0; j < gridHeight; j++)
            {
                GameObject tableObj = Instantiate(TablePrefab);
                Table table = tableObj.GetComponent<Table>();
                if (table)
                {
                    tableGrid[i][j] = table;
                    finishTable(table);
                }
                tableObj.transform.position = new Vector3(i * horizontalSpace, j * verticalSpace);
            }
        }
    }
    
    public void endPlatterDrag(Platter platter, Vector3 position)
    {
        //translate from world space into game space
        int x = Mathf.FloorToInt(position.x / horizontalSpace) + 1;
        int y = Mathf.FloorToInt(position.y / verticalSpace) + 1;
        servePlatter(platter, x, y);
    }

    // x and y are the coordinates, 1 indexed
    // (since <1,1> will hit <0,0> <0,1> <1,0> and <1,1>)
    private void servePlatter(Platter platter, int x, int y)
    {
        //Top Left
        tableGrid[x - 1][y].feedDish(platter.Foods[0]);
        //Top Right
        tableGrid[x][y].feedDish(platter.Foods[1]);
        //Bottom Right
        tableGrid[x][y - 1].feedDish(platter.Foods[2]);
        //Bottom Left
        tableGrid[x - 1][y - 1].feedDish(platter.Foods[3]);
    }

    public Platter newPlatter()
    {
        Platter platter =  Platter.CreateInstance<Platter>();
        platter.Foods[0] = getRandomFood();
        for (int i = 1; i < 4; i++)
        {
            if (Random.Range(0, 1) > 0.7f)
            {
                platter.Foods[i] = getRandomFood();
            }
        }
        return platter;
    }

    public void finishTable(Table table)
    {
        int requestCount = 4;
        FoodType[] requests = new FoodType[requestCount];
        for(int i = 0; i < requestCount; i++)
        {
            requests[i] = getRandomFood();
        }
        table.setFoodRequest(requests);
    }

    private FoodType getRandomFood()
    {
        return FoodOptions[(int)Random.Range(0, FoodOptions.Length - 1)];
    }
}
